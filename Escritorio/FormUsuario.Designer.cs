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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            gruposBindingSource = new BindingSource(components);
            usuarioBindingSource = new BindingSource(components);
            dgvUsuario = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Mail = new DataGridViewTextBoxColumn();
            gruposBindingSource2 = new BindingSource(components);
            gruposBindingSource1 = new BindingSource(components);
            label2 = new Label();
            txtMail = new TextBox();
            label4 = new Label();
            Editar = new Button();
            Nuevo = new Button();
            txtID = new TextBox();
            Eliminar = new Button();
            txtNombre = new TextBox();
            Cancelar = new Button();
            label3 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource1).BeginInit();
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
            // gruposBindingSource
            // 
            gruposBindingSource.DataMember = "Grupos";
            gruposBindingSource.DataSource = usuarioBindingSource;
            // 
            // usuarioBindingSource
            // 
            usuarioBindingSource.DataSource = typeof(Dominio.Usuario);
            // 
            // dgvUsuario
            // 
            dgvUsuario.AllowUserToOrderColumns = true;
            dgvUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuario.AutoGenerateColumns = false;
            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuario.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, Mail });
            dgvUsuario.DataSource = gruposBindingSource2;
            dgvUsuario.Location = new Point(-3, 66);
            dgvUsuario.Name = "dgvUsuario";
            dgvUsuario.Size = new Size(802, 239);
            dgvUsuario.TabIndex = 12;
            dgvUsuario.SelectionChanged += dgvUsuario_SelectionChanged;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // Mail
            // 
            Mail.DataPropertyName = "Mail";
            Mail.HeaderText = "Mail";
            Mail.Name = "Mail";
            // 
            // gruposBindingSource2
            // 
            gruposBindingSource2.DataMember = "Grupos";
            gruposBindingSource2.DataSource = usuarioBindingSource;
            // 
            // gruposBindingSource1
            // 
            gruposBindingSource1.DataMember = "Grupos";
            gruposBindingSource1.DataSource = usuarioBindingSource;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(224, 0);
            label2.Name = "label2";
            label2.Size = new Size(215, 28);
            label2.TabIndex = 6;
            label2.Text = "Mail";
            // 
            // txtMail
            // 
            txtMail.Dock = DockStyle.Fill;
            txtMail.Location = new Point(224, 31);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(215, 23);
            txtMail.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(445, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 28);
            label4.TabIndex = 8;
            label4.Text = "ID";
            // 
            // Editar
            // 
            Editar.Dock = DockStyle.Fill;
            Editar.Location = new Point(224, 93);
            Editar.Name = "Editar";
            Editar.Size = new Size(215, 31);
            Editar.TabIndex = 4;
            Editar.Text = "Editar usuario";
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // Nuevo
            // 
            Nuevo.Dock = DockStyle.Fill;
            Nuevo.Location = new Point(3, 93);
            Nuevo.Name = "Nuevo";
            Nuevo.Size = new Size(215, 31);
            Nuevo.TabIndex = 5;
            Nuevo.Text = "Cargar usuario";
            Nuevo.UseVisualStyleBackColor = true;
            Nuevo.Click += Nuevo_Click;
            // 
            // txtID
            // 
            txtID.Dock = DockStyle.Fill;
            txtID.Enabled = false;
            txtID.Location = new Point(445, 31);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(56, 23);
            txtID.TabIndex = 10;
            // 
            // Eliminar
            // 
            Eliminar.Dock = DockStyle.Fill;
            Eliminar.Location = new Point(507, 31);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(284, 56);
            Eliminar.TabIndex = 9;
            Eliminar.Text = "Eliminar usuario";
            Eliminar.UseVisualStyleBackColor = true;
            Eliminar.Click += Eliminar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Location = new Point(3, 31);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(215, 23);
            txtNombre.TabIndex = 2;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // Cancelar
            // 
            Cancelar.Dock = DockStyle.Fill;
            Cancelar.Location = new Point(507, 93);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(284, 31);
            Cancelar.TabIndex = 11;
            Cancelar.Text = "Cancelar ";
            Cancelar.UseVisualStyleBackColor = true;
            Cancelar.Click += Cancelar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(215, 28);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 290F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNombre, 0, 1);
            tableLayoutPanel1.Controls.Add(Nuevo, 0, 2);
            tableLayoutPanel1.Controls.Add(Editar, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(txtMail, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 0);
            tableLayoutPanel1.Controls.Add(Cancelar, 3, 2);
            tableLayoutPanel1.Controls.Add(Eliminar, 3, 1);
            tableLayoutPanel1.Controls.Add(txtID, 2, 1);
            tableLayoutPanel1.Location = new Point(5, 311);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.Size = new Size(794, 127);
            tableLayoutPanel1.TabIndex = 12;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
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
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private BindingSource usuarioBindingSource;
        private BindingSource gruposBindingSource;
        private DataGridView dgvUsuario;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private BindingSource gruposBindingSource2;
        private BindingSource gruposBindingSource1;
        private DataGridViewTextBoxColumn Mail;
        private Label label2;
        private TextBox txtMail;
        private Label label4;
        private Button Editar;
        private Button Nuevo;
        private TextBox txtID;
        private Button Eliminar;
        private TextBox txtNombre;
        private Button Cancelar;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
    }
}