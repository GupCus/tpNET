namespace Escritorio
{
    partial class FormPlanNoAdmin
    {
        private DataGridView dgvPlanes;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Button btnNuevoPlan;
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

            // Panel creación - Formulario de nuevo plan
            panelCreacion = new Panel { Dock = DockStyle.Top, Height = 150, BackColor = Color.LightBlue };

            var lblTituloCreacion = new Label { Text = "Crear Nuevo Plan", Location = new Point(20, 15), Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true };
            var lblNombre = new Label { Text = "Nombre:", Location = new Point(20, 50), AutoSize = true };
            txtNombre = new TextBox { Location = new Point(80, 47), Size = new Size(200, 20) };
            var lblDescripcion = new Label { Text = "Descripción:", Location = new Point(20, 80), AutoSize = true };
            txtDescripcion = new TextBox { Location = new Point(80, 77), Size = new Size(200, 20) };
            var lblFechaInicio = new Label { Text = "Fecha Inicio:", Location = new Point(300, 50), AutoSize = true };
            dtpFechaInicio = new DateTimePicker { Location = new Point(380, 47), Size = new Size(120, 20) };
            var lblFechaFin = new Label { Text = "Fecha Fin:", Location = new Point(300, 80), AutoSize = true };
            dtpFechaFin = new DateTimePicker { Location = new Point(380, 77), Size = new Size(120, 20) };
            btnNuevoPlan = new Button { Text = "Crear Plan", Location = new Point(520, 70), Size = new Size(100, 30) };

            panelCreacion.Controls.AddRange(new Control[] {
            lblTituloCreacion, lblNombre, txtNombre, lblDescripcion, txtDescripcion,
            lblFechaInicio, dtpFechaInicio, lblFechaFin, dtpFechaFin, btnNuevoPlan
        });

            // Panel lista - DataGridView
            panelLista = new Panel { Dock = DockStyle.Fill };

            dgvPlanes = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvPlanes.Columns.Add("colId", "ID");
            dgvPlanes.Columns.Add("colNombre", "Nombre");
            dgvPlanes.Columns.Add("colDescripcion", "Descripción");
            dgvPlanes.Columns.Add("colFechaInicio", "Fecha Inicio");
            dgvPlanes.Columns.Add("colFechaFin", "Fecha Fin");
            dgvPlanes.Columns["colId"].Visible = false;

            // Panel inferior - Contador
            var panelInferior = new Panel { Dock = DockStyle.Bottom, Height = 40, BackColor = Color.LightGray };
            lblContador = new Label { Text = "0 planes", Location = new Point(20, 12), AutoSize = true };
            panelInferior.Controls.Add(lblContador);

            // Agregar controles al form
            panelLista.Controls.Add(dgvPlanes);
            this.Controls.AddRange(new Control[] { panelLista, panelCreacion, panelSuperior, panelInferior });

            // Eventos
            this.Load += FormPlanNoAdmin_Load;
            btnNuevoPlan.Click += btnNuevoPlan_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnActualizar.Click += btnActualizar_Click;

            this.Size = new Size(800, 600);
            this.ResumeLayout(false);
        }
    }
}