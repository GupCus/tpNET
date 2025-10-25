using Domain.Model;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Escritorio
{
    public partial class FormCategoriaGastos : Form
    {
        /* L�gica del form */
        private bool confirmarEliminar = false;

        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5032")
        };

        public FormCategoriaGastos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GetCategorias();
        }

        //Metodo que se encarga de sanitizar la categoria para no enviar nulos
        private CategoriaGasto LimpiarCategoria()
        {

            CategoriaGasto cg = new()
            {
                /*
                Tipo = string.IsNullOrEmpty(txtTipo.Text) ? "Alimentos" : txtTipo.Text,
                Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Descripcion" : txtDescripcion.Text,}
                */
            };

            return cg;
        }
        //Limpia las casillas al hacer click
        private void Txt_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
        //Al Seleccionar una categoria (fila), se rescatan sus datos a la UI
        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow != null && dgvCategoria.CurrentRow.DataBoundItem is CategoriaGasto cg)
            {

                txtID.Text = cg.Id.ToString();
                txtTipo.Text = cg.Tipo;
                txtDescripcion.Text = cg.Descripcion;

                Modificar.Enabled = true;
                Eliminar.Enabled = true;

                //Reset eliminar
                if (confirmarEliminar)
                {
                    Eliminar.Text = "ELIMINAR CATEGOR�A";
                    confirmarEliminar = false;
                }

            }
        }

        /* API CategoriasGastos */
        //GET ALL Categorias || Actualizaci�n de la tabla principal
        private async void GetCategorias()
        {
            var cgs = await httpClient.GetFromJsonAsync<IEnumerable<CategoriaGasto>>("categoriagastos");
            this.dgvCategoria.DataSource = cgs;
        }

        //POST Categoria
        private async void Cargar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            CategoriaGasto cg = this.LimpiarCategoria();
            await httpClient.PostAsJsonAsync("categoriagastos", cg);
            this.GetCategorias();
        }
        //PUT Categoria
        private async void Modificar_Click(object sender, EventArgs e)
        {
            CategoriaGasto cg = this.LimpiarCategoria();
            await httpClient.PutAsJsonAsync($"categoriagastos/{((CategoriaGasto)dgvCategoria.CurrentRow.DataBoundItem).Id}", cg);
            this.GetCategorias();
        }

        //DELETE Categoria
        private async void Eliminar_Click(object sender, EventArgs e)
        {
            if (!confirmarEliminar)
            {
                Eliminar.Text = "�EST� SEGURO?";
                confirmarEliminar = true;
            }
            //Hacer click de vuelta para ejecutar esto
            else
            {
                await httpClient.DeleteAsync($"categoriagastos/{((CategoriaGasto)dgvCategoria.CurrentRow.DataBoundItem).Id}");
                this.GetCategorias();
                Eliminar.Text = "ELIMINAR CATEGORIA";
                confirmarEliminar = false;
            }
        }
    }
}
