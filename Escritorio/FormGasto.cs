using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FormGasto : Form
    {
        /* Lógica del form */
        private bool confirmarEliminar = false;

        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5032")
        };

        public FormGasto()
        {
            InitializeComponent();
        }

        private void FormGasto_Load(object sender, EventArgs e)
        {
            // No necesitamos cargar un enum para EstadoGasto ya que no existe en el dominio
            GetGastos();
        }

        // Método que se encarga de sanitizar el gasto para no enviar nulos
        private Gasto LimpiarGasto()
        {
            Gasto g = new()
            {
                Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text,
                FechaHora = txtFechaHora.Value,
                Monto = float.TryParse(txtMonto.Text, out float monto) ? monto : 0f
                // CategoriaGasto y Usuario se deberían seleccionar de combobox
                // Por ahora los dejamos como null o valores por defecto
            };

            return g;
        }

        // Al Seleccionar un gasto (fila), se rescatan sus datos a la UI
        private void dgvGasto_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGasto.CurrentRow != null && dgvGasto.CurrentRow.DataBoundItem is Gasto g)
            {
                txtID.Text = g.Id?.ToString() ?? "";
                txtDescripcion.Text = g.Descripcion ?? "";
                txtFechaHora.Value = g.FechaHora;
                txtMonto.Text = g.Monto.ToString();

                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                // Reset eliminar
                if (confirmarEliminar)
                {
                    btnEliminar.Text = "ELIMINAR GASTO";
                    confirmarEliminar = false;
                }
            }
        }

        /* API Gasto */
        // GET ALL Gasto || Actualización de la tabla principal
        private async void GetGastos()
        {
            var gastos = await httpClient.GetFromJsonAsync<IEnumerable<Gasto>>("gasto");
            this.dgvGasto.DataSource = gastos;
        }

        // POST Gasto
        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            Gasto g = this.LimpiarGasto();
            await httpClient.PostAsJsonAsync("gasto", g);
            this.GetGastos();
        }

        // PUT Gasto
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            Gasto g = this.LimpiarGasto();
            await httpClient.PutAsJsonAsync($"gasto/{((Gasto)dgvGasto.CurrentRow.DataBoundItem).Id}", g);
            this.GetGastos();
        }

        // DELETE gasto
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!confirmarEliminar)
            {
                btnEliminar.Text = "¿ESTÁ SEGURO?";
                confirmarEliminar = true;
            }
            // Hacer click de vuelta para ejecutar esto
            else
            {
                await httpClient.DeleteAsync($"gasto/{((Gasto)dgvGasto.CurrentRow.DataBoundItem).Id}");
                this.GetGastos();
                btnEliminar.Text = "ELIMINAR GASTO";
                confirmarEliminar = false;
            }
        }
    }
}
