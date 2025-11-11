using Dominio;
using DTOs;
using API.Clients;

namespace Escritorio
{
    public partial class FormTarea : Form
    {
        private bool confirmarEliminar = false;
        private DateTime? fechaAltaSeleccionada = null;
        private List<PlanDTO> planes = new List<PlanDTO>();

        public FormTarea()
        {
            InitializeComponent();
        }

        private async void FormTarea_Load(object sender, EventArgs e)
        {
            txtEstado.DataSource = Enum.GetValues(typeof(EstadoTarea));
            await CargarPlanes();
            await GetTareas();
        }

        private async Task CargarPlanes()
        {
            try
            {
                planes = (await PlanApiClient.GetAllAsync()).ToList();

                cmbPlan.DataSource = planes;
                cmbPlan.DisplayMember = "Nombre";
                cmbPlan.ValueMember = "Id";
                cmbPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planes: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TareaDTO LimpiarTarea()
        {
            TareaDTO t = new()
            {
                Id = int.TryParse(txtID.Text, out int id) ? id : 0,
                Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Sin nombre" : txtNombre.Text,
                FechaHora = txtFechaHora.Value,
                Duracion = int.TryParse(txtDuracion.Text, out int duracion) ? duracion : null,
                Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text,
                Estado = (EstadoTarea?)txtEstado.SelectedItem ?? EstadoTarea.Activo,
                FechaAlta = fechaAltaSeleccionada ?? DateTime.Now, // Nunca nulo
                PlanId = cmbPlan.SelectedValue != null ? (int)cmbPlan.SelectedValue : 0
            };
            return t;
        }

        
        private void dgvTarea_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTarea.CurrentRow != null && dgvTarea.CurrentRow.DataBoundItem is TareaDTO t)
            {
                txtID.Text = t.Id.ToString();
                txtNombre.Text = t.Nombre ?? "";
                txtFechaHora.Value = t.FechaHora ?? DateTime.Now;
                txtDuracion.Text = t.Duracion?.ToString() ?? "";
                txtDescripcion.Text = t.Descripcion ?? "";
                txtEstado.SelectedItem = t.Estado;
                fechaAltaSeleccionada = t.FechaAlta;

                
                if (cmbPlan.Items.Count > 0)
                {
                    cmbPlan.SelectedValue = t.PlanId;
                }

                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                
                if (confirmarEliminar)
                {
                    btnEliminar.Text = "ELIMINAR TAREA";
                    confirmarEliminar = false;
                }
            }
        }

        
        private async Task GetTareas()
        {
            try
            {
                var tareas = await TareaApiClient.GetAllAsync();
                dgvTarea.DataSource = null; 
                dgvTarea.AutoGenerateColumns = true;
                dgvTarea.DataSource = tareas.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tareas: " + ex.ToString());
            }
        }

        
        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (cmbPlan.SelectedValue == null || cmbPlan.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un plan", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtID.Text = "";
            fechaAltaSeleccionada = DateTime.Now; 
            TareaDTO t = LimpiarTarea();
            try
            {
                await TareaApiClient.AddAsync(t);
                await GetTareas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear tarea: " + ex.Message);
            }
        }

        
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (cmbPlan.SelectedValue == null || cmbPlan.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un plan", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TareaDTO t = LimpiarTarea();
            try
            {
                await TareaApiClient.UpdateAsync(t);
                await GetTareas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar tarea: " + ex.Message);
            }
        }

        
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!confirmarEliminar)
            {
                btnEliminar.Text = "¿ESTÁ SEGURO?";
                confirmarEliminar = true;
            }
            else
            {
                try
                {
                    if (dgvTarea.CurrentRow?.DataBoundItem is TareaDTO tarea)
                    {
                        await TareaApiClient.DeleteAsync(tarea.Id);
                        await GetTareas();
                        LimpiarFormulario();
                    }
                    btnEliminar.Text = "ELIMINAR TAREA";
                    confirmarEliminar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar tarea: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
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
            txtDuracion.Text = "";
            txtDescripcion.Text = "";
            txtFechaHora.Value = DateTime.Now;
            txtEstado.SelectedIndex = 0;
            cmbPlan.SelectedIndex = -1;
            fechaAltaSeleccionada = null;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            if (dgvTarea.CurrentRow != null)
            {
                dgvTarea.ClearSelection();
            }
        }
    }
}