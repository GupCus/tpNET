namespace Escritorio
{
    partial class FormGastoNoAdmin
    {
        private DataGridView dgvGastos;
        private ComboBox cmbCategoria;
        private ComboBox cmbTarea;
        private TextBox txtDescripcion;
        private TextBox txtMonto;
        private DateTimePicker dtpFechaHora;
        private Button btnNuevoGasto;
        private TextBox txtBusqueda;
        private Button btnBuscar;
        private Label lblContador;
        private Label lblBuscar;
        private Button btnActualizar;
        private Label lblTotal;
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

            // Panel creación - Formulario de nuevo gasto
            panelCreacion = new Panel { Dock = DockStyle.Top, Height = 150, BackColor = Color.LightGoldenrodYellow };

            var lblTituloCreacion = new Label { Text = "Registrar Nuevo Gasto", Location = new Point(20, 15), Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true };

            var lblCategoria = new Label { Text = "Categoría:", Location = new Point(20, 45), AutoSize = true };
            cmbCategoria = new ComboBox { Location = new Point(80, 42), Size = new Size(150, 20), DropDownStyle = ComboBoxStyle.DropDownList };

            var lblTarea = new Label { Text = "Tarea:", Location = new Point(20, 75), AutoSize = true };
            cmbTarea = new ComboBox { Location = new Point(80, 72), Size = new Size(150, 20), DropDownStyle = ComboBoxStyle.DropDownList };

            var lblDescripcion = new Label { Text = "Descripción:", Location = new Point(250, 45), AutoSize = true };
            txtDescripcion = new TextBox { Location = new Point(320, 42), Size = new Size(200, 20) };

            var lblMonto = new Label { Text = "Monto:", Location = new Point(250, 75), AutoSize = true };
            txtMonto = new TextBox { Location = new Point(320, 72), Size = new Size(80, 20) };

            var lblFechaHora = new Label { Text = "Fecha/Hora:", Location = new Point(420, 75), AutoSize = true };
            dtpFechaHora = new DateTimePicker { Location = new Point(500, 72), Size = new Size(150, 20), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm", ShowUpDown = true };

            btnNuevoGasto = new Button { Text = "Registrar Gasto", Location = new Point(520, 42), Size = new Size(120, 30) };

            panelCreacion.Controls.AddRange(new Control[] {
            lblTituloCreacion, lblCategoria, cmbCategoria, lblTarea, cmbTarea,
            lblDescripcion, txtDescripcion, lblMonto, txtMonto, lblFechaHora, dtpFechaHora, btnNuevoGasto
        });

            // Panel lista - DataGridView
            panelLista = new Panel { Dock = DockStyle.Fill };

            dgvGastos = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvGastos.Columns.Add("colId", "ID");
            dgvGastos.Columns.Add("colDescripcion", "Descripción");
            dgvGastos.Columns.Add("colMonto", "Monto");
            dgvGastos.Columns.Add("colCategoria", "Categoría");
            dgvGastos.Columns.Add("colTarea", "Tarea");
            dgvGastos.Columns.Add("colFechaHora", "Fecha/Hora");
            dgvGastos.Columns.Add("colUsuario", "Usuario");
            dgvGastos.Columns["colId"].Visible = false;

            // Panel inferior - Contador y Total
            var panelInferior = new Panel { Dock = DockStyle.Bottom, Height = 40, BackColor = Color.LightGray };
            lblContador = new Label { Text = "0 gastos", Location = new Point(20, 12), AutoSize = true };
            lblTotal = new Label { Text = "Total: $0.00", Location = new Point(150, 12), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            panelInferior.Controls.AddRange(new Control[] { lblContador, lblTotal });

            // Agregar controles al form
            panelLista.Controls.Add(dgvGastos);
            this.Controls.AddRange(new Control[] { panelLista, panelCreacion, panelSuperior, panelInferior });

            // Eventos
            this.Load += FormGastoNoAdmin_Load;
            btnNuevoGasto.Click += btnNuevoGasto_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnActualizar.Click += btnActualizar_Click;

            this.Size = new Size(800, 600);
            this.ResumeLayout(false);
        }
    }
}