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

        private ContextMenuStrip menuContextual;
        private int? editingTareaId = null; 

        public FormTareaNoAdmin(int grupoId)
        {
            InitializeComponent();
            this.grupoId = grupoId;
            this.Text = $"Gestión de Tareas - Grupo ID: {grupoId}";

            btnNuevaTarea.Enabled = false;
        }

        private async void FormTareaNoAdmin_Load(object sender, EventArgs e)
        {
            //Para evitar problemas en el diseñador despues
            var estados = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>((int)EstadoTarea.Activo, "Activo"),
                new KeyValuePair<int, string>((int)EstadoTarea.Pendiente, "Pendiente")
            };
            cmbEstado.DisplayMember = "Value";
            cmbEstado.ValueMember = "Key";
            cmbEstado.Items.Clear();
            foreach (var kv in estados) cmbEstado.Items.Add(kv);
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;

            ConfigurarMenuContextual();
            dgvTareas.CellMouseDown += dgvTareas_CellMouseDown;

            await CargarPlanes();
            await CargarTareas();
        }

        private void ConfigurarMenuContextual()
        {
            menuContextual = new ContextMenuStrip();

            var itemEditar = new ToolStripMenuItem("✏️ Editar Tarea");
            var itemCancelar = new ToolStripMenuItem("✖️ Cancelar edición");

            itemEditar.Click += (s, e) => EditarTareaDesdeMenuContextual();
            itemCancelar.Click += (s, e) => CancelarEdicion();

            menuContextual.Items.AddRange(new ToolStripItem[] { itemEditar, itemCancelar });

            dgvTareas.ContextMenuStrip = menuContextual;
        }

        private void dgvTareas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvTareas.ClearSelection();
                dgvTareas.Rows[e.RowIndex].Selected = true;

                if (e.ColumnIndex >= 0)
                {
                    dgvTareas.CurrentCell = dgvTareas.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
                else
                {
                    dgvTareas.CurrentCell = dgvTareas.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>().FirstOrDefault() ?? dgvTareas.Rows[e.RowIndex].Cells[0];
                }
            }
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
            if (editingTareaId.HasValue)
            {
                _ = GuardarEdicionTarea();
            }
            else
            {
                CrearNuevaTarea();
            }
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

                EstadoTarea estado = EstadoTarea.Activo;
                if (cmbEstado.SelectedItem is KeyValuePair<int, string> kvp)
                {
                    estado = (EstadoTarea)kvp.Key;
                }

                var plan = planesDelGrupo.FirstOrDefault(p => p.Id == planId);
                if (plan != null)
                {
                    DateTime planInicio, planFin;
                    try
                    {
                        planInicio = plan.FechaInicio is DateOnly di ? di.ToDateTime(TimeOnly.MinValue) : DateTime.Parse(plan.FechaInicio.ToString());
                        planFin = plan.FechaFin is DateOnly df ? df.ToDateTime(TimeOnly.MinValue) : DateTime.Parse(plan.FechaFin.ToString());
                        if (dtpFechaHora.Value.Date < planInicio.Date || dtpFechaHora.Value.Date > planFin.Date)
                        {
                            MessageBox.Show("La fecha/hora de la tarea debe estar dentro del rango del plan seleccionado.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch
                    {
                       
                    }
                }

                int? duracion = null;
                if (!string.IsNullOrWhiteSpace(txtDuracion.Text))
                {
                    if (int.TryParse(txtDuracion.Text.Trim(), out int d))
                        duracion = d;
                    else
                    {
                        MessageBox.Show("Duración inválida. Ingrese un número entero.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var nuevaTarea = new TareaDTO
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    FechaHora = dtpFechaHora.Value,
                    Duracion = duracion,
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

        private void EditarTareaDesdeMenuContextual()
        {
            if (dgvTareas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una tarea primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(dgvTareas.CurrentRow.Cells[0].Value?.ToString(), out int tareaId))
            {
                MessageBox.Show("No se pudo obtener el ID de la tarea seleccionada", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tarea = tareasDelGrupo.FirstOrDefault(t => t.Id == tareaId);
            if (tarea == null)
            {
                MessageBox.Show("No se encontró la tarea seleccionada en la lista cargada", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            editingTareaId = tarea.Id;
            txtNombre.Text = tarea.Nombre;
            txtDescripcion.Text = tarea.Descripcion;
            txtDuracion.Text = tarea.Duracion?.ToString() ?? "";

            dtpFechaHora.Value = tarea.FechaHora ?? DateTime.Now;


            int estadoIndex = -1;
            for (int i = 0; i < cmbEstado.Items.Count; i++)
            {
                if (cmbEstado.Items[i] is KeyValuePair<int, string> kv && kv.Key == (int)tarea.Estado)
                {
                    estadoIndex = i;
                    break;
                }
            }
            if (estadoIndex >= 0) cmbEstado.SelectedIndex = estadoIndex;

            int planIndex = -1;
            for (int i = 0; i < cmbPlan.Items.Count; i++)
            {
                var item = cmbPlan.Items[i];
                if (item is not string && item.GetType().GetProperty("Value") != null)
                {
                    var val = (int)item.GetType().GetProperty("Value").GetValue(item);
                    if (val == tarea.PlanId)
                    {
                        planIndex = i;
                        break;
                    }
                }
            }
            if (planIndex >= 0) cmbPlan.SelectedIndex = planIndex;

            btnNuevaTarea.Text = "Guardar cambios";
        }

        private async Task GuardarEdicionTarea()
        {
            if (editingTareaId == null)
            {
                MessageBox.Show("No hay ninguna tarea en edición", "Advertencia",
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

            var planSeleccionado = cmbPlan.SelectedItem as dynamic;
            int planId = planSeleccionado?.Value ?? 0;

            if (planId == 0)
            {
                MessageBox.Show("Plan no válido seleccionado", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Estado
            EstadoTarea estado = EstadoTarea.Activo;
            if (cmbEstado.SelectedItem is KeyValuePair<int, string> kvp)
            {
                estado = (EstadoTarea)kvp.Key;
            }

            var plan = planesDelGrupo.FirstOrDefault(p => p.Id == planId);
            if (plan != null)
            {
                try
                {
                    DateTime planInicio = plan.FechaInicio is DateOnly di ? di.ToDateTime(TimeOnly.MinValue) : DateTime.Parse(plan.FechaInicio.ToString());
                    DateTime planFin = plan.FechaFin is DateOnly df ? df.ToDateTime(TimeOnly.MinValue) : DateTime.Parse(plan.FechaFin.ToString());
                    if (dtpFechaHora.Value.Date < planInicio.Date || dtpFechaHora.Value.Date > planFin.Date)
                    {
                        MessageBox.Show("La fecha/hora de la tarea debe estar dentro del rango del plan seleccionado.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch
                {
                   
                }
            }

            int? duracion = null;
            if (!string.IsNullOrWhiteSpace(txtDuracion.Text))
            {
                if (int.TryParse(txtDuracion.Text.Trim(), out int d))
                    duracion = d;
                else
                {
                    MessageBox.Show("Duración inválida. Ingrese un número entero.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
               
                var original = tareasDelGrupo.FirstOrDefault(t => t.Id == editingTareaId.Value);
                DateTime fechaAlta = original?.FechaAlta ?? DateTime.Now;

                var tareaUpdate = new TareaDTO
                {
                    Id = editingTareaId.Value,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    FechaHora = dtpFechaHora.Value,
                    Duracion = duracion,
                    Estado = estado,
                    PlanId = planId,
                    FechaAlta = fechaAlta 
                };

                await TareaApiClient.UpdateAsync(tareaUpdate); 

                MessageBox.Show("Tarea actualizada correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                editingTareaId = null;
                btnNuevaTarea.Text = "Crear Tarea";
                LimpiarCampos();
                await CargarTareas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar tarea: {ex.Message}", "Error",
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
            editingTareaId = null;
            btnNuevaTarea.Text = "Crear Tarea";
        }

        private void CancelarEdicion()
        {
            if (editingTareaId.HasValue)
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarTareas();
        }
    }
}