using System;
using System.Drawing;
using System.Windows.Forms;

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
        private Panel panelSuperior;
        private Panel panelInferior;
        private Label lblTituloCreacion;
        private Label lblCategoria;
        private Label lblTarea;
        private Label lblDescripcion;
        private Label lblMonto;
        private Label lblFechaHora;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colTarea;
        private DataGridViewTextBoxColumn colFechaHora;
        private DataGridViewTextBoxColumn colUsuario;

        private void InitializeComponent()
        {
            // Inicializar componentes
            panelSuperior = new Panel();
            panelCreacion = new Panel();
            panelLista = new Panel();
            panelInferior = new Panel();

            lblBuscar = new Label();
            txtBusqueda = new TextBox();
            btnBuscar = new Button();
            btnActualizar = new Button();

            lblTituloCreacion = new Label();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblTarea = new Label();
            cmbTarea = new ComboBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblMonto = new Label();
            txtMonto = new TextBox();
            lblFechaHora = new Label();
            dtpFechaHora = new DateTimePicker();
            btnNuevoGasto = new Button();

            dgvGastos = new DataGridView();

            colId = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colTarea = new DataGridViewTextBoxColumn();
            colFechaHora = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();

            lblContador = new Label();
            lblTotal = new Label();

            SuspendLayout();

            // panelSuperior
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Height = 60;
            panelSuperior.Padding = new Padding(10);
            panelSuperior.BackColor = Color.LightGray;

            lblBuscar.Text = "Buscar:";
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(10, 20);

            txtBusqueda.Location = new Point(70, 16);
            txtBusqueda.Size = new Size(250, 24);

            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new Point(330, 14);
            btnBuscar.Size = new Size(75, 28);
            btnBuscar.Click += btnBuscar_Click;

            btnActualizar.Text = "Actualizar";
            btnActualizar.Location = new Point(415, 14);
            btnActualizar.Size = new Size(85, 28);
            btnActualizar.Click += btnActualizar_Click;

            panelSuperior.Controls.AddRange(new Control[] { lblBuscar, txtBusqueda, btnBuscar, btnActualizar });

            // panelCreacion
            panelCreacion.Dock = DockStyle.Top;
            panelCreacion.Height = 140;
            panelCreacion.Padding = new Padding(10);
            panelCreacion.BackColor = Color.LightGreen;

            lblTituloCreacion.Text = "Registrar Gasto";
            lblTituloCreacion.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTituloCreacion.AutoSize = true;
            lblTituloCreacion.Location = new Point(10, 8);

            lblCategoria.Text = "Categoría:";
            lblCategoria.Location = new Point(10, 40);
        lblCategoryPosition:;

            cmbCategoria.Location = new Point(90, 36);
            cmbCategoria.Size = new Size(220, 24);
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;

            lblTarea.Text = "Tarea:";
            lblTarea.Location = new Point(330, 40);

            cmbTarea.Location = new Point(380, 36);
            cmbTarea.Size = new Size(240, 24);
            cmbTarea.DropDownStyle = ComboBoxStyle.DropDownList;

            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Location = new Point(10, 75);
            txtDescripcion.Location = new Point(90, 72);
            txtDescripcion.Size = new Size(350, 24);

            lblMonto.Text = "Monto:";
            lblMonto.Location = new Point(460, 75);
            txtMonto.Location = new Point(520, 72);
            txtMonto.Size = new Size(100, 24);
            txtMonto.KeyPress += txtMonto_KeyPress;

            lblFechaHora.Text = "Fecha/Hora:";
            lblFechaHora.Location = new Point(10, 105);
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaHora.ShowUpDown = true;
            dtpFechaHora.Location = new Point(90, 100);
            dtpFechaHora.Size = new Size(170, 24);

            btnNuevoGasto.Text = "Registrar";
            btnNuevoGasto.Size = new Size(100, 30);
            btnNuevoGasto.Location = new Point(520, 98);
            btnNuevoGasto.Click += btnNuevoGasto_Click;

            panelCreacion.Controls.AddRange(new Control[] {
                lblTituloCreacion,
                lblCategoria, cmbCategoria,
                lblTarea, cmbTarea,
                lblDescripcion, txtDescripcion,
                lblMonto, txtMonto,
                lblFechaHora, dtpFechaHora,
                btnNuevoGasto
            });

            // panelLista
            panelLista.Dock = DockStyle.Fill;
            panelLista.Padding = new Padding(10);

            dgvGastos.Dock = DockStyle.Fill;
            dgvGastos.ReadOnly = true;
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.AllowUserToDeleteRows = false;
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // columnas (nombres usados por el form)
            colId.Name = "colId";
            colId.HeaderText = "ID";
            colId.Visible = false;

            colDescripcion.Name = "colDescripcion";
            colDescripcion.HeaderText = "Descripción";

            colMonto.Name = "colMonto";
            colMonto.HeaderText = "Monto";

            colCategoria.Name = "colCategoria";
            colCategoria.HeaderText = "Categoría";

            colTarea.Name = "colTarea";
            colTarea.HeaderText = "Tarea";

            colFechaHora.Name = "colFechaHora";
            colFechaHora.HeaderText = "Fecha/Hora";

            colUsuario.Name = "colUsuario";
            colUsuario.HeaderText = "Usuario";

            dgvGastos.Columns.AddRange(new DataGridViewColumn[] {
                colId, colDescripcion, colMonto, colCategoria, colTarea, colFechaHora, colUsuario
            });

            panelLista.Controls.Add(dgvGastos);

            // panelInferior
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Height = 40;
            panelInferior.Padding = new Padding(10);
            panelInferior.BackColor = Color.LightGray;

            lblContador.AutoSize = true;
            lblContador.Location = new Point(10, 10);

            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(600, 10);

            panelInferior.Controls.AddRange(new Control[] { lblContador, lblTotal });

            // FormGastoNoAdmin
            ClientSize = new Size(900, 600);
            Controls.AddRange(new Control[] { panelLista, panelCreacion, panelSuperior, panelInferior });
            Name = "FormGastoNoAdmin";
            Text = "Gestión de Gastos";
            Load += FormGastoNoAdmin_Load;

            ResumeLayout(false);
        }
    }
}