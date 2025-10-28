using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DTOs; 

namespace Escritorio.Helpers
{
    public static class ReporteHelper
    {
        public static void GenerarPDF(ReporteGastosGrupoDto reporte, string filePath)
        {
            if (reporte == null) throw new ArgumentNullException(nameof(reporte));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                document.Open();

                // Título
                var tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var titulo = new Paragraph($"Reporte de Gastos - {reporte.NombreGrupo}", tituloFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                document.Add(titulo);

                // Fecha de generación
                var fechaFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fecha = new Paragraph($"Generado el: {reporte.FechaGeneracion:dd/MM/yyyy HH:mm}", fechaFont)
                {
                    Alignment = Element.ALIGN_RIGHT,
                    SpacingAfter = 15f
                };
                document.Add(fecha);

                // Tabla de gastos
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 50, 25, 25 });

                // Encabezados de tabla
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                table.AddCell(new PdfPCell(new Phrase("Usuario", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Email", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Total Gastado", headerFont)));

                // Datos
                var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                // ✅ Validar que GastosUsuarios no sea null
                if (reporte.GastosUsuarios != null)
                {
                    foreach (var gastoUsuario in reporte.GastosUsuarios)
                    {
                        table.AddCell(new PdfPCell(new Phrase(gastoUsuario.NombreUsuario ?? "N/A", cellFont)));
                        table.AddCell(new PdfPCell(new Phrase(gastoUsuario.Email ?? "N/A", cellFont)));
                        table.AddCell(new PdfPCell(new Phrase($"${gastoUsuario.TotalGastado:N2}", cellFont)));
                    }
                }
                else
                {
                    // Mensaje si no hay gastos
                    table.AddCell(new PdfPCell(new Phrase("No hay datos de gastos", cellFont)) { Colspan = 3 });
                }

                document.Add(table);

                // Total del grupo
                var totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                var total = new Paragraph($"\nTotal del Grupo: ${reporte.TotalGrupo:N2}", totalFont)
                {
                    Alignment = Element.ALIGN_RIGHT,
                    SpacingBefore = 20f
                };
                document.Add(total);

                document.Close();
                writer.Close();
            }
        }
    }
}