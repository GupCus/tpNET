using API.Clients;
using Dominio;
using DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                // Obtener planes del grupo (por ahora todos los planes)
                var todosLosPlanes = await PlanApiClient.GetAllAsync();
                planesDelGrupo = todosLosPlanes.ToList();

                cmbPlan.Items.Clear();
                cmbPlan.Items.Add("Seleccionar plan...");
                foreach (var plan in planesDelGrupo)
                {
                    cmbPlan.Items.Add(new { Text = plan.Nombre, Value = plan.Id });
                }
                cmbPlan.DisplayMember = "Text";
                cmbPlan.ValueMember = "Value";
                cmbPlan.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarTareas()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvTareas.Rows.Clear();

                var todasLasTareas = await TareaApiClient.GetAllAsync();
                tareasDelGrupo = todasLasTareas.ToList(); // Por ahora mostramos todas

                foreach (var tarea in tareasDelGrupo)
                {
                    dgvTareas.Rows.Add(
                        tarea.Id,
                        tarea.Nombre,
                        tarea.Descripcion,
                        tarea.FechaHora?.ToString("dd/MM/yyyy HH:mm") ?? "No definida",
                        tarea.Duracion?.ToString() ?? "N/A",
                        tarea.Estado.ToString(),
                        tarea.Gastos?.Count ?? 0,
                        tarea.PlanId // ✅ AGREGAR PlanId A LA GRILLA
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

        private void CrearNuevaTarea()
        {
            try
            {
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

                // ✅ OBTENER EL PlanId DEL COMBOBOX SELECCIONADO
                var planSeleccionado = cmbPlan.SelectedItem as dynamic;
                int planId = planSeleccionado?.Value ?? 0;

                if (planId == 0)
                {
                    MessageBox.Show("Plan no válido seleccionado", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevaTarea = new TareaDTO
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    FechaHora = dtpFechaHora.Value,
                    Duracion = string.IsNullOrEmpty(txtDuracion.Text) ? null : int.Parse(txtDuracion.Text),
                    Estado = (EstadoTarea)cmbEstado.SelectedIndex,
                    FechaAlta = DateTime.Now,
                    PlanId = planId // ✅ ASIGNAR EL PlanId CORRECTAMENTE
                };

                _ = TareaApiClient.AddAsync(nuevaTarea);

                MessageBox.Show("Tarea creada exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                _ = CargarTareas();
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
            cmbEstado.SelectedIndex = 0;
            cmbPlan.SelectedIndex = 0; // ✅ LIMPIAR TAMBIÉN LA SELECCIÓN DEL PLAN
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
                        tarea.Gastos?.Count ?? 0,
                        tarea.PlanId // ✅ AGREGAR PlanId A LA GRILLA
                    );
                }
            }
            else
            {
                dgvTareas.Rows.Clear();
                var tareasFiltradas = tareasDelGrupo.Where(t =>
                    t.Nombre.ToLower().Contains(textoBusqueda) ||
                    t.Descripcion.ToLower().Contains(textoBusqueda) ||
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
                        tarea.Gastos?.Count ?? 0,
                        tarea.PlanId // ✅ AGREGAR PlanId A LA GRILLA
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
                var planId = dgvTareas.Rows[e.RowIndex].Cells["colPlanId"].Value; // ✅ OBTENER PlanId

                // Aquí podrías abrir un form de edición o detalles
                MessageBox.Show($"Tarea seleccionada: {tareaNombre}\nID: {tareaId}\nPlan ID: {planId}",
                    "Tarea Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}