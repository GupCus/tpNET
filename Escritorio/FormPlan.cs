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
        private List<GrupoDTO> grupos = new List<GrupoDTO>();

        public FormPlan()
        {
            InitializeComponent();
        }

        private async void FormPlan_Load(object sender, EventArgs e)
        {
            await CargarGrupos();
            await CargarPlanes();
        }

        private async Task CargarGrupos()
        {
            try
            {
                grupos = (await GrupoApiClient.GetAllAsync()).ToList();

                cmbGrupo.DataSource = grupos;
                cmbGrupo.DisplayMember = "Nombre";
                cmbGrupo.ValueMember = "Id";
                cmbGrupo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR al cargar grupos: {ex.Message}");
                MessageBox.Show($"Error al cargar grupos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                txtFechaDesde.Value = new DateTime(pl.FechaInicio.Year, pl.FechaInicio.Month, pl.FechaInicio.Day);
                txtFechaHasta.Value = new DateTime(pl.FechaFin.Year, pl.FechaFin.Month, pl.FechaFin.Day);

                // Seleccionar el grupo correspondiente en el ComboBox
                if (cmbGrupo.Items.Count > 0)
                {
                    cmbGrupo.SelectedValue = pl.GrupoId;
                }

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
                    FechaInicio = txtFechaDesde.Value,
                    FechaFin = txtFechaHasta.Value,
                    GrupoId = cmbGrupo.SelectedValue != null ? (int)cmbGrupo.SelectedValue : 0
                };
                return plUpdate;
            }
            else
            {
                PlanCreateDTO pl = new()
                {
                    Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Nombre" : txtNombre.Text,
                    Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Descripcion" : txtDescripcion.Text,
                    FechaInicio = DateOnly.FromDateTime(txtFechaDesde.Value),
                    FechaBaja = DateOnly.FromDateTime(txtFechaHasta.Value),
                    FechaAlta = DateOnly.FromDateTime(DateTime.Today),
                    GrupoId = cmbGrupo.SelectedValue != null ? (int)cmbGrupo.SelectedValue : 0
                };
                return pl;
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedValue == null || cmbGrupo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un grupo", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                txtID.Text = "";
                PlanCreateDTO pl = (PlanCreateDTO)LimpiarPlan();
                await PlanApiClient.AddAsync(pl);
                await CargarPlanes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar plan: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedValue == null || cmbGrupo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un grupo", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PlanUpdateDTO pl = (PlanUpdateDTO)LimpiarPlan();
                await PlanApiClient.UpdateAsync(pl);
                await CargarPlanes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar plan: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                try
                {
                    await PlanApiClient.DeleteAsync(((PlanDTO)dataGridView1.CurrentRow.DataBoundItem).Id);
                    await CargarPlanes();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar plan: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnEliminar.Text = "ELIMINAR PLAN";
                    confirma = false;
                }
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtFechaDesde.Value = DateTime.Today;
            txtFechaHasta.Value = DateTime.Today.AddDays(30);
            cmbGrupo.SelectedIndex = -1;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.ClearSelection();
            }
        }
    }
}