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


namespace Escritorio
{
    public partial class FormLogin : Form
    {
        private readonly UsuarioClient usuarioClient;
        public FormLogin()
        {
            InitializeComponent();
            usuarioClient = new UsuarioClient(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7126/")
            });
        }
        
        private  async void btnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.");
                return;
            }
            var users = await usuarioClient.GetAllAsync();
            Console.WriteLine(users.Count());
           var usuario=users.FirstOrDefault(u=>u.Nombre==txtUsername.Text && u.Contrasena==txtPassword.Text);
            if (usuario != null)
            {
                MessageBox.Show("¡Usted ha ingresado correctamente!");
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
                this.Hide();

            }
            else { MessageBox.Show("Usuario y/o contraseña incorrectos..."); }
        }
    }
}
