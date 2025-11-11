using API.Clients;
using DTOs;
using System.Diagnostics;

namespace Escritorio
{
    public partial class FormGrupo : Form
    {
        private bool confirma = false;
        public FormGrupo()
        {
            InitializeComponent();
        }
        private async Task CargarGrupos()
        {
            try
            {
                var grupos = await GrupoApiClient.GetAllAsync();
                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = grupos;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"Error: {ex.Message}", "Error al cargar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void FormGrupo_Load_1(object sender, EventArgs e)
        {
            await CargarGrupos();
        }

        private GrupoDTO LimpiarGrupo()
        {
            bool nuevo = string.IsNullOrEmpty(txtID.Text);
            GrupoDTO g = new GrupoDTO();
            g.Nombre = txtNombre.Text;
            g.Descripcion = txtDescripcion.Text;
            if (nuevo)
            {
                g.FechaAlta = DateTime.Now;
                g.IdUsuarioAdministrador = Sesion.UsuarioActual?.Id ?? 0; 
            }
            else
            {
                g.Id = int.Parse(txtID.Text);
            }
            return g;

        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            GrupoDTO grupo = LimpiarGrupo();

            Debug.WriteLine($"ID USUARIO ACTUAL: {Sesion.UsuarioActual?.Id}");

            await GrupoApiClient.AddAsync(grupo);
            await CargarGrupos();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            GrupoDTO grupo = LimpiarGrupo();
            await GrupoApiClient.UpdateAsync(grupo);
            await CargarGrupos();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!confirma)
            {
                btnEliminar.Text = "¿ESTÁ SEGURO?";
                confirma = true;
                return;
            }

            if (dataGridView1.CurrentRow == null || !(dataGridView1.CurrentRow.DataBoundItem is GrupoDTO gDto))
            {
                MessageBox.Show("Seleccione un grupo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                confirma = false;
                btnEliminar.Text = "ELIMINAR GRUPO";
                return;
            }

            int id = gDto.Id;

            try
            {
                btnEliminar.Enabled = false;
                await GrupoApiClient.DeleteAsync(id);
                await CargarGrupos();
                btnEliminar.Text = "ELIMINAR GRUPO";
                confirma = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEliminar.Enabled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is GrupoDTO g)
            {

                txtID.Text = g.Id.ToString();
                txtNombre.Text = g.Nombre;
                txtDescripcion.Text = g.Descripcion;

                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

                if (confirma)
                {
                    btnEliminar.Text = "ELIMINAR GRUPO";
                    confirma = false;
                }

            }
        }
    }
}
