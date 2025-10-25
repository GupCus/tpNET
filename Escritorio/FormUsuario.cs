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
using DTOs;
using API.Clients;
namespace Escritorio
{
    public partial class FormUsuario : Form
    {
        private bool confirma = false;
        private readonly UsuarioApiClient usuarioClient;
        public FormUsuario()
        {
            InitializeComponent();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7126/")
            };


            //usuarioClient = new UsuarioApiClient(client);
        }

        private async void FormUsuario_Load(object sender, EventArgs e)
        {

            await GetUsuarios();
        }
        private async Task GetUsuarios()
        {
            try
            {
                //var users = await usuarioClient.GetAllAsync();
                //this.dgvUsuario.DataSource = users;
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

        private UsuarioDTO LimpiarUsuario()
        {
            UsuarioDTO user = new UsuarioDTO
            {
                Id = string.IsNullOrEmpty(txtID.Text) ? 0 : int.Parse(txtID.Text),
                Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Juan Perez" : txtNombre.Text,
                Mail = string.IsNullOrEmpty(txtMail.Text) ? "jperez@gmail.com" : txtMail.Text,

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
            if (dgvUsuario.CurrentRow != null && dgvUsuario.CurrentRow.DataBoundItem is UsuarioDTO u)
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
                UsuarioDTO u = this.LimpiarUsuario();
                //await usuarioClient.AddAsync( u);
                await this.GetUsuarios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void Editar_Click(object sender, EventArgs e)
        {
            UsuarioDTO u = this.LimpiarUsuario();
            //await usuarioClient.UpdateAsync(u);
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
                //await usuarioClient.DeleteAsync(id);
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
    }
}
