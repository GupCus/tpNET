using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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
                _grupos = new List<GrupoDTO>(grupos);

                if (_grupos != null && _grupos.Count > 0)
                {
                    cmbGrupos.DataSource = _grupos;
                    cmbGrupos.DisplayMember = "Nombre";
                    cmbGrupos.ValueMember = "Id";
                    cmbGrupos.Refresh();

                    if (cmbGrupos.Items.Count > 0)
                        cmbGrupos.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se encontraron grupos", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                MessageBox.Show("Por favor seleccione un grupo", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnGenerarReporte.Enabled = false;
                btnGenerarReporte.Text = "Generando...";

                var grupoId = (int)cmbGrupos.SelectedValue;
                var reporte = await ReporteApiClient.GetReporteGastosGrupoAsync(grupoId);

                if (reporte == null)
                {
                    MessageBox.Show("El reporte recibido está vacío o es nulo", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ AHORA USA DTOs.ReporteGastosGrupoDto (sin conflicto)
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF Files|*.pdf";
                    saveDialog.FileName = $"Reporte_Gastos_{reporte.NombreGrupo}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ReporteHelper.GenerarPDF(reporte, saveDialog.FileName);
                        MessageBox.Show($"Reporte generado exitosamente:\n{saveDialog.FileName}",
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerarReporte.Enabled = true;
                btnGenerarReporte.Text = "Generar Reporte PDF";
            }
        }
    }
}