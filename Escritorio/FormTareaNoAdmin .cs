using API.Clients;
using Dominio;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FormTareaNoAdmin : Form
    {
        private int grupoId;
        private List<PlanDTO> planesDelGrupo;
        private List<TareaDTO> tareasDelGrupo;

        public FormTareaNoAdmin(int grupoId)
        {
            InitializeComponent();
            this.grupoId = grupoId;
            this.Text = $"Gestión de Tareas - Grupo ID: {grupoId}";

            btnNuevaTarea.Enabled = false;
        }

        private async void FormTareaNoAdmin_Load(object sender, EventArgs e)
        {
            await CargarPlanes();
            await CargarTareas();
        }

        private async Task CargarPlanes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var planes = await PlanApiClient.GetByGrupoIdAsync(this.grupoId);
                planesDelGrupo = planes?.ToList() ?? new List<PlanDTO>();

                cmbPlan.Items.Clear();

                if (!planesDelGrupo.Any())
                {
                    
                    cmbPlan.Items.Add("No hay planes en el grupo");
                    cmbPlan.SelectedIndex = 0;
                    cmbPlan.Enabled = false;

                    btnNuevaTarea.Enabled = false;
                }
                else
                {
                    cmbPlan.Items.Add("Seleccionar plan...");
                    foreach (var plan in planesDelGrupo)
                    {
                        cmbPlan.Items.Add(new { Text = plan.Nombre, Value = plan.Id });
                    }
                    cmbPlan.DisplayMember = "Text";
                    cmbPlan.ValueMember = "Value";
                    cmbPlan.SelectedIndex = 0;
                    cmbPlan.Enabled = true;

                    
                    btnNuevaTarea.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                
                cmbPlan.Items.Clear();
                cmbPlan.Items.Add("Error al cargar planes");
                cmbPlan.SelectedIndex = 0;
                cmbPlan.Enabled = false;
                btnNuevaTarea.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task CargarTareas()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvTareas.Rows.Clear();

                
                var tareas = await TareaApiClient.GetByGrupoIdAsync(this.grupoId);
                tareasDelGrupo = tareas?.ToList() ?? new List<TareaDTO>();

                foreach (var tarea in tareasDelGrupo)
                {
                    dgvTareas.Rows.Add(
                        tarea.Id,
                        tarea.Nombre,
                        tarea.Descripcion,
                        tarea.FechaHora?.ToString("dd/MM/yyyy HH:mm") ?? "No definida",
                        tarea.Duracion?.ToString() ?? "N/A",
                        tarea.Estado.ToString(),
                        tarea.PlanId
                    );
                }

                lblContador.Text = $"{dgvTareas.Rows.Count} tareas encontradas";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tareas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnNuevaTarea_Click(object sender, EventArgs e)
        {
            CrearNuevaTarea();
        }

        private async void CrearNuevaTarea()
        {
            try
            {
                if (!btnNuevaTarea.Enabled)
                {
                    
                    MessageBox.Show("No hay planes disponibles para asignar la tarea.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbPlan.SelectedIndex <= 0)
                {
                    MessageBox.Show("Seleccione un plan primero", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nombre = txtNombre.Text.Trim();
                var descripcion = txtDescripcion.Text.Trim();

                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre de la tarea es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                var planSeleccionado = cmbPlan.SelectedItem as dynamic;
                int planId = planSeleccionado?.Value ?? 0;

                if (planId == 0)
                {
                    MessageBox.Show("Plan no válido seleccionado", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                var estadoSeleccionado = cmbEstado.SelectedItem as dynamic;
                var estadoValue = estadoSeleccionado?.Value;
                EstadoTarea estado = EstadoTarea.Activo;
                if (estadoValue != null)
                    estado = (EstadoTarea)Convert.ToInt32(estadoValue);

                var nuevaTarea = new TareaDTO
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    FechaHora = dtpFechaHora.Value,
                    Duracion = string.IsNullOrEmpty(txtDuracion.Text) ? null : int.Parse(txtDuracion.Text),
                    Estado = estado,
                    FechaAlta = DateTime.Now,
                    PlanId = planId
                };

                await TareaApiClient.AddAsync(nuevaTarea);

                MessageBox.Show("Tarea creada exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                await CargarTareas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear tarea: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtDuracion.Clear();
            dtpFechaHora.Value = DateTime.Now;

            
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;
            if (cmbPlan.Enabled && cmbPlan.Items.Count > 0) cmbPlan.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarTareas();
        }

        private void BuscarTareas()
        {
            var textoBusqueda = txtBusqueda.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                dgvTareas.Rows.Clear();
                foreach (var tarea in tareasDelGrupo)
                {
                    dgvTareas.Rows.Add(
                        tarea.Id,
                        tarea.Nombre,
                        tarea.Descripcion,
                        tarea.FechaHora?.ToString("dd/MM/yyyy HH:mm") ?? "No definida",
                        tarea.Duracion?.ToString() ?? "N/A",
                        tarea.Estado.ToString(),
                        tarea.PlanId
                    );
                }
            }
            else
            {
                dgvTareas.Rows.Clear();
                var tareasFiltradas = tareasDelGrupo.Where(t =>
                    (t.Nombre ?? string.Empty).ToLower().Contains(textoBusqueda) ||
                    (t.Descripcion ?? string.Empty).ToLower().Contains(textoBusqueda) ||
                    t.Estado.ToString().ToLower().Contains(textoBusqueda)
                );

                foreach (var tarea in tareasFiltradas)
                {
                    dgvTareas.Rows.Add(
                        tarea.Id,
                        tarea.Nombre,
                        tarea.Descripcion,
                        tarea.FechaHora?.ToString("dd/MM/yyyy HH:mm") ?? "No definida",
                        tarea.Duracion?.ToString() ?? "N/A",
                        tarea.Estado.ToString(),
                        tarea.PlanId
                    );
                }
            }

            lblContador.Text = $"{dgvTareas.Rows.Count} tareas encontradas";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarTareas();
        }

        private void dgvTareas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var tareaId = Convert.ToInt32(dgvTareas.Rows[e.RowIndex].Cells["colId"].Value);
                var tareaNombre = dgvTareas.Rows[e.RowIndex].Cells["colNombre"].Value.ToString();
                var planId = dgvTareas.Rows[e.RowIndex].Cells["colPlanId"].Value;

                MessageBox.Show($"Tarea seleccionada: {tareaNombre}\nID: {tareaId}\nPlan ID: {planId}",
                    "Tarea Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}