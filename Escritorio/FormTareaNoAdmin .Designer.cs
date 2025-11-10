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
        private Button btnActualizar;
        private Label lblContador;
        private Panel panelCreacion;
        private Panel panelLista;
        private Panel panelSuperior;
        private Panel panelInferior;

        private Label lblTituloCreacion;
        private Label lblPlan;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblDuracion;
        private Label lblFechaHora;
        private Label lblEstado;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colFechaHora;
        private DataGridViewTextBoxColumn colDuracion;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colPlanId;

        private void InitializeComponent()
        {
            panelSuperior = new Panel();
            panelCreacion = new Panel();
            lblTituloCreacion = new Label();
            lblPlan = new Label();
            cmbPlan = new ComboBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblFechaHora = new Label();
            dtpFechaHora = new DateTimePicker();
            lblDuracion = new Label();
            txtDuracion = new TextBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnNuevaTarea = new Button();
            btnActualizar = new Button();
            panelLista = new Panel();
            dgvTareas = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colFechaHora = new DataGridViewTextBoxColumn();
            colDuracion = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colPlanId = new DataGridViewTextBoxColumn();
            panelInferior = new Panel();
            lblContador = new Label();

            panelCreacion.SuspendLayout();
            panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTareas).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();

            // panelSuperior
            panelSuperior.BackColor = Color.LightGray;
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Padding = new Padding(10);
            panelSuperior.Height = 60;
            panelSuperior.Name = "panelSuperior";

            // panelCreacion - similar style to FormGastoNoAdmin
            panelCreacion.BackColor = Color.LightGreen;
            panelCreacion.Dock = DockStyle.Top;
            panelCreacion.Padding = new Padding(10);
            panelCreacion.Height = 160;
            panelCreacion.Name = "panelCreacion";

            // lblTituloCreacion
            lblTituloCreacion.AutoSize = true;
            lblTituloCreacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloCreacion.Location = new Point(10, 8);
            lblTituloCreacion.Name = "lblTituloCreacion";
            lblTituloCreacion.Text = "Crear Nueva Tarea";

            // lblPlan + cmbPlan
            lblPlan.Location = new Point(10, 40);
            lblPlan.Size = new Size(60, 23);
            lblPlan.Text = "Plan:";
            lblPlan.Name = "lblPlan";

            cmbPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlan.Location = new Point(80, 38);
            cmbPlan.Size = new Size(220, 28);
            cmbPlan.Name = "cmbPlan";

            // lblNombre + txtNombre
            lblNombre.Location = new Point(320, 40);
            lblNombre.Size = new Size(70, 23);
            lblNombre.Text = "Nombre:";
            lblNombre.Name = "lblNombre";

            txtNombre.Location = new Point(400, 38);
            txtNombre.Size = new Size(260, 28);
            txtNombre.Name = "txtNombre";

            // lblDescripcion + txtDescripcion
            lblDescripcion.Location = new Point(10, 76);
            lblDescripcion.Size = new Size(90, 23);
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Name = "lblDescripcion";

            txtDescripcion.Location = new Point(100, 74);
            txtDescripcion.Size = new Size(560, 28);
            txtDescripcion.Name = "txtDescripcion";

            // lblFechaHora + dtpFechaHora
            lblFechaHora.Location = new Point(10, 112);
            lblFechaHora.Size = new Size(90, 23);
            lblFechaHora.Text = "Fecha/Hora:";
            lblFechaHora.Name = "lblFechaHora";

            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaHora.ShowUpDown = true;
            dtpFechaHora.Location = new Point(100, 110);
            dtpFechaHora.Size = new Size(160, 28);
            dtpFechaHora.Name = "dtpFechaHora";

            // lblDuracion + txtDuracion
            lblDuracion.Location = new Point(280, 112);
            lblDuracion.Size = new Size(110, 23);
            lblDuracion.Text = "Duración (min):";
            lblDuracion.Name = "lblDuracion";

            txtDuracion.Location = new Point(390, 110);
            txtDuracion.Size = new Size(80, 28);
            txtDuracion.Name = "txtDuracion";

            // lblEstado + cmbEstado
            lblEstado.Location = new Point(490, 112);
            lblEstado.Size = new Size(60, 23);
            lblEstado.Text = "Estado:";
            lblEstado.Name = "lblEstado";

            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Location = new Point(555, 110);
            cmbEstado.Size = new Size(140, 28);
            cmbEstado.Name = "cmbEstado";

            // btnNuevaTarea
            btnNuevaTarea.Location = new Point(710, 108);
            btnNuevaTarea.Size = new Size(100, 30);
            btnNuevaTarea.Text = "Crear Tarea";
            btnNuevaTarea.Name = "btnNuevaTarea";

            panelCreacion.Controls.AddRange(new Control[] {
                lblTituloCreacion,
                lblPlan, cmbPlan,
                lblNombre, txtNombre,
                lblDescripcion, txtDescripcion,
                lblFechaHora, dtpFechaHora,
                lblDuracion, txtDuracion,
                lblEstado, cmbEstado,
                btnNuevaTarea
            });

            // panelLista + dgvTareas (fill area)
            panelLista.Dock = DockStyle.Fill;
            panelLista.Padding = new Padding(10);
            panelLista.Name = "panelLista";

            dgvTareas.Dock = DockStyle.Fill;
            dgvTareas.ReadOnly = true;
            dgvTareas.AllowUserToAddRows = false;
            dgvTareas.AllowUserToDeleteRows = false;
            dgvTareas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTareas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTareas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTareas.Name = "dgvTareas";

            // Define columns (like other forms)
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;

            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;

            colDescripcion.HeaderText = "Descripción";
            colDescripcion.MinimumWidth = 6;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;

            colFechaHora.HeaderText = "Fecha/Hora";
            colFechaHora.MinimumWidth = 6;
            colFechaHora.Name = "colFechaHora";
            colFechaHora.ReadOnly = true;

            colDuracion.HeaderText = "Duración";
            colDuracion.MinimumWidth = 6;
            colDuracion.Name = "colDuracion";
            colDuracion.ReadOnly = true;

            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;

            colPlanId.HeaderText = "Plan ID";
            colPlanId.MinimumWidth = 6;
            colPlanId.Name = "colPlanId";
            colPlanId.ReadOnly = true;
            colPlanId.Visible = false; // hide PlanId by default

            dgvTareas.Columns.AddRange(new DataGridViewColumn[] {
                colId, colNombre, colDescripcion, colFechaHora, colDuracion, colEstado, colPlanId
            });

            panelLista.Controls.Add(dgvTareas);

            // panelInferior - contador
            panelInferior.BackColor = Color.LightGray;
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Padding = new Padding(10);
            panelInferior.Height = 40;
            panelInferior.Name = "panelInferior";

            lblContador.AutoSize = true;
            lblContador.Location = new Point(10, 10);
            lblContador.Name = "lblContador";
            lblContador.Text = "0 tareas";

            panelInferior.Controls.Add(lblContador);

            // Add panels to form (order: list, creation, superior, inferior)
            Controls.Add(panelLista);
            Controls.Add(panelCreacion);
            Controls.Add(panelSuperior);
            Controls.Add(panelInferior);

            // Events
            Load += FormTareaNoAdmin_Load;
            btnNuevaTarea.Click += btnNuevaTarea_Click;
            dgvTareas.CellDoubleClick += dgvTareas_CellDoubleClick;

            // Final form settings
            ClientSize = new Size(900, 600);
            Name = "FormTareaNoAdmin";
            Text = "Gestión de Tareas";

            panelCreacion.ResumeLayout(false);
            panelCreacion.PerformLayout();
            panelLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTareas).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }
    }
}