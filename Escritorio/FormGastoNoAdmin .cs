using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FormGastoNoAdmin : Form
    {
        private int grupoId;
        private List<CategoriaGastoDTO> categorias;
        private List<TareaDTO> tareasDelGrupo;
        private List<GastoDTO> gastosDelGrupo;

        private ContextMenuStrip menuContextual;
        private int? editingGastoId = null;

        public FormGastoNoAdmin(int grupoId)
        {
            InitializeComponent();
            this.grupoId = grupoId;
            this.Text = $"Gestión de Gastos - Grupo ID: {grupoId}";
        }

        private async void FormGastoNoAdmin_Load(object sender, EventArgs e)
        {
            ConfigurarMenuContextual();
            dgvGastos.CellMouseDown += dgvGastos_CellMouseDown;

            await CargarCategorias();
            await CargarTareas();
            await CargarGastos();
        }

        private void ConfigurarMenuContextual()
        {
            menuContextual = new ContextMenuStrip();

            var itemEditar = new ToolStripMenuItem("✏️ Editar Gasto");
            var itemCancelar = new ToolStripMenuItem("✖️ Cancelar edición");

            itemEditar.Click += (s, e) => EditarGastoDesdeMenuContextual();
            itemCancelar.Click += (s, e) => CancelarEdicion();

            menuContextual.Items.AddRange(new ToolStripItem[] { itemEditar, itemCancelar });

            dgvGastos.ContextMenuStrip = menuContextual;
        }

        // Selecciona la fila bajo el cursor cuando se hace click derecho para que la acción del menú actúe sobre esa fila
        private void dgvGastos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvGastos.ClearSelection();
                dgvGastos.Rows[e.RowIndex].Selected = true;

                if (e.ColumnIndex >= 0)
                {
                    dgvGastos.CurrentCell = dgvGastos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
                else
                {
                    dgvGastos.CurrentCell = dgvGastos.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>().FirstOrDefault() ?? dgvGastos.Rows[e.RowIndex].Cells[0];
                }
            }
        }

        private async Task CargarCategorias()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                categorias = (await CategoriaGastoApiClient.GetAllAsync()).ToList();

                cmbCategoria.Items.Clear();
                cmbCategoria.Items.Add("Seleccionar categoría...");
                foreach (var categoria in categorias)
                {
                    cmbCategoria.Items.Add(new { Text = categoria.Tipo, Value = categoria.Id });
                }
                cmbCategoria.DisplayMember = "Text";
                cmbCategoria.ValueMember = "Value";
                cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var tareas = await TareaApiClient.GetByGrupoIdAsync(this.grupoId);
                tareasDelGrupo = tareas?.ToList() ?? new List<TareaDTO>();

                cmbTarea.Items.Clear();

                if (!tareasDelGrupo.Any())
                {
                    cmbTarea.Items.Add("No hay tareas en el grupo");
                    cmbTarea.SelectedIndex = 0;
                    cmbTarea.Enabled = false;
                    btnNuevoGasto.Enabled = false;
                }
                else
                {
                    cmbTarea.Items.Add("Sin tarea específica...");
                    foreach (var tarea in tareasDelGrupo)
                    {
                        cmbTarea.Items.Add(new { Text = tarea.Nombre ?? $"Tarea {tarea.Id}", Value = tarea.Id });
                    }

                    cmbTarea.DisplayMember = "Text";
                    cmbTarea.ValueMember = "Value";
                    cmbTarea.SelectedIndex = 0;
                    cmbTarea.Enabled = true;
                    btnNuevoGasto.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tareas del grupo {grupoId}: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                cmbTarea.Items.Clear();
                cmbTarea.Items.Add("Error al cargar tareas");
                cmbTarea.SelectedIndex = 0;
                cmbTarea.Enabled = false;
                btnNuevoGasto.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task CargarGastos()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvGastos.Rows.Clear();

                var gastos = await GastoApiClient.GetByGrupoIdAsync(this.grupoId);
                gastosDelGrupo = gastos?.ToList() ?? new List<GastoDTO>();

                foreach (var gasto in gastosDelGrupo)
                {
                    dgvGastos.Rows.Add(
                        gasto.Id,
                        gasto.Descripcion,
                        gasto.Monto.ToString("C2"),
                        gasto.CategoriaGastoNombre ?? "Sin categoría",
                        gasto.TareaNombre ?? "Sin tarea",
                        gasto.FechaHora.ToString("dd/MM/yyyy HH:mm"),
                        gasto.UsuarioNombre ?? "Sin usuario",
                        gasto.UsuarioMail,
                        gasto.TareaId
                    );
                }

                lblContador.Text = $"{dgvGastos.Rows.Count} gastos encontrados";

                var total = gastosDelGrupo.Sum(g => g.Monto);
                lblTotal.Text = $"Total: {total:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gastos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnNuevoGasto_Click(object sender, EventArgs e)
        {
            if (editingGastoId.HasValue)
            {
                _ = GuardarEdicionGasto();
            }
            else
            {
                CrearNuevoGasto();
            }
        }

        private async void CrearNuevoGasto()
        {
            try
            {
                if (cmbCategoria.SelectedIndex <= 0)
                {
                    MessageBox.Show("Seleccione una categoría", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var descripcion = txtDescripcion.Text.Trim();
                var montoText = txtMonto.Text.Trim();

                if (string.IsNullOrEmpty(descripcion))
                {
                    MessageBox.Show("La descripción del gasto es obligatoria", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(montoText) || !float.TryParse(montoText, out float monto) || monto <= 0)
                {
                    MessageBox.Show("El monto debe ser un número válido mayor a 0", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var categoriaSeleccionada = cmbCategoria.SelectedItem as dynamic;
                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una categoría válida", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int categoriaId = categoriaSeleccionada.Value;

                int? tareaId = null;
                if (cmbTarea.Enabled && cmbTarea.SelectedIndex > 0)
                {
                    var tareaSeleccionada = cmbTarea.SelectedItem as dynamic;
                    tareaId = tareaSeleccionada?.Value;
                }

                var nuevoGasto = new GastoDTO
                {
                    Descripcion = descripcion,
                    Monto = monto,
                    CategoriaGastoId = categoriaId,
                    TareaId = tareaId,
                    UsuarioId = Sesion.UsuarioActual.Id,
                    FechaHora = dtpFechaHora.Value,
                    FechaAlta = DateTime.Now
                };

                await GastoApiClient.AddAsync(nuevoGasto);

                MessageBox.Show("Gasto registrado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                await CargarGastos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar gasto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método llamado desde el menú contextual "Editar Gasto"
        private void EditarGastoDesdeMenuContextual()
        {
            if (dgvGastos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un gasto primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener ID (columna 0 según carga en CargarGastos)
            if (!int.TryParse(dgvGastos.CurrentRow.Cells[0].Value?.ToString(), out int gastoId))
            {
                MessageBox.Show("No se pudo obtener el ID del gasto seleccionado", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var gasto = gastosDelGrupo.FirstOrDefault(g => g.Id == gastoId);
            if (gasto == null)
            {
                MessageBox.Show("No se encontró el gasto seleccionado en la lista cargada", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llenar controles con datos del gasto y pasar a modo edición
            editingGastoId = gasto.Id;
            txtDescripcion.Text = gasto.Descripcion;
            txtMonto.Text = gasto.Monto.ToString();

            // Categoría: buscar índice del item cuyo Value == gasto.CategoriaGastoId
            int catIndex = -1;
            for (int i = 0; i < cmbCategoria.Items.Count; i++)
            {
                var item = cmbCategoria.Items[i];
                if (item is not string && item.GetType().GetProperty("Value") != null)
                {
                    var val = (int)item.GetType().GetProperty("Value").GetValue(item);
                    if (val == gasto.CategoriaGastoId)
                    {
                        catIndex = i;
                        break;
                    }
                }
            }
            if (catIndex >= 0) cmbCategoria.SelectedIndex = catIndex;

            // Tarea: si tiene tarea asociada, seleccionar el item correspondiente
            int tareaIndex = -1;
            if (gasto.TareaId.HasValue)
            {
                for (int i = 0; i < cmbTarea.Items.Count; i++)
                {
                    var item = cmbTarea.Items[i];
                    if (item is not string && item.GetType().GetProperty("Value") != null)
                    {
                        var val = (int)item.GetType().GetProperty("Value").GetValue(item);
                        if (val == gasto.TareaId.Value)
                        {
                            tareaIndex = i;
                            break;
                        }
                    }
                }
            }
            if (tareaIndex >= 0) cmbTarea.SelectedIndex = tareaIndex;
            else if (cmbTarea.Items.Count > 0) cmbTarea.SelectedIndex = 0;

            // FechaHora
            dtpFechaHora.Value = gasto.FechaHora != default ? gasto.FechaHora : DateTime.Now;

            btnNuevoGasto.Text = "Guardar cambios";
        }

        private async Task GuardarEdicionGasto()
        {
            if (editingGastoId == null)
            {
                MessageBox.Show("No hay ningún gasto en edición", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategoria.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione una categoría", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var descripcion = txtDescripcion.Text.Trim();
            var montoText = txtMonto.Text.Trim();

            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("La descripción del gasto es obligatoria", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(montoText) || !float.TryParse(montoText, out float monto) || monto <= 0)
            {
                MessageBox.Show("El monto debe ser un número válido mayor a 0", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categoriaSeleccionada = cmbCategoria.SelectedItem as dynamic;
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría válida", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int categoriaId = categoriaSeleccionada.Value;

            int? tareaId = null;
            if (cmbTarea.Enabled && cmbTarea.SelectedIndex > 0)
            {
                var tareaSeleccionada = cmbTarea.SelectedItem as dynamic;
                tareaId = tareaSeleccionada?.Value;
            }

            try
            {
                // Obtener la fecha de alta original para evitar enviar null
                var original = gastosDelGrupo.FirstOrDefault(g => g.Id == editingGastoId.Value);
                DateTime fechaAlta = original?.FechaAlta ?? DateTime.Now;
                int usuarioId = original?.UsuarioId ?? Sesion.UsuarioActual.Id;

                var gastoUpdate = new GastoDTO
                {
                    Id = editingGastoId.Value,
                    Descripcion = descripcion,
                    Monto = monto,
                    CategoriaGastoId = categoriaId,
                    TareaId = tareaId,
                    UsuarioId = usuarioId,
                    FechaHora = dtpFechaHora.Value,
                    FechaAlta = fechaAlta
                };

                await GastoApiClient.UpdateAsync(gastoUpdate); // debe llamar al PUT /gastos

                MessageBox.Show("Gasto actualizado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Resetear estado de edición
                editingGastoId = null;
                btnNuevoGasto.Text = "Registrar Gasto";
                LimpiarCampos();
                await CargarGastos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar gasto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Clear();
            txtMonto.Clear();
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            if (cmbTarea.Items.Count > 0) cmbTarea.SelectedIndex = 0;
            dtpFechaHora.Value = DateTime.Now;

            // Salir de modo edición si corresponde
            editingGastoId = null;
            btnNuevoGasto.Text = "Registrar Gasto";
        }

        private void CancelarEdicion()
        {
            if (editingGastoId.HasValue)
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
            _ = CargarGastos();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void dgvGastos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var gastoId = Convert.ToInt32(dgvGastos.Rows[e.RowIndex].Cells["colId"].Value);
                var gastoDescripcion = dgvGastos.Rows[e.RowIndex].Cells["colDescripcion"].Value.ToString();
                var gastoMonto = dgvGastos.Rows[e.RowIndex].Cells["colMonto"].Value.ToString();

                MessageBox.Show($"Gasto seleccionado:\n\nDescripción: {gastoDescripcion}\nMonto: {gastoMonto}\nID: {gastoId}",
                    "Detalles del Gasto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbTarea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}