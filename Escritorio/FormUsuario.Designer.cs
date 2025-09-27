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
            txtNombre = new TextBox();
            txtMail = new TextBox();
            Editar = new Button();
            Nuevo = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Eliminar = new Button();
            txtID = new TextBox();
            Cancelar = new Button();
            dgvUsuario = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Mail = new DataGridViewTextBoxColumn();
            gruposBindingSource2 = new BindingSource(components);
            gruposBindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(-3, 2);
            label1.Name = "label1";
            label1.Size = new Size(802, 73);
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
            // txtNombre
            // 
            txtNombre.Location = new Point(53, 320);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(192, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(280, 320);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(192, 23);
            txtMail.TabIndex = 3;
            // 
            // Editar
            // 
            Editar.Location = new Point(280, 399);
            Editar.Name = "Editar";
            Editar.Size = new Size(192, 23);
            Editar.TabIndex = 4;
            Editar.Text = "Editar usuario";
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // Nuevo
            // 
            Nuevo.Location = new Point(53, 399);
            Nuevo.Name = "Nuevo";
            Nuevo.Size = new Size(192, 23);
            Nuevo.TabIndex = 5;
            Nuevo.Text = "Cargar usuario";
            Nuevo.UseVisualStyleBackColor = true;
            Nuevo.Click += Nuevo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(280, 293);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 6;
            label2.Text = "Mail";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 293);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(549, 293);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 8;
            label4.Text = "ID";
            // 
            // Eliminar
            // 
            Eliminar.Location = new Point(549, 324);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(236, 59);
            Eliminar.TabIndex = 9;
            Eliminar.Text = "Eliminar usuario";
            Eliminar.UseVisualStyleBackColor = true;
            Eliminar.Click += Eliminar_Click;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(573, 289);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(39, 23);
            txtID.TabIndex = 10;
            // 
            // Cancelar
            // 
            Cancelar.Location = new Point(549, 394);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(236, 33);
            Cancelar.TabIndex = 11;
            Cancelar.Text = "Cancelar ";
            Cancelar.UseVisualStyleBackColor = true;
            Cancelar.Click += Cancelar_Click;
            // 
            // dgvUsuario
            // 
            dgvUsuario.AllowUserToOrderColumns = true;
            dgvUsuario.AutoGenerateColumns = false;
            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuario.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, Mail });
            dgvUsuario.DataSource = gruposBindingSource2;
            dgvUsuario.Location = new Point(-3, 66);
            dgvUsuario.Name = "dgvUsuario";
            dgvUsuario.Size = new Size(802, 150);
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
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvUsuario);
            Controls.Add(Cancelar);
            Controls.Add(txtID);
            Controls.Add(Eliminar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Nuevo);
            Controls.Add(Editar);
            Controls.Add(txtMail);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FormUsuario";
            Text = "FormUsuario";
            Load += FormUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gruposBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private TextBox txtMail;
        private Button Editar;
        private Button Nuevo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button Eliminar;
        private BindingSource usuarioBindingSource;
        private TextBox txtID;
        private Button Cancelar;
        private BindingSource gruposBindingSource;
        private DataGridView dgvUsuario;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private BindingSource gruposBindingSource2;
        private BindingSource gruposBindingSource1;
        private DataGridViewTextBoxColumn Mail;
    }
}