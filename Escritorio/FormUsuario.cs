using DTOs;
using API.Clients;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FormUsuario : Form
    {
        private bool confirma = false;

        public FormUsuario()
        {
            InitializeComponent();
        }

        private async void FormUsuario_Load(object sender, EventArgs e)
        {
            comRol.Items.Clear();
            comRol.Items.Add("Admin");
            comRol.Items.Add("NoAdmin");
            comRol.SelectedIndex = 1;
            await GetUsuarios();
        }

        private async Task GetUsuarios()
        {
            try
            {
                var users = await UsuarioApiClient.GetAllAsync();
                this.dgvUsuario.DataSource = null;
                this.dgvUsuario.AutoGenerateColumns = true;
                this.dgvUsuario.DataSource = users;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        private UsuarioUpdateDTO LimpiarUsuario()
        {
            UsuarioUpdateDTO user = new()
            {
                Id = string.IsNullOrEmpty(txtID.Text) ? 0 : int.Parse(txtID.Text),
                Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Juan Perez" : txtNombre.Text,
                Mail = string.IsNullOrEmpty(txtMail.Text) ? "jperez@gmail.com" : txtMail.Text,
                Contrasena = string.IsNullOrEmpty(txtContraseña.Text) ? "" : txtContraseña.Text,
                Rol = comRol.SelectedItem?.ToString() ?? "NoAdmin"
            };
            return user;
        }

        private void LimpiarCampos()
        {
            this.txtID.Text = "";
            this.txtNombre.Text = "";
            this.txtMail.Text = "";
            this.txtContraseña.Text = "";
            comRol.SelectedIndex = 1;
        }

        private void Txt_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        private void dgvUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuario.CurrentRow != null && dgvUsuario.CurrentRow.DataBoundItem is UsuarioDTO u)
            {
                txtID.Text = u.Id.ToString();
                txtNombre.Text = u.Nombre;
                txtMail.Text = u.Mail;
                txtContraseña.Text = "";

                if (u.Rol == "Admin" || u.Rol == "NoAdmin")
                    comRol.SelectedItem = u.Rol;
                else
                    comRol.SelectedIndex = 1;

                Nuevo.Enabled = true;
                Editar.Enabled = true;
                if (confirma)
                {
                    Eliminar.Text = "Eliminar";
                    confirma = false;
                }
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            confirma = false;
            Eliminar.Text = "Eliminar usuario";
            this.LimpiarCampos();
        }

        private async void Nuevo_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            try
            {
                UsuarioUpdateDTO u = this.LimpiarUsuario();
                await UsuarioApiClient.AddAsync(u);
                await this.GetUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Editar_Click(object sender, EventArgs e)
        {
            UsuarioUpdateDTO u = this.LimpiarUsuario();
            await UsuarioApiClient.UpdateAsync(u);
            await this.GetUsuarios();
        }

        private async void Eliminar_Click(object sender, EventArgs e)
        {
            if (!confirma)
            {
                Eliminar.Text = "¿SEGURO?";
                confirma = true;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    confirma = false;
                    Eliminar.Text = "Eliminar";
                    return;
                }

                if (!int.TryParse(txtID.Text, out int id))
                {
                    MessageBox.Show("ID inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confirma = false;
                    Eliminar.Text = "Eliminar";
                    return;
                }

                try
                {
                    Eliminar.Enabled = false; 
                    await UsuarioApiClient.DeleteAsync(id);
                    await this.GetUsuarios();
                    Eliminar.Text = "Eliminar";
                    confirma = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Eliminar.Enabled = true;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
