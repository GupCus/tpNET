namespace Escritorio
{
    partial class FormMisGrupos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelSuperior = new Panel();
            gbDatosGrupo = new GroupBox();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtID = new TextBox();
            lblID = new Label();
            gbAcciones = new GroupBox();
            btnLimpiar = new Button();
            btnCrear = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            gbAgregarUsuario = new GroupBox();
            txtUsuarioMail = new TextBox();
            lblUsuarioMail = new Label();
            btnAgregarUsuario = new Button();
            dataGridViewGrupos = new DataGridView();
            lblEstado = new Label();
            toolTip = new ToolTip(components);
            panelSuperior.SuspendLayout();
            gbDatosGrupo.SuspendLayout();
            gbAcciones.SuspendLayout();
            gbAgregarUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGrupos).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.Controls.Add(gbDatosGrupo);
            panelSuperior.Controls.Add(gbAcciones);
            panelSuperior.Controls.Add(gbAgregarUsuario);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Padding = new Padding(10);
            panelSuperior.Size = new Size(884, 200);
            panelSuperior.TabIndex = 0;
            // 
            // gbDatosGrupo
            // 
            gbDatosGrupo.Controls.Add(txtDescripcion);
            gbDatosGrupo.Controls.Add(lblDescripcion);
            gbDatosGrupo.Controls.Add(txtNombre);
            gbDatosGrupo.Controls.Add(lblNombre);
            gbDatosGrupo.Controls.Add(txtID);
            gbDatosGrupo.Controls.Add(lblID);
            gbDatosGrupo.Location = new Point(13, 13);
            gbDatosGrupo.Name = "gbDatosGrupo";
            gbDatosGrupo.Size = new Size(350, 174);
            gbDatosGrupo.TabIndex = 0;
            gbDatosGrupo.TabStop = false;
            gbDatosGrupo.Text = "Datos del Grupo";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 90);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(220, 70);
            txtDescripcion.TabIndex = 2;
            toolTip.SetToolTip(txtDescripcion, "Descripción del grupo");
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(20, 93);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 55);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 27);
            txtNombre.TabIndex = 1;
            toolTip.SetToolTip(txtNombre, "Nombre del grupo");
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // txtID
            // 
            txtID.BackColor = SystemColors.ControlLight;
            txtID.Location = new Point(120, 20);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(100, 27);
            txtID.TabIndex = 0;
            toolTip.SetToolTip(txtID, "ID del grupo (automático)");
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(20, 23);
            lblID.Name = "lblID";
            lblID.Size = new Size(27, 20);
            lblID.TabIndex = 0;
            lblID.Text = "ID:";
            // 
            // gbAcciones
            // 
            gbAcciones.Controls.Add(btnLimpiar);
            gbAcciones.Controls.Add(btnCrear);
            gbAcciones.Controls.Add(btnEditar);
            gbAcciones.Controls.Add(btnEliminar);
            gbAcciones.Location = new Point(369, 13);
            gbAcciones.Name = "gbAcciones";
            gbAcciones.Size = new Size(250, 174);
            gbAcciones.TabIndex = 1;
            gbAcciones.TabStop = false;
            gbAcciones.Text = "Acciones";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(20, 142);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(210, 32);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar Formulario";
            toolTip.SetToolTip(btnLimpiar, "Limpiar todos los campos");
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(20, 25);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(210, 35);
            btnCrear.TabIndex = 0;
            btnCrear.Text = "Crear Nuevo Grupo";
            toolTip.SetToolTip(btnCrear, "Crear un nuevo grupo");
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnEditar
            // 
            btnEditar.Enabled = false;
            btnEditar.Location = new Point(20, 66);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(210, 35);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar Grupo";
            toolTip.SetToolTip(btnEditar, "Editar grupo seleccionado");
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(20, 107);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(210, 35);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "ELIMINAR GRUPO";
            toolTip.SetToolTip(btnEliminar, "Eliminar grupo seleccionado");
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // gbAgregarUsuario
            // 
            gbAgregarUsuario.Controls.Add(txtUsuarioMail);
            gbAgregarUsuario.Controls.Add(lblUsuarioMail);
            gbAgregarUsuario.Controls.Add(btnAgregarUsuario);
            gbAgregarUsuario.Location = new Point(625, 13);
            gbAgregarUsuario.Name = "gbAgregarUsuario";
            gbAgregarUsuario.Size = new Size(250, 174);
            gbAgregarUsuario.TabIndex = 2;
            gbAgregarUsuario.TabStop = false;
            gbAgregarUsuario.Text = "Agregar Usuario al Grupo";
            // 
            // txtUsuarioMail
            // 
            txtUsuarioMail.Enabled = false;
            txtUsuarioMail.Location = new Point(20, 55);
            txtUsuarioMail.Name = "txtUsuarioMail";
            txtUsuarioMail.PlaceholderText = "ejemplo@mail.com";
            txtUsuarioMail.Size = new Size(210, 27);
            txtUsuarioMail.TabIndex = 0;
            toolTip.SetToolTip(txtUsuarioMail, "Ingrese el email del usuario a agregar");
            txtUsuarioMail.KeyPress += txtUsuarioMail_KeyPress;
            // 
            // lblUsuarioMail
            // 
            lblUsuarioMail.AutoSize = true;
            lblUsuarioMail.Location = new Point(20, 32);
            lblUsuarioMail.Name = "lblUsuarioMail";
            lblUsuarioMail.Size = new Size(126, 20);
            lblUsuarioMail.TabIndex = 2;
            lblUsuarioMail.Text = "Email del usuario:";
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Enabled = false;
            btnAgregarUsuario.Location = new Point(20, 95);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(210, 35);
            btnAgregarUsuario.TabIndex = 1;
            btnAgregarUsuario.Text = "Agregar al Grupo";
            toolTip.SetToolTip(btnAgregarUsuario, "Agregar usuario al grupo seleccionado");
            btnAgregarUsuario.UseVisualStyleBackColor = true;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // dataGridViewGrupos
            // 
            dataGridViewGrupos.AllowUserToAddRows = false;
            dataGridViewGrupos.AllowUserToDeleteRows = false;
            dataGridViewGrupos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewGrupos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGrupos.BackgroundColor = SystemColors.Window;
            dataGridViewGrupos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewGrupos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewGrupos.ColumnHeadersHeight = 35;
            dataGridViewGrupos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewGrupos.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewGrupos.Dock = DockStyle.Fill;
            dataGridViewGrupos.Location = new Point(0, 230);
            dataGridViewGrupos.MultiSelect = false;
            dataGridViewGrupos.Name = "dataGridViewGrupos";
            dataGridViewGrupos.ReadOnly = true;
            dataGridViewGrupos.RowHeadersVisible = false;
            dataGridViewGrupos.RowHeadersWidth = 51;
            dataGridViewGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGrupos.Size = new Size(884, 331);
            dataGridViewGrupos.TabIndex = 1;
            dataGridViewGrupos.CellFormatting += dataGridViewGrupos_CellFormatting;
            dataGridViewGrupos.SelectionChanged += dataGridViewGrupos_SelectionChanged;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Top;
            lblEstado.Location = new Point(0, 200);
            lblEstado.Name = "lblEstado";
            lblEstado.Padding = new Padding(10, 5, 10, 5);
            lblEstado.Size = new Size(884, 30);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Cargando grupos...";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormMisGrupos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(dataGridViewGrupos);
            Controls.Add(lblEstado);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(900, 600);
            Name = "FormMisGrupos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mis Grupos - Administrador";
            Load += FormMisGrupos_Load;
            panelSuperior.ResumeLayout(false);
            gbDatosGrupo.ResumeLayout(false);
            gbDatosGrupo.PerformLayout();
            gbAcciones.ResumeLayout(false);
            gbAgregarUsuario.ResumeLayout(false);
            gbAgregarUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGrupos).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.GroupBox gbDatosGrupo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.GroupBox gbAcciones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gbAgregarUsuario;
        private System.Windows.Forms.TextBox txtUsuarioMail;
        private System.Windows.Forms.Label lblUsuarioMail;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.DataGridView dataGridViewGrupos;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblEstado;
    }
}