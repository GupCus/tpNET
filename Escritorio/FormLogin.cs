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
                // Llama al endpoint de login de la API usando UsuarioUpdateDTO
                var usuario = await UsuarioApiClient.LoginAsync(txtUsername.Text, txtPassword.Text);

                if (usuario != null)
                {
                    MessageBox.Show("¡Usted ha ingresado correctamente!",
                        "Login Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    // Puedes guardar datos del usuario logueado aquí si lo necesitas
                    return;
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos",
                        "Login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
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