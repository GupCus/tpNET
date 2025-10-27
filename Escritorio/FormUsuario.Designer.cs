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
            label1.Name = "label1";
            label1.Size = new Size(800, 73);
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
            dgvUsuario.Location = new Point(-3, 66);
            dgvUsuario.Name = "dgvUsuario";
            dgvUsuario.RowHeadersWidth = 51;
            dgvUsuario.Size = new Size(802, 239);
            dgvUsuario.TabIndex = 12;
            dgvUsuario.SelectionChanged += dgvUsuario_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(164, 0);
            label2.Name = "label2";
            label2.Size = new Size(155, 26);
            label2.TabIndex = 6;
            label2.Text = "Mail";
            // 
            // txtMail
            // 
            txtMail.Dock = DockStyle.Fill;
            txtMail.Location = new Point(164, 29);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(155, 23);
            txtMail.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(325, 0);
            label4.Name = "label4";
            label4.Size = new Size(162, 26);
            label4.TabIndex = 8;
            label4.Text = "Contraseña";
            // 
            // Editar
            // 
            Editar.Dock = DockStyle.Fill;
            Editar.Location = new Point(164, 77);
            Editar.Name = "Editar";
            Editar.Size = new Size(155, 48);
            Editar.TabIndex = 4;
            Editar.Text = "Editar usuario";
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // Nuevo
            // 
            Nuevo.Dock = DockStyle.Fill;
            Nuevo.Location = new Point(3, 77);
            Nuevo.Name = "Nuevo";
            Nuevo.Size = new Size(155, 48);
            Nuevo.TabIndex = 5;
            Nuevo.Text = "Cargar usuario";
            Nuevo.UseVisualStyleBackColor = true;
            Nuevo.Click += Nuevo_Click;
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Location = new Point(3, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(155, 23);
            txtNombre.TabIndex = 2;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 26);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 168F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 242F));
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
            tableLayoutPanel1.Location = new Point(0, 304);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tableLayoutPanel1.Size = new Size(794, 128);
            tableLayoutPanel1.TabIndex = 12;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(493, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 26);
            label5.TabIndex = 32;
            label5.Text = "ID";
            // 
            // Eliminar
            // 
            Eliminar.Dock = DockStyle.Fill;
            Eliminar.Location = new Point(555, 29);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(236, 42);
            Eliminar.TabIndex = 31;
            Eliminar.Text = "Eliminar usuario";
            Eliminar.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            txtID.Dock = DockStyle.Fill;
            txtID.Enabled = false;
            txtID.Location = new Point(555, 3);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(236, 23);
            txtID.TabIndex = 29;
            // 
            // Cancelar
            // 
            Cancelar.Dock = DockStyle.Fill;
            Cancelar.Location = new Point(555, 77);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(236, 48);
            Cancelar.TabIndex = 27;
            Cancelar.Text = "Cancelar ";
            Cancelar.UseVisualStyleBackColor = true;
            // 
            // txtContraseña
            // 
            txtContraseña.Dock = DockStyle.Fill;
            txtContraseña.Location = new Point(325, 29);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(162, 23);
            txtContraseña.TabIndex = 13;
            // 
            // comRol
            // 
            comRol.FormattingEnabled = true;
            comRol.Location = new Point(324, 76);
            comRol.Margin = new Padding(2, 2, 2, 2);
            comRol.Name = "comRol";
            comRol.Size = new Size(163, 23);
            comRol.TabIndex = 33;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dgvUsuario);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
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