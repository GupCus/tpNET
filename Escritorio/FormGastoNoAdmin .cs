using API.Clients;
using DTOs;
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

                // USAR EL API CLIENT REAL para obtener categorías
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
                var todasLasTareas = await TareaApiClient.GetAllAsync();
                tareasDelGrupo = todasLasTareas.ToList();

                cmbTarea.Items.Clear();
                cmbTarea.Items.Add("Sin tarea específica...");
                foreach (var tarea in tareasDelGrupo)
                {
                    cmbTarea.Items.Add(new { Text = tarea.Nombre, Value = tarea.Id });
                }
                cmbTarea.DisplayMember = "Text";
                cmbTarea.ValueMember = "Value";
                cmbTarea.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tareas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarGastos()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvGastos.Rows.Clear();

                var todosLosGastos = await GastoApiClient.GetAllAsync();
                gastosDelGrupo = todosLosGastos.ToList();

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

                // Calcular total
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

                // Obtener el ID de la categoría seleccionada
                var categoriaSeleccionada = cmbCategoria.SelectedItem as dynamic;
                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una categoría válida", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int categoriaId = categoriaSeleccionada.Value;

                // Obtener el ID de la tarea si se seleccionó una
                int? tareaId = null;
                if (cmbTarea.SelectedIndex > 0)
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
            cmbCategoria.SelectedIndex = 0;
            cmbTarea.SelectedIndex = 0;
            dtpFechaHora.Value = DateTime.Now;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarGastos();
        }

        private void BuscarGastos()
        {
            var textoBusqueda = txtBusqueda.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                dgvGastos.Rows.Clear();
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
            }
            else
            {
                dgvGastos.Rows.Clear();
                var gastosFiltrados = gastosDelGrupo.Where(g =>
                    g.Descripcion.ToLower().Contains(textoBusqueda) ||
                    g.CategoriaGastoNombre?.ToLower().Contains(textoBusqueda) == true ||
                    g.TareaNombre?.ToLower().Contains(textoBusqueda) == true ||
                    g.Monto.ToString().Contains(textoBusqueda)
                );

                foreach (var gasto in gastosFiltrados)
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
            }

            lblContador.Text = $"{dgvGastos.Rows.Count} gastos encontrados";

            // Recalcular total con los gastos filtrados
            var total = gastosDelGrupo.Where(g =>
                string.IsNullOrEmpty(textoBusqueda) ||
                g.Descripcion.ToLower().Contains(textoBusqueda) ||
                g.CategoriaGastoNombre?.ToLower().Contains(textoBusqueda) == true ||
                g.TareaNombre?.ToLower().Contains(textoBusqueda) == true ||
                g.Monto.ToString().Contains(textoBusqueda)
            ).Sum(g => g.Monto);

            lblTotal.Text = $"Total: {total:C2}";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarGastos();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal y tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
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
    }
}