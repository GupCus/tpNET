using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using API.Clients;
using Services;
using DTOs;


namespace Escritorio
{
    public partial class FormLogin : Form
    {
        private readonly UsuarioService usuarioService = new();
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

            LoginDTO user = new() { Usuario= txtUsername.Text, Contrasena= txtPassword.Text };

            if (usuarioService.Login(user))
            {
                MessageBox.Show("¡Usted ha ingresado correctamente!",
                    "Login Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                return;
            }
            else {

                MessageBox.Show("Usuario y/o contraseña incorrectos",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
    }
}
