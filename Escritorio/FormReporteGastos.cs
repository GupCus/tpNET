using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using Escritorio.Helpers;

namespace Escritorio.Forms
{
    public partial class FormReporteGastos : Form
    {
        private List<GrupoDTO> _grupos;

        public FormReporteGastos()
        {
            InitializeComponent();
            _grupos = new List<GrupoDTO>();
        }

        private async void FormReporteGastos_Load(object sender, EventArgs e)
        {
            await CargarGrupos();
        }

        private async System.Threading.Tasks.Task CargarGrupos()
        {
            try
            {
                var grupos = await GrupoApiClient.GetAllAsync();
                _grupos = grupos?.ToList() ?? new List<GrupoDTO>();

                cmbGrupos.DataSource = null;
                cmbGrupos.DataSource = _grupos;
                cmbGrupos.DisplayMember = "Nombre";
                cmbGrupos.ValueMember = "Id";

                if (cmbGrupos.Items.Count > 0)
                    cmbGrupos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar grupos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (cmbGrupos.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un grupo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnGenerarReporte.Enabled = false;
                btnGenerarReporte.Text = "Generando PDF...";

                int grupoId = Convert.ToInt32(cmbGrupos.SelectedValue);

                // Obtener gastos 
                var gastos = await GastoApiClient.GetByGrupoIdAsync(grupoId);
                var gastosList = gastos?.ToList() ?? new List<GastoDTO>();

                if (!gastosList.Any())
                {
                    MessageBox.Show("No se encontraron gastos para el grupo seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Agrupar gastos por usuario y sumar montos 
                var gastosPorUsuario = gastosList
                    .GroupBy(g => g.UsuarioId)
                    .Select(grp =>
                    {
                        var first = grp.FirstOrDefault();
                        return new ReporteGastosUsuarioDto
                        {
                            NombreUsuario = first?.UsuarioNombre ?? $"Usuario {grp.Key}",
                            TotalGastado = Convert.ToDecimal(grp.Sum(x => x.Monto))
                            
                        };
                    })
                    .OrderByDescending(r => r.TotalGastado)
                    .ToList();

                var grupoSeleccionado = cmbGrupos.SelectedItem as GrupoDTO;
                var reporte = new ReporteGastosGrupoDto
                {
                    NombreGrupo = grupoSeleccionado?.Nombre ?? $"Grupo_{grupoId}",
                    FechaGeneracion = DateTime.Now,
                    GastosUsuarios = gastosPorUsuario
                };

               
                string path = null;
                this.Invoke((MethodInvoker)(() =>
                {
                    using (var dlg = new SaveFileDialog())
                    {
                        dlg.Filter = "PDF Files|*.pdf";
                        dlg.FileName = $"Reporte_Gastos_{reporte.NombreGrupo}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            path = dlg.FileName;
                        }
                    }
                }));

                if (string.IsNullOrEmpty(path))
                    return;

                
                try
                {
                    await StaThreadHelper.RunInSta(() =>
                    {
                        PdfReportGenerator.GeneratePdf(reporte, path);
                    });

                    MessageBox.Show($"Reporte PDF generado correctamente:\n{path}", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exPdf)
                {
                    MessageBox.Show($"Error al generar PDF: {exPdf.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preparar el reporte: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerarReporte.Enabled = true;
                btnGenerarReporte.Text = "Generar Reporte PDF";
            }
        }
    }
}