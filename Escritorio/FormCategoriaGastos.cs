using DTOs;
using API.Clients;
using System.Diagnostics;

namespace Escritorio
{
    public partial class FormCategoriaGastos : Form
    {
        /* Lógica del form */
        private bool confirmarEliminar = false;
       

        public FormCategoriaGastos()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Form1_Load ejecutándose...");
            await GetCategorias();
            Debug.WriteLine("Form1_Load completado");
        }

        //Metodo que se encarga de sanitizar la categoria para no enviar nulos
        private object LimpiarCategoria()
        {
            bool nuevo = string.IsNullOrEmpty(txtID.Text);
            if (!nuevo)
            {
                CategoriaGastoUpdateDTO cgUpdate = new()
                {
                    Id = string.IsNullOrEmpty(txtID.Text) ? 0 : int.Parse(txtID.Text),
                    Tipo = string.IsNullOrEmpty(txtTipo.Text) ? "Alimentos" : txtTipo.Text,
                    Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Descripcion" : txtDescripcion.Text,
                };
                return cgUpdate;
            }
            else
            {
                CategoriaGastoDTO cg = new()
                {
                    Tipo = string.IsNullOrEmpty(txtTipo.Text) ? "Alimentos" : txtTipo.Text,
                    Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Descripcion" : txtDescripcion.Text,
                };
                return cg;

            }
        }
        //Limpia las casillas al hacer click
        private void Txt_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        //Al Seleccionar una categoria (fila), se rescatan sus datos a la UI
        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow != null && dgvCategoria.CurrentRow.DataBoundItem is CategoriaGastoDTO cg)
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
        private async Task GetCategorias()
        {
            try
            {
                var cgs = await CategoriaGastoApiClient.GetAllAsync();
                Debug.WriteLine($"Categorías recibidas: {cgs?.Count() ?? 0}");
                this.dgvCategoria.DataSource = null;
                this.dgvCategoria.AutoGenerateColumns = true;
                this.dgvCategoria.DataSource = cgs;
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"Error: {ex.Message}", "Error al cargar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //POST Categoria
        private async void Cargar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            CategoriaGastoDTO cg = (CategoriaGastoDTO)this.LimpiarCategoria();
            await CategoriaGastoApiClient.AddAsync(cg);
            await GetCategorias();
        }
        //PUT Categoria
        private async void Modificar_Click(object sender, EventArgs e)
        {
            CategoriaGastoUpdateDTO cg = (CategoriaGastoUpdateDTO)this.LimpiarCategoria();
            await CategoriaGastoApiClient.UpdateAsync(cg);
            await GetCategorias();
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
                await CategoriaGastoApiClient.DeleteAsync(((CategoriaGastoDTO)dgvCategoria.CurrentRow.DataBoundItem).Id);
                await GetCategorias();
                Eliminar.Text = "ELIMINAR CATEGORIA";
                confirmarEliminar = false;
            }
        }
    }
}
