namespace Escritorio
{
    partial class FormUsuario
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
            label1 = new Label();
            dgvUsuario = new DataGridView();
            label2 = new Label();
            txtMail = new TextBox();
            label4 = new Label();
            Editar = new Button();
            Nuevo = new Button();
            txtNombre = new TextBox();
            label3 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label5 = new Label();
            Eliminar = new Button();
            txtID = new TextBox();
            Cancelar = new Button();
            txtContraseña = new TextBox();
            comRol = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(1000, 91);
            label1.TabIndex = 0;
            label1.Text = "Usuarios\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvUsuario
            // 
            dgvUsuario.AllowUserToOrderColumns = true;
            dgvUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuario.Location = new Point(-4, 82);
            dgvUsuario.Margin = new Padding(4);
            dgvUsuario.Name = "dgvUsuario";
            dgvUsuario.RowHeadersWidth = 51;
            dgvUsuario.Size = new Size(1002, 299);
            dgvUsuario.TabIndex = 12;
            dgvUsuario.SelectionChanged += dgvUsuario_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(205, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(193, 32);
            label2.TabIndex = 6;
            label2.Text = "Mail";
            // 
            // txtMail
            // 
            txtMail.Dock = DockStyle.Fill;
            txtMail.Location = new Point(205, 36);
            txtMail.Margin = new Padding(4);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(193, 27);
            txtMail.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(406, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(202, 32);
            label4.TabIndex = 8;
            label4.Text = "Contraseña";
            // 
            // Editar
            // 
            Editar.Dock = DockStyle.Fill;
            Editar.Location = new Point(205, 96);
            Editar.Margin = new Padding(4);
            Editar.Name = "Editar";
            Editar.Size = new Size(193, 60);
            Editar.TabIndex = 4;
            Editar.Text = "Editar usuario";
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // Nuevo
            // 
            Nuevo.Dock = DockStyle.Fill;
            Nuevo.Location = new Point(4, 96);
            Nuevo.Margin = new Padding(4);
            Nuevo.Name = "Nuevo";
            Nuevo.Size = new Size(193, 60);
            Nuevo.TabIndex = 5;
            Nuevo.Text = "Cargar usuario";
            Nuevo.UseVisualStyleBackColor = true;
            Nuevo.Click += Nuevo_Click;
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Location = new Point(4, 36);
            txtNombre.Margin = new Padding(4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(193, 27);
            txtNombre.TabIndex = 2;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(4, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(193, 32);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 302F));
            tableLayoutPanel1.Controls.Add(label5, 3, 0);
            tableLayoutPanel1.Controls.Add(Eliminar, 4, 1);
            tableLayoutPanel1.Controls.Add(txtID, 4, 0);
            tableLayoutPanel1.Controls.Add(Cancelar, 4, 2);
            tableLayoutPanel1.Controls.Add(txtContraseña, 2, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNombre, 0, 1);
            tableLayoutPanel1.Controls.Add(Nuevo, 0, 2);
            tableLayoutPanel1.Controls.Add(Editar, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(txtMail, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 0);
            tableLayoutPanel1.Controls.Add(comRol, 2, 2);
            tableLayoutPanel1.Location = new Point(0, 380);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            tableLayoutPanel1.Size = new Size(992, 160);
            tableLayoutPanel1.TabIndex = 12;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(616, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(70, 32);
            label5.TabIndex = 32;
            label5.Text = "ID";
            // 
            // Eliminar
            // 
            Eliminar.Dock = DockStyle.Fill;
            Eliminar.Location = new Point(694, 36);
            Eliminar.Margin = new Padding(4);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(294, 52);
            Eliminar.TabIndex = 31;
            Eliminar.Text = "Eliminar usuario";
            Eliminar.UseVisualStyleBackColor = true;
            Eliminar.Click += Eliminar_Click;
            // 
            // txtID
            // 
            txtID.Dock = DockStyle.Fill;
            txtID.Enabled = false;
            txtID.Location = new Point(694, 4);
            txtID.Margin = new Padding(4);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(294, 27);
            txtID.TabIndex = 29;
            // 
            // Cancelar
            // 
            Cancelar.Dock = DockStyle.Fill;
            Cancelar.Location = new Point(694, 96);
            Cancelar.Margin = new Padding(4);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(294, 60);
            Cancelar.TabIndex = 27;
            Cancelar.Text = "Cancelar ";
            Cancelar.UseVisualStyleBackColor = true;
            // 
            // txtContraseña
            // 
            txtContraseña.Dock = DockStyle.Fill;
            txtContraseña.Location = new Point(406, 36);
            txtContraseña.Margin = new Padding(4);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(202, 27);
            txtContraseña.TabIndex = 13;
            // 
            // comRol
            // 
            comRol.FormattingEnabled = true;
            comRol.Location = new Point(404, 94);
            comRol.Margin = new Padding(2);
            comRol.Name = "comRol";
            comRol.Size = new Size(203, 28);
            comRol.TabIndex = 33;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1000, 562);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dgvUsuario);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormUsuario";
            Text = "FormUsuario";
            Load += FormUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView dgvUsuario;
        private Label label2;
        private TextBox txtMail;
        private Label label4;
        private Button Editar;
        private Button Nuevo;
        private TextBox txtNombre;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtContraseña;
        private TextBox txtID;
        private Button Cancelar;
        private Label label5;
        private Button Eliminar;
        private ComboBox comRol;
    }
}