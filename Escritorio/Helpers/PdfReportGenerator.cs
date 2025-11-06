using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;

// Alias para evitar ambigüedad entre System.Drawing.Color y QuestPDF.Infrastructure.Color
using DrawingColor = System.Drawing.Color;

namespace Escritorio.Helpers
{
    public static class PdfReportGenerator
    {
        // Genera un PNG con un gráfico de torta y lo devuelve como array de bytes.
        private static byte[] RenderPieChartPng(List<ReporteGastosUsuarioDto> gastos, int width = 700, int height = 320)
        {
            if (gastos == null) gastos = new List<ReporteGastosUsuarioDto>();

            var total = gastos.Sum(x => x.TotalGastado);
            using var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(DrawingColor.White);

            // Área del gráfico (cuadrado) y posición de la leyenda
            int chartSize = Math.Min(height - 20, (width / 2));
            var chartRect = new Rectangle(10, 10, chartSize, chartSize);
            var legendX = chartRect.Right + 20;
            var legendY = chartRect.Top;

            // Paleta de colores (System.Drawing.Color)
            DrawingColor[] palette = new DrawingColor[]
            {
                DrawingColor.FromArgb(0x2E,0x86,0xAB),
                DrawingColor.FromArgb(0xF2,0x7D,0x50),
                DrawingColor.FromArgb(0x8D,0xB9,0x52),
                DrawingColor.FromArgb(0xE8,0xCA,0x4A),
                DrawingColor.FromArgb(0xA3,0x6E,0xF3),
                DrawingColor.FromArgb(0xFF,0x99,0x66),
                DrawingColor.FromArgb(0x66,0xCC,0xCC),
                DrawingColor.FromArgb(0xCC,0x66,0x99)
            };

            float startAngle = 0f;
            int i = 0;

            if (total <= 0)
            {
                // Texto cuando no hay datos
                using var noDataFont = new Font("Arial", 12);
                var msg = "No hay gastos para graficar";
                var sz = g.MeasureString(msg, noDataFont);
                g.DrawString(msg, noDataFont, Brushes.Black, (width - sz.Width) / 2, (height - sz.Height) / 2);
            }
            else
            {
                foreach (var u in gastos)
                {
                    var sweep = (float)(u.TotalGastado / total) * 360f;
                    using var brush = new SolidBrush(palette[i % palette.Length]);
                    g.FillPie(brush, chartRect, startAngle, sweep);
                    startAngle += sweep;
                    i++;
                }

                // Borde del círculo
                g.DrawEllipse(Pens.Gray, chartRect);
            }

            // Leyenda
            int leyendaIndex = 0;
            float boxSize = 14f;
            using var leyendaFont = new Font("Arial", 10);
            var legendSpacing = 6f;
            foreach (var u in gastos)
            {
                var color = palette[leyendaIndex % palette.Length];
                using var brush = new SolidBrush(color);
                var y = legendY + leyendaIndex * (boxSize + legendSpacing);
                // rect color
                g.FillRectangle(brush, legendX, y, boxSize, boxSize);
                g.DrawRectangle(Pens.Black, legendX, y, boxSize, boxSize);
                // texto: nombre (y porcentaje)
                var porcentaje = total > 0 ? (double)((u.TotalGastado / total) * 100) : 0.0;
                var txt = $"{u.NombreUsuario ?? "Usuario"} - {u.TotalGastado:C2} ({porcentaje:F1}%)";
                g.DrawString(txt, leyendaFont, Brushes.Black, legendX + boxSize + 8, y);
                leyendaIndex++;
            }

            // Guardar a bytes PNG (usar System.Drawing.Imaging.ImageFormat calificado para evitar ambigüedad)
            using var ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        // Generador del PDF que incluye el gráfico de torta y la tabla de totales por usuario.
        public static void GeneratePdf(ReporteGastosGrupoDto reporte, string filePath)
        {
            // Asegurar licencia (es seguro llamarlo repetidamente)
            QuestPDF.Settings.License = LicenseType.Community;

            if (reporte == null) throw new ArgumentNullException(nameof(reporte));
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));

            var gastos = reporte.GastosUsuarios ?? new List<ReporteGastosUsuarioDto>();
            var total = reporte.TotalGrupo;

            // Generar la imagen del gráfico (PNG en memoria)
            var piePng = RenderPieChartPng(gastos, width: 700, height: 320);

            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.PageColor(Colors.White); // QuestPDF color
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .Column(col =>
                        {
                            col.Item().Text(reporte.NombreGrupo ?? "Reporte de Gastos").FontSize(18).Bold();
                            col.Item().Text($"Fecha: {reporte.FechaGeneracion:dd/MM/yyyy HH:mm}").FontSize(10);
                            col.Item().PaddingVertical(6).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                        });

                    page.Content()
                        .PaddingVertical(10)
                        .Column(content =>
                        {
                            content.Spacing(8);

                            content.Item().Element(e =>
                            {
                                using var ms = new MemoryStream(piePng);
                                
                                e.Height(220).Image(ms);
                            });

                            // Resumen total
                            content.Item().PaddingTop(6).Row(r =>
                            {
                                r.RelativeColumn().Stack(s =>
                                {
                                    s.Item().Text($"Total gastado del grupo: {total:C2}").FontSize(12).SemiBold();
                                    s.Item().Text($"Usuarios incluidos: {gastos.Count}").FontSize(10);
                                });
                            });

                            content.Item().PaddingTop(6);

                            // Tabla de usuarios
                            content.Item().Element(ContainerTable);

                            content.Item().PaddingTop(10).Text(t =>
                            {
                                t.Span("Generado por: ").SemiBold();
                                t.Span("Sistema de Reportes");
                            });

                            void ContainerTable(IContainer containerTable)
                            {
                                containerTable.Table(table =>
                                {
                                    
                                    table.ColumnsDefinition(cols =>
                                    {
                                        cols.RelativeColumn(3); // usuario
                                        cols.RelativeColumn(3); // email
                                        cols.RelativeColumn(2); // total
                                        cols.RelativeColumn(2); // porcentaje
                                    });

                                    // Header
                                    table.Header(header =>
                                    {
                                        header.Cell().Element(CellStyle).Text("Usuario").SemiBold();
                                        header.Cell().Element(CellStyle).Text("Email").SemiBold();
                                        header.Cell().Element(CellStyle).AlignRight().Text("Total").SemiBold();
                                        header.Cell().Element(CellStyle).AlignRight().Text("% del Grupo").SemiBold();
                                    });

                                    // Rows
                                    foreach (var u in gastos)
                                    {
                                        var porcentaje = total > 0 ? (double)((u.TotalGastado / total) * 100) : 0.0;
                                        table.Cell().Element(CellStyle).Text(u.NombreUsuario ?? "").FontSize(11);
                                        table.Cell().Element(CellStyle).Text(u.Email ?? "").FontSize(11);
                                        table.Cell().Element(CellStyle).AlignRight().Text($"{u.TotalGastado:C2}").FontSize(11);
                                        table.Cell().Element(CellStyle).AlignRight().Text($"{porcentaje:F1}%").FontSize(11);
                                    }

                                    IContainer CellStyle(IContainer c) => c.PaddingVertical(6).PaddingHorizontal(5);
                                });
                            }
                        });

                    // Footer simple
                    page.Footer()
                        .AlignCenter()
                        .Text($"Generado por Sistema de Reportes - {reporte.FechaGeneracion:dd/MM/yyyy HH:mm}")
                        .FontSize(9);
                });
            });

            // Generar PDF en disco
            doc.GeneratePdf(filePath);
        }
    }
}