namespace Escritorio
{
    partial class FormTarea
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            dgvTarea = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descripcionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaHoraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            duracionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tareaBindingSource = new BindingSource(components);
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label6 = new Label();
            btnNuevo = new Button();
            txtNombre = new TextBox();
            label2 = new Label();
            btnModificar = new Button();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtDuracion = new TextBox();
            label8 = new Label();
            txtFechaHora = new DateTimePicker();
            txtEstado = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnEliminar = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            label7 = new Label();
            txtID = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTarea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tareaBindingSource).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvTarea, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.3504734F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.75237F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.8971634F));
            tableLayoutPanel1.Size = new Size(791, 491);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Enabled = false;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(791, 50);
            label1.TabIndex = 3;
            label1.Text = "Tareas";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvTarea
            // 
            dgvTarea.AutoGenerateColumns = false;
            dgvTarea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTarea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTarea.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, descripcionDataGridViewTextBoxColumn, fechaHoraDataGridViewTextBoxColumn, duracionDataGridViewTextBoxColumn, estadoDataGridViewTextBoxColumn });
            dgvTarea.DataSource = tareaBindingSource;
            dgvTarea.Dock = DockStyle.Fill;
            dgvTarea.Location = new Point(9, 58);
            dgvTarea.Margin = new Padding(9, 8, 9, 8);
            dgvTarea.Name = "dgvTarea";
            dgvTarea.RowHeadersWidth = 51;
            dgvTarea.Size = new Size(773, 238);
            dgvTarea.TabIndex = 4;
            dgvTarea.SelectionChanged += dgvTarea_SelectionChanged;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "ID";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            descripcionDataGridViewTextBoxColumn.MinimumWidth = 6;
            descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // fechaHoraDataGridViewTextBoxColumn
            // 
            fechaHoraDataGridViewTextBoxColumn.DataPropertyName = "FechaHora";
            fechaHoraDataGridViewTextBoxColumn.HeaderText = "FechaHora";
            fechaHoraDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechaHoraDataGridViewTextBoxColumn.Name = "fechaHoraDataGridViewTextBoxColumn";
            // 
            // duracionDataGridViewTextBoxColumn
            // 
            duracionDataGridViewTextBoxColumn.DataPropertyName = "Duracion";
            duracionDataGridViewTextBoxColumn.HeaderText = "Duracion";
            duracionDataGridViewTextBoxColumn.MinimumWidth = 6;
            duracionDataGridViewTextBoxColumn.Name = "duracionDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoDataGridViewTextBoxColumn.MinimumWidth = 6;
            estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            // 
            // tareaBindingSource
            // 
            tareaBindingSource.DataSource = typeof(Domain.Model.Tarea);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 304);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(791, 187);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tableLayoutPanel3.Controls.Add(label6, 0, 0);
            tableLayoutPanel3.Controls.Add(btnNuevo, 0, 7);
            tableLayoutPanel3.Controls.Add(txtNombre, 0, 2);
            tableLayoutPanel3.Controls.Add(label2, 0, 1);
            tableLayoutPanel3.Controls.Add(btnModificar, 2, 7);
            tableLayoutPanel3.Controls.Add(label3, 2, 1);
            tableLayoutPanel3.Controls.Add(txtDescripcion, 2, 2);
            tableLayoutPanel3.Controls.Add(label4, 0, 3);
            tableLayoutPanel3.Controls.Add(label5, 2, 3);
            tableLayoutPanel3.Controls.Add(txtDuracion, 2, 4);
            tableLayoutPanel3.Controls.Add(label8, 0, 5);
            tableLayoutPanel3.Controls.Add(txtFechaHora, 0, 4);
            tableLayoutPanel3.Controls.Add(txtEstado, 0, 6);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 8;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(553, 187);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(48, 21);
            label6.TabIndex = 12;
            label6.Text = "Tarea";
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnNuevo.Location = new Point(9, 155);
            btnNuevo.Margin = new Padding(9, 8, 9, 8);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(247, 58);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Cargar Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.Location = new Point(18, 38);
            txtNombre.Margin = new Padding(18, 2, 18, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(229, 23);
            txtNombre.TabIndex = 16;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(26, 21);
            label2.Margin = new Padding(26, 0, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(236, 15);
            label2.TabIndex = 17;
            label2.Text = "Nombre";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnModificar.Location = new Point(296, 155);
            btnModificar.Margin = new Padding(9, 8, 9, 8);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(248, 58);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(313, 21);
            label3.Margin = new Padding(26, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(237, 15);
            label3.TabIndex = 18;
            label3.Text = "Descripción";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.Location = new Point(287, 38);
            txtDescripcion.Margin = new Padding(0, 2, 35, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(231, 23);
            txtDescripcion.TabIndex = 19;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(26, 63);
            label4.Margin = new Padding(26, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(236, 15);
            label4.TabIndex = 20;
            label4.Text = "Fecha y Hora";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(313, 63);
            label5.Margin = new Padding(26, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(237, 15);
            label5.TabIndex = 22;
            label5.Text = "Duración (Hs)";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtDuracion
            // 
            txtDuracion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDuracion.Location = new Point(287, 80);
            txtDuracion.Margin = new Padding(0, 2, 35, 2);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(231, 23);
            txtDuracion.TabIndex = 23;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(26, 105);
            label8.Margin = new Padding(26, 0, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(236, 15);
            label8.TabIndex = 24;
            label8.Text = "Estado";
            label8.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtFechaHora
            // 
            txtFechaHora.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFechaHora.Location = new Point(18, 80);
            txtFechaHora.Margin = new Padding(18, 2, 18, 2);
            txtFechaHora.MinDate = new DateTime(2025, 9, 24, 0, 0, 0, 0);
            txtFechaHora.Name = "txtFechaHora";
            txtFechaHora.Size = new Size(229, 23);
            txtFechaHora.TabIndex = 25;
            // 
            // txtEstado
            // 
            txtEstado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtEstado.FormattingEnabled = true;
            txtEstado.Items.AddRange(new object[] { "Activo", "Suspendido" });
            txtEstado.Location = new Point(18, 122);
            txtEstado.Margin = new Padding(18, 2, 18, 2);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(229, 23);
            txtEstado.TabIndex = 26;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(btnEliminar, 0, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(553, 0);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 18.4F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 81.6F));
            tableLayoutPanel4.Size = new Size(238, 187);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnEliminar.Location = new Point(9, 42);
            btnEliminar.Margin = new Padding(9, 8, 9, 8);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(220, 137);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar Tarea";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(label7, 0, 0);
            tableLayoutPanel5.Controls.Add(txtID, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 2);
            tableLayoutPanel5.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(232, 30);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(89, 0);
            label7.Name = "label7";
            label7.Size = new Size(24, 15);
            label7.TabIndex = 15;
            label7.Text = "ID: ";
            // 
            // txtID
            // 
            txtID.AutoSize = true;
            txtID.Location = new Point(119, 0);
            txtID.Name = "txtID";
            txtID.Size = new Size(0, 15);
            txtID.TabIndex = 16;
            // 
            // FormTarea
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(791, 491);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTarea";
            Text = "FormTarea";
            Load += FormTarea_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTarea).EndInit();
            ((System.ComponentModel.ISupportInitialize)tareaBindingSource).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private DataGridView dgvTarea;
        private BindingSource tareaBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaHoraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn duracionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnEliminar;
        private Button btnNuevo;
        private Button btnModificar;
        private Label label6;
        private Label label7;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label4;
        private Label label5;
        private TextBox txtDuracion;
        private Label label8;
        private DateTimePicker txtFechaHora;
        private ComboBox txtEstado;
        private TableLayoutPanel tableLayoutPanel5;
        private Label txtID;
    }
}