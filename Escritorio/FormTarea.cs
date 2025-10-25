using Dominio;
using DTOs;
using Services;

namespace Escritorio
{
    public partial class FormTarea : Form
    {

        /* Lógica del form */
        private bool confirmarEliminar = false;

        private readonly TareaService service = new();
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
        private TareaDTO LimpiarTarea()
        {

            TareaDTO t = new()
            {
                
                Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "Sin nombre" : txtNombre.Text,
                FechaHora = txtFechaHora.Value,
                Duracion = int.TryParse(txtDuracion.Text, out int duracion) ? duracion : null, 
                Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text,
                Estado = (EstadoTarea?)txtEstado.SelectedItem ?? EstadoTarea.Activo
            };

            return t;
        }

        //Al Seleccionar una tarea (fila), se rescatan sus datos a la UI
        private void dgvTarea_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTarea.CurrentRow != null && dgvTarea.CurrentRow.DataBoundItem is Tarea t)
            {
                txtID.Text = t.Id.ToString() ?? "";
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
        private void GetTareas()
        {
            var tareas = service.GetAll();
            this.dgvTarea.DataSource = tareas;
        }

        //POST Tarea
        private void btnNuevo_Click(object sender, EventArgs e)
        {
           txtID.Text = "";
           TareaDTO t = this.LimpiarTarea();
           service.Add(t);
           this.GetTareas();
        }
        //PUT Tarea
        private void btnModificar_Click(object sender, EventArgs e)
        {
            TareaDTO t = this.LimpiarTarea();
            service.Update(t);
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
                service.Delete(((Tarea)dgvTarea.CurrentRow.DataBoundItem).Id);
                this.GetTareas();
                btnEliminar.Text = "ELIMINAR TAREA";
                confirmarEliminar = false;
            }
        }


    }
}
