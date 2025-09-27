using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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
            BaseAddress = new Uri("https://localhost:7126/")
        };

        public FormGasto()
        {
            InitializeComponent();
        }

        private async void FormGasto_Load(object sender, EventArgs e)
        {
            await GetCategorias();
            await GetUsuarios();
            await GetGastos(); 
        }

        
        private async Task GetCategorias()
        {
            try
            {
                var categorias = await httpClient.GetFromJsonAsync<IEnumerable<CategoriaGasto>>("categoriagastos");

        
                cmbCategoria.DataSource = categorias?.ToList();
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task GetUsuarios()
        {
            try
            {
                var usuarios = await httpClient.GetFromJsonAsync<IEnumerable<Usuario>>("usuario");

                cmbUsuario.DataSource = usuarios?.ToList();
                cmbUsuario.DisplayMember = "NombreUsuario";
                cmbUsuario.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Gasto LimpiarGasto()
        {
            if (cmbCategoria.SelectedValue == null)
            {
                throw new InvalidOperationException("Debe seleccionar una Categoría.");
            }
            if (cmbUsuario.SelectedValue == null)
            {
                throw new InvalidOperationException("Debe seleccionar un Usuario.");
            }
            if (!float.TryParse(txtMonto.Text, out float monto))
            {
                throw new InvalidOperationException("El Monto no es un número válido.");
            }

            Gasto g = new()
            {
                Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text,
                FechaHora = txtFechaHora.Value,
                Monto = monto,
                CategoriaGastoId = (int)cmbCategoria.SelectedValue,
                UsuarioId = (int)cmbUsuario.SelectedValue
            };

            return g;
        }

        private void dgvGasto_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGasto.CurrentRow != null && dgvGasto.CurrentRow.DataBoundItem is Gasto g)
            {
                txtID.Text = g.Id?.ToString() ?? "";
                txtDescripcion.Text = g.Descripcion ?? "";
                txtFechaHora.Value = g.FechaHora;
                txtMonto.Text = g.Monto.ToString();

                
                if (cmbCategoria.DataSource != null)
                {
                    cmbCategoria.SelectedValue = g.CategoriaGastoId;
                }
                if (cmbUsuario.DataSource != null)
                {
                    cmbUsuario.SelectedValue = g.UsuarioId;
                }

                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                
                if (confirmarEliminar)
                {
                    btnEliminar.Text = "Eliminar Gasto";
                    confirmarEliminar = false;
                }
            }
        }

        /* API Gasto */
        // GET ALL Gasto || Actualización de la tabla principal
        private async Task GetGastos()
        {
            try
            {
                
                var gastos = await httpClient.GetFromJsonAsync<IEnumerable<Gasto>>("gasto");
                this.dgvGasto.DataSource = gastos?.ToList();
                txtID.Text = string.Empty; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los gastos: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // POST Gasto
        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            try
            {
                Gasto g = this.LimpiarGasto();
                await httpClient.PostAsJsonAsync("gasto", g);
                await this.GetGastos();
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el nuevo gasto: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // PUT Gasto
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGasto.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un gasto para modificar.", "Advertencia");
                return;
            }

            try
            {
                Gasto g = this.LimpiarGasto();
                int? idSeleccionado = ((Gasto)dgvGasto.CurrentRow.DataBoundItem).Id;

                
                g.Id = idSeleccionado;

                await httpClient.PutAsJsonAsync($"gasto/{idSeleccionado}", g);
                await this.GetGastos();
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el gasto: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DELETE gasto
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGasto.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un gasto para eliminar.", "Advertencia");
                return;
            }

            if (!confirmarEliminar)
            {
                btnEliminar.Text = "¿ESTÁ SEGURO?";
                confirmarEliminar = true;
            }
            // Hacer click de vuelta para ejecutar esto
            else
            {
                try
                {
                    int? idSeleccionado = ((Gasto)dgvGasto.CurrentRow.DataBoundItem).Id;
                    await httpClient.DeleteAsync($"gasto/{idSeleccionado}");
                    await this.GetGastos();
                    btnEliminar.Text = "Eliminar Gasto";
                    confirmarEliminar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el gasto: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}