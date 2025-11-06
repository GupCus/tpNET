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
        private TextBox txtBusqueda;
        private Button btnBuscar;
        private Label lblContador;
        private Label lblBuscar;
        private Button btnActualizar;
        private Panel panelCreacion;
        private Panel panelLista;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Panel superior - Búsqueda
            var panelSuperior = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.LightGray };

            lblBuscar = new Label { Text = "Buscar:", Location = new Point(20, 20), AutoSize = true };
            txtBusqueda = new TextBox { Location = new Point(80, 17), Size = new Size(200, 20) };
            btnBuscar = new Button { Text = "Buscar", Location = new Point(290, 15), Size = new Size(75, 25) };
            btnActualizar = new Button { Text = "Actualizar", Location = new Point(375, 15), Size = new Size(80, 25) };

            panelSuperior.Controls.AddRange(new Control[] { lblBuscar, txtBusqueda, btnBuscar, btnActualizar });

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
            cmbEstado = new ComboBox { Location = new Point(380, 102), Size = new Size(120, 20), DropDownStyle = ComboBoxStyle.DropDownList };

            // POBLAR solo con los dos estados necesarios (evitar duplicados)
            // Usamos objetos con Text/Value para mostrar texto y leer el valor numérico (0/1) al crear la tarea.
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
            cmbEstado.Items.Add(new { Text = "Activo", Value = (int)EstadoTarea.Activo });
            cmbEstado.Items.Add(new { Text = "Pendiente", Value = (int)EstadoTarea.Pendiente });
            cmbEstado.SelectedIndex = 0; // por defecto "Activo"

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

            // Agregar controles al form
            panelLista.Controls.Add(dgvTareas);
            this.Controls.AddRange(new Control[] { panelLista, panelCreacion, panelSuperior, panelInferior });

            // Eventos
            this.Load += FormTareaNoAdmin_Load;
            btnNuevaTarea.Click += btnNuevaTarea_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnActualizar.Click += btnActualizar_Click;
            dgvTareas.CellDoubleClick += dgvTareas_CellDoubleClick;

            this.Size = new Size(800, 600);
            this.ResumeLayout(false);
        }
    }
}