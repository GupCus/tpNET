using DTOs;
using API.Clients;

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
            // Cargar roles en el ComboBox
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
            comRol.SelectedIndex = 1; // Por defecto "NoAdmin"
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
                txtContraseña.Text = ""; // Por seguridad, no se muestra la contraseña

                // Seleccionar el rol en el ComboBox
                if (u.Rol == "Admin" || u.Rol == "NoAdmin")
                    comRol.SelectedItem = u.Rol;
                else
                    comRol.SelectedIndex = 1; // Default "NoAdmin"

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
                int id = int.Parse(txtID.Text);
                await UsuarioApiClient.DeleteAsync(id);
                await this.GetUsuarios();
                Eliminar.Text = "Eliminar";
                confirma = false;
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
