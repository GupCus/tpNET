using Dominio;
using DTOs;
using Services;
using System.Net.Http.Json;


namespace Escritorio
{
    public partial class FormCategoriaGastos : Form
    {
        /* Lógica del form */
        private bool confirmarEliminar = false;
        private readonly CategoriaGastoService CategoriaGastoService = new();

        public FormCategoriaGastos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GetCategorias();
        }

        //Metodo que se encarga de sanitizar la categoria para no enviar nulos
        private CategoriaGastoDTO LimpiarCategoria()
        {

            CategoriaGastoDTO cg = new()
            {
                Id = string.IsNullOrEmpty(txtID.Text) ? 0 : int.Parse(txtID.Text),
                Tipo = string.IsNullOrEmpty(txtTipo.Text) ? "Alimentos" : txtTipo.Text,
                Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Descripcion" : txtDescripcion.Text,
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
        private void GetCategorias()
        {
            var cgs = CategoriaGastoService.GetAll();
            this.dgvCategoria.DataSource = cgs;
        }

        //POST Categoria
        private async void Cargar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            CategoriaGastoDTO cg = this.LimpiarCategoria();
            CategoriaGastoService.Add(cg);
            this.GetCategorias();
        }
        //PUT Categoria
        private async void Modificar_Click(object sender, EventArgs e)
        {
            CategoriaGastoDTO cg = this.LimpiarCategoria();
            CategoriaGastoService.Update(cg);
            this.GetCategorias();
        }

        //DELETE Categoria
        private async void Eliminar_Click(object sender, EventArgs e)
        {
            if (!confirmarEliminar)
            {
                Eliminar.Text = "¿ESTÁ SEGURO?";
                confirmarEliminar = true;
            }
            //Hacer click de vuelta para ejecutar esto
            else
            {
                CategoriaGastoService.Delete(((CategoriaGasto)dgvCategoria.CurrentRow.DataBoundItem).Id);
                this.GetCategorias();
                Eliminar.Text = "ELIMINAR CATEGORIA";
                confirmarEliminar = false;
            }
        }
    }
}
