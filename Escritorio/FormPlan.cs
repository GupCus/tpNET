using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;
namespace Escritorio
{
    public partial class FormPlan : Form
    {
        private bool confirma = false;
        public FormPlan()
        {
            InitializeComponent();
        }
        private async void FormPlan_Load(object sender, EventArgs e)
        {
            await CargarPlanes();

        }

        private async Task CargarPlanes()
        {
            try
            {
                var planes = await PlanApiClient.GetAllAsync();
                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = planes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"Error: {ex.Message}", "Error al cargar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is PlanDTO pl)
            {
                txtID.Text = pl.Id.ToString();
                txtNombre.Text = pl.Nombre;
                txtDescripcion.Text = pl.Descripcion;
                txtFechaDesde.Text = pl.FechaInicio.ToString();
                txtFechaHasta.Text = pl.FechaFin.ToString();
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

                if (confirma)
                {
                    btnEliminar.Text = "Eliminar";
                    confirma = false;
                }
            }
        }
        private object LimpiarPlan()
        {
            bool nuevo = string.IsNullOrEmpty(txtID.Text);
            if (!nuevo)
            {
                PlanUpdateDTO plUpdate = new()
                {
                    Id = string.IsNullOrEmpty(txtID.Text) ? 0 : int.Parse(txtID.Text),
                    Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Nombre" : txtNombre.Text,
                    Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Descripcion" : txtDescripcion.Text,
                    FechaInicio = DateTime.Parse(txtFechaDesde.Text),
                    FechaFin = DateTime.Parse(txtFechaHasta.Text),
                };
                return plUpdate;
            }
            else
            {
                PlanCreateDTO pl = new()
                {
                    Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Nombre" : txtNombre.Text,
                    Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Descripcion" : txtDescripcion.Text,
                    FechaInicio = DateOnly.Parse(txtFechaDesde.Text),
                    FechaBaja = DateOnly.Parse(txtFechaHasta.Text),
                    FechaAlta = DateOnly.FromDateTime(DateTime.Today),
                };
                return pl;

            }
        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            PlanCreateDTO pl = (PlanCreateDTO)LimpiarPlan();
            await PlanApiClient.AddAsync(pl);
            await CargarPlanes();

        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            PlanUpdateDTO pl = (PlanUpdateDTO)LimpiarPlan();
            await PlanApiClient.UpdateAsync(pl);
            await CargarPlanes();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!confirma)
            {
                btnEliminar.Text = "¿ESTÁ SEGURO?";
                confirma = true;
            }
            
            else
            {
                await PlanApiClient.DeleteAsync(((PlanDTO)dataGridView1.CurrentRow.DataBoundItem).Id);
                await CargarPlanes();
                btnEliminar.Text = "ELIMINAR PLAN";
                confirma = false;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
