using System;
using System.Drawing;
using System.Windows.Forms;

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
        private Label lblContador;
        private Button btnActualizar;
        private Panel panelCreacion;
        private Panel panelLista;
        private Panel panelSuperior;
        private Panel panelInferior;
        private Label lblTituloCreacion;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblFechaInicio;
        private Label lblFechaFin;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colFechaInicio;
        private DataGridViewTextBoxColumn colFechaFin;

        private void InitializeComponent()
        {
            panelSuperior = new Panel();
            btnActualizar = new Button();
            panelCreacion = new Panel();
            lblTituloCreacion = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            btnNuevoPlan = new Button();
            panelLista = new Panel();
            dgvPlanes = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colFechaInicio = new DataGridViewTextBoxColumn();
            colFechaFin = new DataGridViewTextBoxColumn();
            panelInferior = new Panel();
            lblContador = new Label();
            panelSuperior.SuspendLayout();
            panelCreacion.SuspendLayout();
            panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.LightGray;
            panelSuperior.Controls.Add(btnActualizar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Padding = new Padding(10);
            panelSuperior.Size = new Size(900, 60);
            panelSuperior.TabIndex = 2;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(8, 16);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(90, 28);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // panelCreacion
            // 
            panelCreacion.BackColor = Color.LightGreen;
            panelCreacion.Controls.Add(lblTituloCreacion);
            panelCreacion.Controls.Add(lblNombre);
            panelCreacion.Controls.Add(txtNombre);
            panelCreacion.Controls.Add(lblDescripcion);
            panelCreacion.Controls.Add(txtDescripcion);
            panelCreacion.Controls.Add(lblFechaInicio);
            panelCreacion.Controls.Add(dtpFechaInicio);
            panelCreacion.Controls.Add(lblFechaFin);
            panelCreacion.Controls.Add(dtpFechaFin);
            panelCreacion.Controls.Add(btnNuevoPlan);
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
            lblTituloCreacion.Size = new Size(122, 23);
            lblTituloCreacion.TabIndex = 0;
            lblTituloCreacion.Text = "Registrar Plan";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(10, 40);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(74, 23);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(110, 38);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 27);
            txtNombre.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(10, 75);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(91, 23);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(110, 71);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(420, 27);
            txtDescripcion.TabIndex = 4;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.Location = new Point(10, 104);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(90, 23);
            lblFechaInicio.TabIndex = 5;
            lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(110, 100);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(160, 27);
            dtpFechaInicio.TabIndex = 6;
            // 
            // lblFechaFin
            // 
            lblFechaFin.Location = new Point(290, 104);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(70, 23);
            lblFechaFin.TabIndex = 7;
            lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(360, 100);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(170, 27);
            dtpFechaFin.TabIndex = 8;
            // 
            // btnNuevoPlan
            // 
            btnNuevoPlan.Location = new Point(540, 98);
            btnNuevoPlan.Name = "btnNuevoPlan";
            btnNuevoPlan.Size = new Size(100, 30);
            btnNuevoPlan.TabIndex = 9;
            btnNuevoPlan.Text = "Guardar";
            btnNuevoPlan.Click += btnNuevoPlan_Click;
            // 
            // panelLista
            // 
            panelLista.Controls.Add(dgvPlanes);
            panelLista.Dock = DockStyle.Fill;
            panelLista.Location = new Point(0, 200);
            panelLista.Name = "panelLista";
            panelLista.Padding = new Padding(10);
            panelLista.Size = new Size(900, 360);
            panelLista.TabIndex = 0;
            // 
            // dgvPlanes
            // 
            dgvPlanes.AllowUserToAddRows = false;
            dgvPlanes.AllowUserToDeleteRows = false;
            dgvPlanes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlanes.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colDescripcion, colFechaInicio, colFechaFin });
            dgvPlanes.Dock = DockStyle.Fill;
            dgvPlanes.Location = new Point(10, 10);
            dgvPlanes.Name = "dgvPlanes";
            dgvPlanes.ReadOnly = true;
            dgvPlanes.RowHeadersWidth = 51;
            dgvPlanes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlanes.Size = new Size(880, 340);
            dgvPlanes.TabIndex = 0;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.MinimumWidth = 6;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colFechaInicio
            // 
            colFechaInicio.HeaderText = "Fecha Inicio";
            colFechaInicio.MinimumWidth = 6;
            colFechaInicio.Name = "colFechaInicio";
            colFechaInicio.ReadOnly = true;
            // 
            // colFechaFin
            // 
            colFechaFin.HeaderText = "Fecha Fin";
            colFechaFin.MinimumWidth = 6;
            colFechaFin.Name = "colFechaFin";
            colFechaFin.ReadOnly = true;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.LightGray;
            panelInferior.Controls.Add(lblContador);
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
            // FormPlanNoAdmin
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(panelLista);
            Controls.Add(panelCreacion);
            Controls.Add(panelSuperior);
            Controls.Add(panelInferior);
            Name = "FormPlanNoAdmin";
            Text = "Gestión de Planes";
            Load += FormPlanNoAdmin_Load;
            panelSuperior.ResumeLayout(false);
            panelCreacion.ResumeLayout(false);
            panelCreacion.PerformLayout();
            panelLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }
    }
}