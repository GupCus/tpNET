namespace Escritorio
{
    partial class FormGasto
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
            dgvGasto = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descripcionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaHoraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            montoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gastoBindingSource = new BindingSource(components);
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label6 = new Label();
            btnNuevo = new Button();
            btnModificar = new Button();
            label4 = new Label();
            label3 = new Label();
            txtMonto = new TextBox();
            txtDescripcion = new TextBox();
            label2 = new Label();
            label5 = new Label();
            txtFechaHora = new DateTimePicker();
            cmbCategoria = new ComboBox();
            label8 = new Label();
            cmbUsuario = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnEliminar = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            label7 = new Label();
            txtID = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGasto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gastoBindingSource).BeginInit();
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
            tableLayoutPanel1.Controls.Add(dgvGasto, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.3504734F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.75237F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.8971634F));
            tableLayoutPanel1.Size = new Size(989, 614);
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
            label1.Size = new Size(989, 63);
            label1.TabIndex = 3;
            label1.Text = "Gastos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvGasto
            // 
            dgvGasto.AutoGenerateColumns = false;
            dgvGasto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGasto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGasto.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, descripcionDataGridViewTextBoxColumn, fechaHoraDataGridViewTextBoxColumn, montoDataGridViewTextBoxColumn });
            dgvGasto.DataSource = gastoBindingSource;
            dgvGasto.Dock = DockStyle.Fill;
            dgvGasto.Location = new Point(11, 73);
            dgvGasto.Margin = new Padding(11, 10, 11, 10);
            dgvGasto.Name = "dgvGasto";
            dgvGasto.RowHeadersWidth = 51;
            dgvGasto.Size = new Size(967, 297);
            dgvGasto.TabIndex = 4;
            dgvGasto.SelectionChanged += dgvGasto_SelectionChanged;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "ID";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            descripcionDataGridViewTextBoxColumn.MinimumWidth = 6;
            descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaHoraDataGridViewTextBoxColumn
            // 
            fechaHoraDataGridViewTextBoxColumn.DataPropertyName = "FechaHora";
            fechaHoraDataGridViewTextBoxColumn.HeaderText = "Fecha y Hora";
            fechaHoraDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechaHoraDataGridViewTextBoxColumn.Name = "fechaHoraDataGridViewTextBoxColumn";
            fechaHoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            montoDataGridViewTextBoxColumn.MinimumWidth = 6;
            montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            montoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gastoBindingSource
            // 
            gastoBindingSource.DataSource = typeof(Dominio.Gasto);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 380);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(989, 234);
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
            tableLayoutPanel3.Controls.Add(btnModificar, 2, 7);
            tableLayoutPanel3.Controls.Add(label4, 0, 1);
            tableLayoutPanel3.Controls.Add(label3, 2, 1);
            tableLayoutPanel3.Controls.Add(txtMonto, 0, 2);
            tableLayoutPanel3.Controls.Add(txtDescripcion, 2, 2);
            tableLayoutPanel3.Controls.Add(label2, 0, 3);
            tableLayoutPanel3.Controls.Add(label5, 2, 3);
            tableLayoutPanel3.Controls.Add(txtFechaHora, 0, 4);
            tableLayoutPanel3.Controls.Add(cmbCategoria, 2, 4);
            tableLayoutPanel3.Controls.Add(label8, 0, 5);
            tableLayoutPanel3.Controls.Add(cmbUsuario, 0, 6);
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
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(692, 234);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(4, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(64, 28);
            label6.TabIndex = 12;
            label6.Text = "Gasto";
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnNuevo.Location = new Point(11, 193);
            btnNuevo.Margin = new Padding(11, 10, 11, 10);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(310, 31);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Cargar Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnModificar.Location = new Point(370, 193);
            btnModificar.Margin = new Padding(11, 10, 11, 10);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(311, 31);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(32, 28);
            label4.Margin = new Padding(32, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(296, 20);
            label4.TabIndex = 20;
            label4.Text = "Monto";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(391, 28);
            label3.Margin = new Padding(32, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(297, 20);
            label3.TabIndex = 18;
            label3.Text = "Descripción";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtMonto
            // 
            txtMonto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMonto.Location = new Point(22, 50);
            txtMonto.Margin = new Padding(22, 2, 22, 2);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(288, 27);
            txtMonto.TabIndex = 23;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.Location = new Point(359, 50);
            txtDescripcion.Margin = new Padding(0, 2, 44, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(289, 27);
            txtDescripcion.TabIndex = 19;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(32, 79);
            label2.Margin = new Padding(32, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(296, 20);
            label2.TabIndex = 17;
            label2.Text = "Fecha y Hora";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(391, 79);
            label5.Margin = new Padding(32, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(297, 20);
            label5.TabIndex = 22;
            label5.Text = "Categoría";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtFechaHora
            // 
            txtFechaHora.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFechaHora.Location = new Point(22, 101);
            txtFechaHora.Margin = new Padding(22, 2, 22, 2);
            txtFechaHora.MinDate = new DateTime(2025, 9, 24, 0, 0, 0, 0);
            txtFechaHora.Name = "txtFechaHora";
            txtFechaHora.Size = new Size(288, 27);
            txtFechaHora.TabIndex = 25;
            // 
            // cmbCategoria
            // 
            cmbCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(359, 101);
            cmbCategoria.Margin = new Padding(0, 2, 44, 2);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(289, 28);
            cmbCategoria.TabIndex = 26;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(32, 131);
            label8.Margin = new Padding(32, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(296, 20);
            label8.TabIndex = 28;
            label8.Text = "Usuario";
            label8.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cmbUsuario
            // 
            cmbUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(22, 153);
            cmbUsuario.Margin = new Padding(22, 2, 22, 2);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(288, 28);
            cmbUsuario.TabIndex = 27;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(btnEliminar, 0, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(692, 0);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 18.4F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 81.6F));
            tableLayoutPanel4.Size = new Size(297, 234);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnEliminar.Location = new Point(11, 53);
            btnEliminar.Margin = new Padding(11, 10, 11, 10);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(275, 171);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar Gasto";
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
            tableLayoutPanel5.Location = new Point(4, 2);
            tableLayoutPanel5.Margin = new Padding(4, 2, 4, 2);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(289, 39);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(109, 0);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(31, 20);
            label7.TabIndex = 15;
            label7.Text = "ID: ";
            // 
            // txtID
            // 
            txtID.AutoSize = true;
            txtID.Location = new Point(148, 0);
            txtID.Margin = new Padding(4, 0, 4, 0);
            txtID.Name = "txtID";
            txtID.Size = new Size(0, 20);
            txtID.TabIndex = 16;
            // 
            // FormGasto
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(989, 614);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 2, 4, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormGasto";
            Text = "FormGasto";
            Load += FormGasto_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGasto).EndInit();
            ((System.ComponentModel.ISupportInitialize)gastoBindingSource).EndInit();
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
        private DataGridView dgvGasto;
        private BindingSource gastoBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaHoraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaGastoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnEliminar;
        private Button btnNuevo;
        private Button btnModificar;
        private Label label6;
        private Label label7;
        private Label label2;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label4;
        private Label label5;
        private TextBox txtMonto;
        private DateTimePicker txtFechaHora;
        private TableLayoutPanel tableLayoutPanel5;
        private Label txtID;

        // NUEVAS DECLARACIONES AGREGADAS
        private ComboBox cmbCategoria;
        private ComboBox cmbUsuario;
        private Label label8; // Para la etiqueta de Usuario
    }
}