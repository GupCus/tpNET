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

        public FormGastoNoAdmin(int grupoId)
        {
            InitializeComponent();
            this.grupoId = grupoId;
            this.Text = $"Gestión de Gastos - Grupo ID: {grupoId}";
        }

        private async void FormGastoNoAdmin_Load(object sender, EventArgs e)
        {
            await CargarCategorias();
            await CargarTareas();
            await CargarGastos();
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
                        gasto.UsuarioNombre ?? "Sin usuario"
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
            CrearNuevoGasto();
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

        private void LimpiarCampos()
        {
            txtDescripcion.Clear();
            txtMonto.Clear();
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            if (cmbTarea.Items.Count > 0) cmbTarea.SelectedIndex = 0;
            dtpFechaHora.Value = DateTime.Now;
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