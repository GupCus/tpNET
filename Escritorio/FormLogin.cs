using System;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace Escritorio
{
    public partial class FormLogin : Form
    {
        public static UsuarioDTO? UsuarioLogueado { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LoginDTO user = new()
                {
                    Usuario = txtUsername.Text.Trim(),
                    Contrasena = txtPassword.Text.Trim()
                };

                UsuarioDTO? usuario = await UsuarioApiClient.Login(user);

                if (usuario != null)
                {
                    MessageBox.Show($"¡Bienvenido, {usuario.Nombre}!",
                        "Login Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    UsuarioLogueado = usuario;
                    Sesion.UsuarioActual = usuario;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos",
                        "Login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar usuario: " + ex.Message,
                    "Error API",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}