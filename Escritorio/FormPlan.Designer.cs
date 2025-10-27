namespace Escritorio
{
    partial class FormPlan
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtFechaDesde = new DateTimePicker();
            txtFechaHasta = new DateTimePicker();
            lblDescripcion = new Label();
            lblNombre = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblID = new Label();
            txtID = new TextBox();
            lblFechaDesde = new Label();
            lblFechaHasta = new Label();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblGrupo = new Label();
            cmbGrupo = new ComboBox();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(794, 268);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(366, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 37);
            label1.TabIndex = 1;
            label1.Text = "Plan";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.Location = new Point(112, 3);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(265, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.Location = new Point(112, 45);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(265, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // txtFechaDesde
            // 
            txtFechaDesde.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFechaDesde.Location = new Point(460, 3);
            txtFechaDesde.Name = "txtFechaDesde";
            txtFechaDesde.Size = new Size(222, 23);
            txtFechaDesde.TabIndex = 3;
            txtFechaDesde.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtFechaHasta
            // 
            txtFechaHasta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFechaHasta.Location = new Point(460, 45);
            txtFechaHasta.Name = "txtFechaHasta";
            txtFechaHasta.Size = new Size(222, 23);
            txtFechaHasta.TabIndex = 3;
            txtFechaHasta.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(3, 49);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(103, 15);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripcion";
            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(3, 7);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(103, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            lblNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 271F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 228F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblNombre, 0, 0);
            tableLayoutPanel1.Controls.Add(lblDescripcion, 0, 1);
            tableLayoutPanel1.Controls.Add(txtNombre, 1, 0);
            tableLayoutPanel1.Controls.Add(txtFechaHasta, 3, 1);
            tableLayoutPanel1.Controls.Add(txtDescripcion, 1, 1);
            tableLayoutPanel1.Controls.Add(txtFechaDesde, 3, 0);
            tableLayoutPanel1.Controls.Add(lblID, 0, 2);
            tableLayoutPanel1.Controls.Add(txtID, 1, 2);
            tableLayoutPanel1.Controls.Add(lblFechaDesde, 2, 0);
            tableLayoutPanel1.Controls.Add(lblFechaHasta, 2, 1);
            tableLayoutPanel1.Controls.Add(btnAgregar, 4, 0);
            tableLayoutPanel1.Controls.Add(btnEditar, 4, 1);
            tableLayoutPanel1.Controls.Add(btnEliminar, 4, 2);
            tableLayoutPanel1.Controls.Add(lblGrupo, 0, 3);
            tableLayoutPanel1.Controls.Add(cmbGrupo, 1, 3);
            tableLayoutPanel1.Controls.Add(btnLimpiar, 4, 3);
            tableLayoutPanel1.Location = new Point(3, 333);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(794, 114);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // lblID
            // 
            lblID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblID.AutoSize = true;
            lblID.Location = new Point(3, 61);
            lblID.Name = "lblID";
            lblID.Size = new Size(103, 15);
            lblID.TabIndex = 5;
            lblID.Text = "ID";
            lblID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtID.Enabled = false;
            txtID.Location = new Point(112, 57);
            txtID.Name = "txtID";
            txtID.Size = new Size(265, 23);
            txtID.TabIndex = 6;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Location = new Point(383, 0);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(71, 28);
            lblFechaDesde.TabIndex = 7;
            lblFechaDesde.Text = "Fecha desde";
            lblFechaDesde.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(383, 28);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(71, 28);
            lblFechaHasta.TabIndex = 8;
            lblFechaHasta.Text = "Fecha hasta";
            lblFechaHasta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnAgregar.Location = new Point(688, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(103, 22);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnEditar.Location = new Point(688, 31);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(103, 22);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnEliminar.Location = new Point(688, 59);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(103, 22);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 2);
            tableLayoutPanel2.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 60.88889F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 26.88889F));
            tableLayoutPanel2.Size = new Size(800, 450);
            tableLayoutPanel2.TabIndex = 6;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // lblGrupo
            // 
            lblGrupo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblGrupo.AutoSize = true;
            lblGrupo.Location = new Point(3, 91);
            lblGrupo.Name = "lblGrupo";
            lblGrupo.Size = new Size(103, 15);
            lblGrupo.TabIndex = 12;
            lblGrupo.Text = "Grupo";
            lblGrupo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbGrupo
            // 
            cmbGrupo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbGrupo.FormattingEnabled = true;
            cmbGrupo.Location = new Point(112, 87);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(265, 23);
            cmbGrupo.TabIndex = 13;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiar.Location = new Point(688, 87);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(103, 23);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // FormPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(tableLayoutPanel2);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPlan";
            Text = "FormPlan";
            Load += FormPlan_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private DateTimePicker txtFechaDesde;
        private DateTimePicker txtFechaHasta;
        private Label lblDescripcion;
        private Label lblNombre;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblID;
        private TextBox txtID;
        private Label lblFechaDesde;
        private Label lblFechaHasta;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblGrupo;
        private ComboBox cmbGrupo;
        private Button btnLimpiar;
    }
}