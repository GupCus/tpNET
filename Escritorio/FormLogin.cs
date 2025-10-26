using System;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace Escritorio
{
    public partial class FormLogin : Form
    {
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
                // Crear el DTO de login
                LoginDTO user = new()
                {
                    Usuario = txtUsername.Text.Trim(),
                    Contrasena = txtPassword.Text.Trim()
                };

                // Consumir el servicio API del login (retorna bool)
                bool ok = await UsuarioApiClient.Login(user);

                if (ok)
                {
                    MessageBox.Show("¡Usted ha ingresado correctamente!",
                        "Login Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    // Puedes guardar datos del usuario logueado aquí si lo necesitas
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