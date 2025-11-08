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
        private Label lblContador;
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
            panelSuperior = new Panel();
            panelCreacion = new Panel();
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
            panelLista = new Panel();
            dgvGastos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colTarea = new DataGridViewTextBoxColumn();
            colFechaHora = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            panelInferior = new Panel();
            lblContador = new Label();
            lblTotal = new Label();
            panelCreacion.SuspendLayout();
            panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.LightGray;
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Padding = new Padding(10);
            panelSuperior.Size = new Size(900, 60);
            panelSuperior.TabIndex = 2;
            // 
            // panelCreacion
            // 
            panelCreacion.BackColor = Color.LightGreen;
            panelCreacion.Controls.Add(lblTituloCreacion);
            panelCreacion.Controls.Add(lblCategoria);
            panelCreacion.Controls.Add(cmbCategoria);
            panelCreacion.Controls.Add(lblTarea);
            panelCreacion.Controls.Add(cmbTarea);
            panelCreacion.Controls.Add(lblDescripcion);
            panelCreacion.Controls.Add(txtDescripcion);
            panelCreacion.Controls.Add(lblMonto);
            panelCreacion.Controls.Add(txtMonto);
            panelCreacion.Controls.Add(lblFechaHora);
            panelCreacion.Controls.Add(dtpFechaHora);
            panelCreacion.Controls.Add(btnNuevoGasto);
            panelCreacion.Dock = DockStyle.Top;
            panelCreacion.Location = new Point(0, 60);
            panelCreacion.Name = "panelCreacion";
            panelCreacion.Padding = new Padding(10);
            panelCreacion.Size = new Size(900, 140);
            panelCreacion.TabIndex = 1;
            // 
            // lblTituloCreacion
            // 
            lblTituloCreacion.AutoSize = true;
            lblTituloCreacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloCreacion.Location = new Point(10, 8);
            lblTituloCreacion.Name = "lblTituloCreacion";
            lblTituloCreacion.Size = new Size(133, 23);
            lblTituloCreacion.TabIndex = 0;
            lblTituloCreacion.Text = "Registrar Gasto";
            // 
            // lblCategoria
            // 
            lblCategoria.Location = new Point(10, 40);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(74, 23);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Location = new Point(90, 36);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(220, 28);
            cmbCategoria.TabIndex = 2;
            // 
            // lblTarea
            // 
            lblTarea.Location = new Point(330, 40);
            lblTarea.Name = "lblTarea";
            lblTarea.Size = new Size(54, 23);
            lblTarea.TabIndex = 3;
            lblTarea.Text = "Tarea:";
            // 
            // cmbTarea
            // 
            cmbTarea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTarea.Location = new Point(390, 36);
            cmbTarea.Name = "cmbTarea";
            cmbTarea.Size = new Size(240, 28);
            cmbTarea.TabIndex = 4;
            cmbTarea.SelectedIndexChanged += cmbTarea_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(0, 75);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(91, 23);
            lblDescripcion.TabIndex = 5;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(90, 71);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(350, 27);
            txtDescripcion.TabIndex = 6;
            // 
            // lblMonto
            // 
            lblMonto.Location = new Point(460, 75);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(54, 23);
            lblMonto.TabIndex = 7;
            lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(530, 70);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(100, 27);
            txtMonto.TabIndex = 8;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // lblFechaHora
            // 
            lblFechaHora.Location = new Point(10, 105);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(74, 23);
            lblFechaHora.TabIndex = 9;
            lblFechaHora.Text = "Fecha/Hora:";
            // 
            // dtpFechaHora
            // 
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.Location = new Point(90, 100);
            dtpFechaHora.Name = "dtpFechaHora";
            dtpFechaHora.ShowUpDown = true;
            dtpFechaHora.Size = new Size(170, 27);
            dtpFechaHora.TabIndex = 10;
            // 
            // btnNuevoGasto
            // 
            btnNuevoGasto.Location = new Point(530, 100);
            btnNuevoGasto.Name = "btnNuevoGasto";
            btnNuevoGasto.Size = new Size(100, 30);
            btnNuevoGasto.TabIndex = 11;
            btnNuevoGasto.Text = "Registrar";
            btnNuevoGasto.Click += btnNuevoGasto_Click;
            // 
            // panelLista
            // 
            panelLista.Controls.Add(dgvGastos);
            panelLista.Dock = DockStyle.Fill;
            panelLista.Location = new Point(0, 200);
            panelLista.Name = "panelLista";
            panelLista.Padding = new Padding(10);
            panelLista.Size = new Size(900, 360);
            panelLista.TabIndex = 0;
            // 
            // dgvGastos
            // 
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.AllowUserToDeleteRows = false;
            dgvGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGastos.ColumnHeadersHeight = 29;
            dgvGastos.Columns.AddRange(new DataGridViewColumn[] { colId, colDescripcion, colMonto, colCategoria, colTarea, colFechaHora, colUsuario });
            dgvGastos.Dock = DockStyle.Fill;
            dgvGastos.Location = new Point(10, 10);
            dgvGastos.Name = "dgvGastos";
            dgvGastos.ReadOnly = true;
            dgvGastos.RowHeadersWidth = 51;
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.Size = new Size(880, 340);
            dgvGastos.TabIndex = 0;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colDescripcion
            // 
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.MinimumWidth = 6;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colMonto
            // 
            colMonto.HeaderText = "Monto";
            colMonto.MinimumWidth = 6;
            colMonto.Name = "colMonto";
            colMonto.ReadOnly = true;
            // 
            // colCategoria
            // 
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 6;
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            // 
            // colTarea
            // 
            colTarea.HeaderText = "Tarea";
            colTarea.MinimumWidth = 6;
            colTarea.Name = "colTarea";
            colTarea.ReadOnly = true;
            // 
            // colFechaHora
            // 
            colFechaHora.HeaderText = "Fecha/Hora";
            colFechaHora.MinimumWidth = 6;
            colFechaHora.Name = "colFechaHora";
            colFechaHora.ReadOnly = true;
            // 
            // colUsuario
            // 
            colUsuario.HeaderText = "Usuario";
            colUsuario.MinimumWidth = 6;
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.LightGray;
            panelInferior.Controls.Add(lblContador);
            panelInferior.Controls.Add(lblTotal);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 560);
            panelInferior.Name = "panelInferior";
            panelInferior.Padding = new Padding(10);
            panelInferior.Size = new Size(900, 40);
            panelInferior.TabIndex = 3;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(10, 10);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(0, 20);
            lblContador.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(600, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 20);
            lblTotal.TabIndex = 1;
            // 
            // FormGastoNoAdmin
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(panelLista);
            Controls.Add(panelCreacion);
            Controls.Add(panelSuperior);
            Controls.Add(panelInferior);
            Name = "FormGastoNoAdmin";
            Text = "Gestión de Gastos";
            Load += FormGastoNoAdmin_Load;
            panelCreacion.ResumeLayout(false);
            panelCreacion.PerformLayout();
            panelLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }
    }
}