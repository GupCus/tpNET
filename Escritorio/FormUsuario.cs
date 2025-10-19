using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Windows.Forms;
using Dominio;
using System.Reflection.Metadata.Ecma335;
using System.Net.Http;
namespace Escritorio
{
    public partial class FormUsuario : Form
    {
        private bool confirma = false;

        public FormUsuario()
        {
            InitializeComponent();

        }
        private readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7126/")
        };
        private async void FormUsuario_Load(object sender, EventArgs e)
        {

            await GetUsuarios();
        }
        private async Task GetUsuarios()
        {
            try
            {
                var users = await client.GetFromJsonAsync<IEnumerable<Usuario>>("usuario");
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

        private Usuario LimpiarUsuario()
        {
            Usuario user = new Usuario
            {
                Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Juan Perez" : txtNombre.Text,
                Mail = string.IsNullOrEmpty(txtMail.Text) ? "jperez@gmail.com" : txtMail.Text,
                Contrasena = "123"
            };
            return user;
        }
        private void LimpiarCampos()
        {
            this.txtID.Text = "";
            this.txtNombre.Text = "";
            this.txtMail.Text = "";
        }
        private void Txt_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
        private void dgvUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuario.CurrentRow != null && dgvUsuario.CurrentRow.DataBoundItem is Usuario u)
            {
                txtID.Text = u.Id.ToString();
                txtNombre.Text = u.Nombre;
                txtMail.Text = u.Mail;

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
                Usuario u = this.LimpiarUsuario();
                await client.PostAsJsonAsync("usuario", u);
                await this.GetUsuarios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void Editar_Click(object sender, EventArgs e)
        {
            Usuario u = this.LimpiarUsuario();
            await client.PutAsJsonAsync($"usuario/{((Usuario)dgvUsuario.CurrentRow.DataBoundItem).Id}", u);
            this.GetUsuarios();

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
                await client.DeleteAsync($"usuario/{((Usuario)dgvUsuario.CurrentRow.DataBoundItem).Id}");
                this.GetUsuarios();
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
    }
}
