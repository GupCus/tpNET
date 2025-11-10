using API.Clients;
using DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FormPlanNoAdmin : Form
    {
        private int grupoId;
        private List<PlanDTO> planesDelGrupo;
        private ContextMenuStrip menuContextual;
        private int? editingPlanId = null; // null = modo creación, tiene valor = modo edición

        public FormPlanNoAdmin(int grupoId)
        {
            InitializeComponent();
            this.grupoId = grupoId;
            this.Text = $"Gestión de Planes - Grupo ID: {grupoId}";
        }

        private async void FormPlanNoAdmin_Load(object sender, EventArgs e)
        {
            ConfigurarMenuContextual();
            // asegurarnos de que al click derecho se seleccione la fila
            dgvPlanes.CellMouseDown += dgvPlanes_CellMouseDown;

            await CargarPlanes();
        }

        private void ConfigurarMenuContextual()
        {
            menuContextual = new ContextMenuStrip();

            var itemEditar = new ToolStripMenuItem("✏️ Editar Plan");
            var itemCancelarEdicion = new ToolStripMenuItem("✖️ Cancelar edición");

            itemEditar.Click += (s, e) => EditarPlanDesdeMenuContextual();
            itemCancelarEdicion.Click += (s, e) => CancelarEdicion();

            menuContextual.Items.AddRange(new ToolStripItem[] { itemEditar, itemCancelarEdicion });

            dgvPlanes.ContextMenuStrip = menuContextual;
        }

        // Selecciona la fila bajo el cursor cuando se hace click derecho para que la acción del menú actúe sobre esa fila
        private void dgvPlanes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPlanes.ClearSelection();
                dgvPlanes.Rows[e.RowIndex].Selected = true;

                if (e.ColumnIndex >= 0)
                {
                    dgvPlanes.CurrentCell = dgvPlanes.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
                else
                {
                    dgvPlanes.CurrentCell = dgvPlanes.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>().FirstOrDefault() ?? dgvPlanes.Rows[e.RowIndex].Cells[0];
                }
            }
        }

        private async Task CargarPlanes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvPlanes.Rows.Clear();

                var planes = await PlanApiClient.GetByGrupoIdAsync(this.grupoId);
                planesDelGrupo = planes.ToList();

                foreach (var plan in planesDelGrupo)
                {
                    dgvPlanes.Rows.Add(
                        plan.Id,
                        plan.Nombre,
                        plan.Descripcion,
                        plan.FechaInicio.ToString("dd/MM/yyyy"),
                        plan.FechaFin.ToString("dd/MM/yyyy")
                    );
                }

                lblContador.Text = $"{dgvPlanes.Rows.Count} planes encontrados";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnNuevoPlan_Click(object sender, EventArgs e)
        {
            if (editingPlanId.HasValue)
            {
                _ = GuardarEdicionPlan();
            }
            else
            {
                CrearNuevoPlan();
            }
        }

        private async void CrearNuevoPlan()
        {
            try
            {
                var nombre = txtNombre.Text.Trim();
                var descripcion = txtDescripcion.Text.Trim();

                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre del plan es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validación: la fecha de inicio no puede ser mayor que la fecha de baja
                var fechaInicio = DateOnly.FromDateTime(dtpFechaInicio.Value.Date);
                var fechaBaja = DateOnly.FromDateTime(dtpFechaFin.Value.Date);

                if (fechaInicio > fechaBaja)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de baja.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpFechaInicio.Focus();
                    return;
                }

                var nuevoPlan = new PlanCreateDTO
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    FechaInicio = fechaInicio,
                    FechaBaja = fechaBaja,
                    FechaAlta = DateOnly.FromDateTime(DateTime.Now),
                    GrupoId = this.grupoId
                };

                await PlanApiClient.AddAsync(nuevoPlan);

                MessageBox.Show("Plan creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                await CargarPlanes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear plan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método llamado desde el menú contextual "Editar Plan"
        private void EditarPlanDesdeMenuContextual()
        {
            if (dgvPlanes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un plan primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID desde la celda oculta/visible (según diseño)
            if (!int.TryParse(dgvPlanes.CurrentRow.Cells[0].Value?.ToString(), out int planId))
            {
                MessageBox.Show("No se pudo obtener el ID del plan seleccionado", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var plan = planesDelGrupo.FirstOrDefault(p => p.Id == planId);
            if (plan == null)
            {
                MessageBox.Show("No se encontró el plan seleccionado en la lista cargada", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llenar el formulario con los datos del plan y pasar a modo edición
            editingPlanId = plan.Id;
            txtNombre.Text = plan.Nombre;
            txtDescripcion.Text = plan.Descripcion;

            // Intentar asignar las fechas (manejar DateOnly/DateTime)
            try
            {
                dtpFechaInicio.Value = plan.FechaInicio is DateOnly dInicio
                    ? dInicio.ToDateTime(TimeOnly.MinValue)
                    : DateTime.Parse(plan.FechaInicio.ToString());
            }
            catch
            {
                dtpFechaInicio.Value = DateTime.Today;
            }

            try
            {
                dtpFechaFin.Value = plan.FechaFin is DateOnly dFin
                    ? dFin.ToDateTime(TimeOnly.MinValue)
                    : DateTime.Parse(plan.FechaFin.ToString());
            }
            catch
            {
                dtpFechaFin.Value = DateTime.Today.AddMonths(1);
            }

            btnNuevoPlan.Text = "Guardar cambios";
        }

        private async Task GuardarEdicionPlan()
        {
            if (editingPlanId == null)
            {
                MessageBox.Show("No hay ningún plan en edición", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nombre = txtNombre.Text.Trim();
            var descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre del plan es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación fechas
            var fechaInicioDt = dtpFechaInicio.Value.Date;
            var fechaFinDt = dtpFechaFin.Value.Date;

            if (fechaInicioDt > fechaFinDt)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de baja.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaInicio.Focus();
                return;
            }

            try
            {
                var plUpdate = new PlanUpdateDTO
                {
                    Id = editingPlanId.Value,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    // El endpoint PUT /planes espera PlanUpdateDTO; usar DateTime para las fechas (coincide con uso en FormPlan)
                    FechaInicio = dtpFechaInicio.Value,
                    FechaFin = dtpFechaFin.Value,
                    GrupoId = this.grupoId
                };

                await PlanApiClient.UpdateAsync(plUpdate);

                MessageBox.Show("Plan actualizado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Resetear estado de edición
                editingPlanId = null;
                btnNuevoPlan.Text = "Crear Plan";
                LimpiarCampos();
                await CargarPlanes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar plan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddMonths(1);
            // Si estaba en modo edición, salir de él
            editingPlanId = null;
            btnNuevoPlan.Text = "Crear Plan";
        }

        private void CancelarEdicion()
        {
            if (editingPlanId.HasValue)
            {
                var result = MessageBox.Show("Cancelar la edición actual?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    LimpiarCampos();
                }
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarPlanes();
        }
    }
}