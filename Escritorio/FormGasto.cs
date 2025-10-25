using Dominio;
using DTOs;
using API.Clients;


namespace Escritorio
{
    public partial class FormGasto : Form
    {
        private bool confirmarEliminar = false;
        private DateTime? fechaAltaSeleccionada = null;

        public FormGasto()
        {
            InitializeComponent();
        }

        private async void FormGasto_Load(object sender, EventArgs e)
        {
            await GetCategorias();
            await GetUsuarios();
            await GetTareas();
            await GetGastos();
        }

        private async Task GetCategorias()
        {
            try
            {
                var categorias = await CategoriaGastoApiClient.GetAllAsync();
                cmbCategoria.DataSource = categorias?.ToList();
                cmbCategoria.DisplayMember = "Tipo";
                cmbCategoria.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GetUsuarios()
        {
            try
            {
                var usuarios = await UsuarioApiClient.GetAllAsync();
                cmbUsuario.DataSource = usuarios?.ToList();
                cmbUsuario.DisplayMember = "NombreUsuario";
                cmbUsuario.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GetTareas()
        {
            try
            {
                var tareas = await TareaApiClient.GetAllAsync();
                comTarea.DataSource = tareas?.ToList();
                comTarea.DisplayMember = "Nombre";
                comTarea.ValueMember = "Id";
                comTarea.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tareas: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private GastoDTO LimpiarGasto()
        {
            if (cmbCategoria.SelectedValue == null)
                throw new InvalidOperationException("Debe seleccionar una Categoría.");
            if (cmbUsuario.SelectedValue == null)
                throw new InvalidOperationException("Debe seleccionar un Usuario.");
            if (!float.TryParse(txtMonto.Text, out float monto))
                throw new InvalidOperationException("El Monto no es un número válido.");

            int? tareaId = comTarea.SelectedValue as int?;
            if (comTarea.SelectedValue != null && int.TryParse(comTarea.SelectedValue.ToString(), out int tid))
                tareaId = tid;
            else
                tareaId = null;

            GastoDTO g = new()
            {
                Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text,
                FechaHora = txtFechaHora.Value,
                Monto = monto,
                CategoriaGastoId = (int)cmbCategoria.SelectedValue,
                UsuarioId = (int)cmbUsuario.SelectedValue,
                TareaId = tareaId,
                FechaAlta = fechaAltaSeleccionada ?? DateTime.Now 
            };

            if (!string.IsNullOrEmpty(txtID.Text) && int.TryParse(txtID.Text, out int id))
                g.Id = id;

            return g;
        }

        private void dgvGasto_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGasto.CurrentRow != null && dgvGasto.CurrentRow.DataBoundItem is GastoDTO g)
            {
                txtID.Text = g.Id.ToString();
                txtDescripcion.Text = g.Descripcion ?? "";
                txtFechaHora.Value = g.FechaHora;
                txtMonto.Text = g.Monto.ToString();
                if (cmbCategoria.DataSource != null)
                    cmbCategoria.SelectedValue = g.CategoriaGastoId;
                if (cmbUsuario.DataSource != null)
                    cmbUsuario.SelectedValue = g.UsuarioId;
                if (comTarea.DataSource != null)
                    comTarea.SelectedValue = g.TareaId ?? -1;
                fechaAltaSeleccionada = g.FechaAlta;

                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                if (confirmarEliminar)
                {
                    btnEliminar.Text = "Eliminar Gasto";
                    confirmarEliminar = false;
                }
            }
        }

        private async Task GetGastos()
        {
            try
            {
                var gastos = await GastoApiClient.GetAllAsync();
                dgvGasto.DataSource = null;
                dgvGasto.AutoGenerateColumns = true;
                this.dgvGasto.DataSource = gastos?.ToList();
                txtID.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los gastos: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            fechaAltaSeleccionada = DateTime.Now; // Nueva fecha para alta
            try
            {
                GastoDTO g = this.LimpiarGasto();
                await GastoApiClient.AddAsync(g);
                await this.GetGastos();
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el nuevo gasto: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGasto.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un gasto para modificar.", "Advertencia");
                return;
            }

            try
            {
                GastoDTO g = this.LimpiarGasto();
                g.Id = ((GastoDTO)dgvGasto.CurrentRow.DataBoundItem).Id;
                await GastoApiClient.UpdateAsync(g);
                await this.GetGastos();
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el gasto: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGasto.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un gasto para eliminar.", "Advertencia");
                return;
            }

            if (!confirmarEliminar)
            {
                btnEliminar.Text = "¿ESTÁ SEGURO?";
                confirmarEliminar = true;
            }
            else
            {
                try
                {
                    int idSeleccionado = ((GastoDTO)dgvGasto.CurrentRow.DataBoundItem).Id;
                    await GastoApiClient.DeleteAsync(idSeleccionado);
                    await this.GetGastos();
                    btnEliminar.Text = "Eliminar Gasto";
                    confirmarEliminar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el gasto: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comTarea_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}