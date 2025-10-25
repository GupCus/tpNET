namespace Escritorio
{
    partial class FormCategoriaGastos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            categoriaGastoBindingSource = new BindingSource(components);
            Cargar = new Button();
            label1 = new Label();
            label2 = new Label();
            txtTipo = new TextBox();
            txtDescripcion = new TextBox();
            label3 = new Label();
            label6 = new Label();
            Modificar = new Button();
            label7 = new Label();
            Eliminar = new Button();
            dgvCategoria = new DataGridView();
            txtID = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)categoriaGastoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategoria).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // Cargar
            // 
            Cargar.Dock = DockStyle.Fill;
            Cargar.Location = new Point(3, 82);
            Cargar.Margin = new Padding(3, 2, 3, 2);
            Cargar.Name = "Cargar";
            Cargar.Size = new Size(268, 29);
            Cargar.TabIndex = 1;
            Cargar.Text = "Cargar Nuevo";
            Cargar.UseVisualStyleBackColor = true;
            Cargar.Click += Cargar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(205, 3);
            label1.Name = "label1";
            label1.Size = new Size(274, 46);
            label1.TabIndex = 2;
            label1.Text = "Categoria Gastos";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(268, 29);
            label2.TabIndex = 3;
            label2.Text = "Tipo";
            // 
            // txtTipo
            // 
            txtTipo.Dock = DockStyle.Fill;
            txtTipo.Location = new Point(3, 31);
            txtTipo.Margin = new Padding(3, 2, 3, 2);
            txtTipo.Name = "txtTipo";
            txtTipo.PlaceholderText = "Tipo";
            txtTipo.Size = new Size(268, 23);
            txtTipo.TabIndex = 4;
            txtTipo.DoubleClick += Txt_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Fill;
            txtDescripcion.Location = new Point(277, 31);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Descripción";
            txtDescripcion.Size = new Size(268, 23);
            txtDescripcion.TabIndex = 6;
            txtDescripcion.DoubleClick += Txt_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(277, 0);
            label3.Name = "label3";
            label3.Size = new Size(268, 29);
            label3.TabIndex = 5;
            label3.Text = "Descripción";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(10, 232);
            label6.Name = "label6";
            label6.Size = new Size(81, 21);
            label6.TabIndex = 11;
            label6.Text = "Categoría";
            label6.TextAlign = ContentAlignment.BottomLeft;
            // 
            // Modificar
            // 
            Modificar.Dock = DockStyle.Fill;
            Modificar.Enabled = false;
            Modificar.Location = new Point(277, 82);
            Modificar.Margin = new Padding(3, 2, 3, 2);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(268, 29);
            Modificar.TabIndex = 13;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Modificar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(551, 0);
            label7.Name = "label7";
            label7.Size = new Size(103, 29);
            label7.TabIndex = 14;
            label7.Text = "ID: ";
            // 
            // Eliminar
            // 
            Eliminar.BackColor = Color.White;
            Eliminar.Dock = DockStyle.Fill;
            Eliminar.Enabled = false;
            Eliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Eliminar.ForeColor = SystemColors.MenuText;
            Eliminar.Location = new Point(551, 31);
            Eliminar.Margin = new Padding(3, 2, 3, 2);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(103, 47);
            Eliminar.TabIndex = 15;
            Eliminar.Text = "ELIMINAR CATEGORÍA";
            Eliminar.UseVisualStyleBackColor = false;
            Eliminar.Click += Eliminar_Click;
            // 
            // dgvCategoria
            // 
            dgvCategoria.AllowUserToOrderColumns = true;
            dgvCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategoria.AutoGenerateColumns = false;
            dgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategoria.DataSource = categoriaGastoBindingSource;
            dgvCategoria.Location = new Point(10, 51);
            dgvCategoria.Margin = new Padding(3, 2, 3, 2);
            dgvCategoria.Name = "dgvCategoria";
            dgvCategoria.ReadOnly = true;
            dgvCategoria.RowHeadersWidth = 51;
            dgvCategoria.Size = new Size(710, 179);
            dgvCategoria.TabIndex = 0;
            dgvCategoria.SelectionChanged += dgvCategoria_SelectionChanged;
            // 
            // txtID
            // 
            txtID.AutoSize = true;
            txtID.Location = new Point(584, 256);
            txtID.Name = "txtID";
            txtID.Size = new Size(0, 15);
            txtID.TabIndex = 17;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 109F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(Eliminar, 2, 1);
            tableLayoutPanel1.Controls.Add(txtDescripcion, 1, 1);
            tableLayoutPanel1.Controls.Add(label7, 2, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 0);
            tableLayoutPanel1.Controls.Add(Modificar, 1, 2);
            tableLayoutPanel1.Controls.Add(Cargar, 0, 2);
            tableLayoutPanel1.Controls.Add(txtTipo, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 256);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35.9375F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 64.0625F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.Size = new Size(732, 113);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // FormCategoriaGastos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 369);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(txtID);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(dgvCategoria);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCategoriaGastos";
            Text = "Gestión API";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)categoriaGastoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategoria).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Cargar;
        private Label label1;
        private Label label2;
        private TextBox txtTipo;
        private TextBox txtDescripcion;
        private Label label3;
        private Label label6;
        private Button Modificar;
        private Label label7;
        private Button Eliminar;
        private BindingSource categoriaGastoBindingSource;
        private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridView dgvCategoria;
        private Label txtID;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
