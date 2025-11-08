using System;
using System.Drawing;
using System.Windows.Forms;
using Dominio;

namespace Escritorio
{
    partial class FormTareaNoAdmin
    {
        private DataGridView dgvTareas;
        private ComboBox cmbPlan;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtDuracion;
        private DateTimePicker dtpFechaHora;
        private ComboBox cmbEstado;
        private Button btnNuevaTarea;
        private Label lblContador;
        private Panel panelCreacion;
        private Panel panelLista;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Panel creación - Formulario de nueva tarea
            panelCreacion = new Panel { Dock = DockStyle.Top, Height = 180, BackColor = Color.LightGreen };

            var lblTituloCreacion = new Label { Text = "Crear Nueva Tarea", Location = new Point(20, 15), Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true };

            var lblPlan = new Label { Text = "Plan:", Location = new Point(20, 45), AutoSize = true };
            cmbPlan = new ComboBox { Location = new Point(80, 42), Size = new Size(200, 20), DropDownStyle = ComboBoxStyle.DropDownList };

            var lblNombre = new Label { Text = "Nombre:", Location = new Point(20, 75), AutoSize = true };
            txtNombre = new TextBox { Location = new Point(80, 72), Size = new Size(200, 20) };

            var lblDescripcion = new Label { Text = "Descripción:", Location = new Point(20, 105), AutoSize = true };
            txtDescripcion = new TextBox { Location = new Point(80, 102), Size = new Size(200, 20) };

            var lblFechaHora = new Label { Text = "Fecha/Hora:", Location = new Point(300, 45), AutoSize = true };
            dtpFechaHora = new DateTimePicker { Location = new Point(380, 42), Size = new Size(150, 20), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm", ShowUpDown = true };

            var lblDuracion = new Label { Text = "Duración (min):", Location = new Point(300, 75), AutoSize = true };
            txtDuracion = new TextBox { Location = new Point(380, 72), Size = new Size(80, 20) };

            var lblEstado = new Label { Text = "Estado:", Location = new Point(300, 105), AutoSize = true };
            // En el diseñador SOLO creamos el combobox, NO lo poblamos con objetos anónimos ni valores.
            cmbEstado = new ComboBox { Location = new Point(380, 102), Size = new Size(120, 20), DropDownStyle = ComboBoxStyle.DropDownList };

            btnNuevaTarea = new Button { Text = "Crear Tarea", Location = new Point(520, 95), Size = new Size(100, 30) };

            panelCreacion.Controls.AddRange(new Control[] {
                lblTituloCreacion, lblPlan, cmbPlan, lblNombre, txtNombre, lblDescripcion, txtDescripcion,
                lblFechaHora, dtpFechaHora, lblDuracion, txtDuracion, lblEstado, cmbEstado, btnNuevaTarea
            });

            // Panel lista - DataGridView
            panelLista = new Panel { Dock = DockStyle.Fill };

            dgvTareas = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Columnas: Id (oculta), Nombre, Descripción, Fecha/Hora, Duración, Estado, PlanId
            dgvTareas.Columns.Add("colId", "ID");
            dgvTareas.Columns.Add("colNombre", "Nombre");
            dgvTareas.Columns.Add("colDescripcion", "Descripción");
            dgvTareas.Columns.Add("colFechaHora", "Fecha/Hora");
            dgvTareas.Columns.Add("colDuracion", "Duración");
            dgvTareas.Columns.Add("colEstado", "Estado");
            dgvTareas.Columns.Add("colPlanId", "Plan ID");

            // Ocultar Id si no quieres mostrarlo
            dgvTareas.Columns["colId"].Visible = false;
            // Puedes ocultar PlanId si prefieres no mostrarlo en la grilla:
            // dgvTareas.Columns["colPlanId"].Visible = false;

            // Panel inferior - Contador
            var panelInferior = new Panel { Dock = DockStyle.Bottom, Height = 40, BackColor = Color.LightGray };
            lblContador = new Label { Text = "0 tareas", Location = new Point(20, 12), AutoSize = true };
            panelInferior.Controls.Add(lblContador);

            // Agregar controles al form (sin panel de búsqueda)
            panelLista.Controls.Add(dgvTareas);
            this.Controls.AddRange(new Control[] { panelLista, panelCreacion, panelInferior });

            // Eventos
            this.Load += FormTareaNoAdmin_Load;
            btnNuevaTarea.Click += btnNuevaTarea_Click;
            dgvTareas.CellDoubleClick += dgvTareas_CellDoubleClick;

            this.Size = new Size(800, 600);
            this.ResumeLayout(false);
        }
    }
}