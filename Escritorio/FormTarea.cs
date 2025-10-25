using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FormTarea : Form
    {

        /* Lógica del form */
        private bool confirmarEliminar = false;

        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5032")
        };
        public FormTarea()
        {
            InitializeComponent();
        }
        private void FormTarea_Load(object sender, EventArgs e)
        {
            txtEstado.DataSource = Enum.GetValues(typeof(EstadoTarea));
            GetTareas();
        }

        //Metodo que se encarga de sanitizar la tarea para no enviar nulos
        private Tarea LimpiarTarea()
        {

            Tarea t = new()
            {
                /*
                Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Sin nombre" : txtNombre.Text,
                FechaHora = txtFechaHora.Value,
                Duracion = int.TryParse(txtDuracion.Text, out int duracion) ? duracion : null, 
                Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text,
                Estado = (EstadoTarea?)txtEstado.SelectedItem ?? EstadoTarea.Activo
            */};

            return t;
        }

        //Al Seleccionar una tarea (fila), se rescatan sus datos a la UI
        private void dgvTarea_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTarea.CurrentRow != null && dgvTarea.CurrentRow.DataBoundItem is Tarea t)
            {
                //txtID.Text = t.Id?.ToString() ?? "";
                txtNombre.Text = t.Nombre ?? "";
                txtFechaHora.Value = t.FechaHora ?? DateTime.Now;
                txtDuracion.Text = t.Duracion?.ToString() ?? "";
                txtDescripcion.Text = t.Descripcion ?? "";
                txtEstado.SelectedItem = t.Estado;

                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                // Reset eliminar
                if (confirmarEliminar)
                {
                    btnEliminar.Text = "ELIMINAR TAREA";
                    confirmarEliminar = false;
                }
            }
        }

        /* API Tarea */
        //GET ALL Tarea || Actualización de la tabla principal
        private async void GetTareas()
        {
            var tareas = await httpClient.GetFromJsonAsync<IEnumerable<Tarea>>("tarea");
            this.dgvTarea.DataSource = tareas;
        }

        //POST Tarea
        private async void btnNuevo_Click(object sender, EventArgs e)
        {
           txtID.Text = "";
           Tarea t = this.LimpiarTarea();
           await httpClient.PostAsJsonAsync("tarea", t);
           this.GetTareas();
        }
        //PUT Tarea
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            Tarea t = this.LimpiarTarea();
            await httpClient.PutAsJsonAsync($"tarea/{((Tarea)dgvTarea.CurrentRow.DataBoundItem).Id}", t);
            this.GetTareas();
        }

        //DELETE tarea
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!confirmarEliminar)
            {
                btnEliminar.Text = "¿ESTÁ SEGURO?";
                confirmarEliminar = true;
            }
            //Hacer click de vuelta para ejecutar esto
            else
            {
                await httpClient.DeleteAsync($"tarea/{((Tarea)dgvTarea.CurrentRow.DataBoundItem).Id}");
                this.GetTareas();
                btnEliminar.Text = "ELIMINAR TAREA";
                confirmarEliminar = false;
            }
        }


    }
}
