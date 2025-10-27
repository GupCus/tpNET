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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            // Controles principales
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.gbDatosGrupo = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();

            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.gbAgregarUsuario = new System.Windows.Forms.GroupBox();
            this.txtUsuarioMail = new System.Windows.Forms.TextBox();
            this.lblUsuarioMail = new System.Windows.Forms.Label();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();

            this.dataGridViewGrupos = new System.Windows.Forms.DataGridView();
            this.lblEstado = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);

            this.panelSuperior.SuspendLayout();
            this.gbDatosGrupo.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            this.gbAgregarUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupos)).BeginInit();
            this.SuspendLayout();

            // 
            // panelSuperior
            // 
            this.panelSuperior.Controls.Add(this.gbDatosGrupo);
            this.panelSuperior.Controls.Add(this.gbAcciones);
            this.panelSuperior.Controls.Add(this.gbAgregarUsuario);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Padding = new System.Windows.Forms.Padding(10);
            this.panelSuperior.Size = new System.Drawing.Size(884, 200);
            this.panelSuperior.TabIndex = 0;

            // 
            // gbDatosGrupo
            // 
            this.gbDatosGrupo.Controls.Add(this.txtDescripcion);
            this.gbDatosGrupo.Controls.Add(this.lblDescripcion);
            this.gbDatosGrupo.Controls.Add(this.txtNombre);
            this.gbDatosGrupo.Controls.Add(this.lblNombre);
            this.gbDatosGrupo.Controls.Add(this.txtID);
            this.gbDatosGrupo.Controls.Add(this.lblID);
            this.gbDatosGrupo.Location = new System.Drawing.Point(13, 13);
            this.gbDatosGrupo.Name = "gbDatosGrupo";
            this.gbDatosGrupo.Size = new System.Drawing.Size(350, 174);
            this.gbDatosGrupo.TabIndex = 0;
            this.gbDatosGrupo.TabStop = false;
            this.gbDatosGrupo.Text = "Datos del Grupo";

            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(120, 90);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(220, 70);
            this.txtDescripcion.TabIndex = 2;
            this.toolTip.SetToolTip(this.txtDescripcion, "Descripción del grupo");
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 93);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(90, 20);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 27);
            this.txtNombre.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtNombre, "Nombre del grupo");
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(67, 20);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtID.Location = new System.Drawing.Point(120, 20);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 27);
            this.txtID.TabIndex = 0;
            this.toolTip.SetToolTip(this.txtID, "ID del grupo (automático)");
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(20, 23);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(27, 20);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // gbAcciones
            // 
            this.gbAcciones.Controls.Add(this.btnLimpiar);
            this.gbAcciones.Controls.Add(this.btnCrear);
            this.gbAcciones.Controls.Add(this.btnEditar);
            this.gbAcciones.Controls.Add(this.btnEliminar);
            this.gbAcciones.Location = new System.Drawing.Point(369, 13);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(250, 174);
            this.gbAcciones.TabIndex = 1;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(20, 130);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(210, 35);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar Formulario";
            this.toolTip.SetToolTip(this.btnLimpiar, "Limpiar todos los campos");
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(20, 25);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(210, 35);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear Nuevo Grupo";
            this.toolTip.SetToolTip(this.btnCrear, "Crear un nuevo grupo");
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(20, 65);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(210, 35);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar Grupo";
            this.toolTip.SetToolTip(this.btnEditar, "Editar grupo seleccionado");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(20, 105);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(210, 35);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "ELIMINAR GRUPO";
            this.toolTip.SetToolTip(this.btnEliminar, "Eliminar grupo seleccionado");
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gbAgregarUsuario
            // 
            this.gbAgregarUsuario.Controls.Add(this.txtUsuarioMail);
            this.gbAgregarUsuario.Controls.Add(this.lblUsuarioMail);
            this.gbAgregarUsuario.Controls.Add(this.btnAgregarUsuario);
            this.gbAgregarUsuario.Location = new System.Drawing.Point(625, 13);
            this.gbAgregarUsuario.Name = "gbAgregarUsuario";
            this.gbAgregarUsuario.Size = new System.Drawing.Size(250, 174);
            this.gbAgregarUsuario.TabIndex = 2;
            this.gbAgregarUsuario.TabStop = false;
            this.gbAgregarUsuario.Text = "Agregar Usuario al Grupo";
            // 
            // txtUsuarioMail
            // 
            this.txtUsuarioMail.Enabled = false;
            this.txtUsuarioMail.Location = new System.Drawing.Point(20, 55);
            this.txtUsuarioMail.Name = "txtUsuarioMail";
            this.txtUsuarioMail.PlaceholderText = "ejemplo@mail.com";
            this.txtUsuarioMail.Size = new System.Drawing.Size(210, 27);
            this.txtUsuarioMail.TabIndex = 0;
            this.toolTip.SetToolTip(this.txtUsuarioMail, "Ingrese el email del usuario a agregar");
            this.txtUsuarioMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioMail_KeyPress);
            // 
            // lblUsuarioMail
            // 
            this.lblUsuarioMail.AutoSize = true;
            this.lblUsuarioMail.Location = new System.Drawing.Point(20, 32);
            this.lblUsuarioMail.Name = "lblUsuarioMail";
            this.lblUsuarioMail.Size = new System.Drawing.Size(121, 20);
            this.lblUsuarioMail.TabIndex = 2;
            this.lblUsuarioMail.Text = "Email del usuario:";
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Enabled = false;
            this.btnAgregarUsuario.Location = new System.Drawing.Point(20, 95);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(210, 35);
            this.btnAgregarUsuario.TabIndex = 1;
            this.btnAgregarUsuario.Text = "Agregar al Grupo";
            this.toolTip.SetToolTip(this.btnAgregarUsuario, "Agregar usuario al grupo seleccionado");
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // dataGridViewGrupos
            // 
            this.dataGridViewGrupos.AllowUserToAddRows = false;
            this.dataGridViewGrupos.AllowUserToDeleteRows = false;
            this.dataGridViewGrupos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewGrupos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGrupos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewGrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGrupos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewGrupos.ColumnHeadersHeight = 35;
            this.dataGridViewGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewGrupos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGrupos.Location = new System.Drawing.Point(0, 230);
            this.dataGridViewGrupos.MultiSelect = false;
            this.dataGridViewGrupos.Name = "dataGridViewGrupos";
            this.dataGridViewGrupos.ReadOnly = true;
            this.dataGridViewGrupos.RowHeadersVisible = false;
            this.dataGridViewGrupos.RowHeadersWidth = 51;
            this.dataGridViewGrupos.RowTemplate.Height = 29;
            this.dataGridViewGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGrupos.Size = new System.Drawing.Size(884, 331);
            this.dataGridViewGrupos.TabIndex = 1;
            this.dataGridViewGrupos.SelectionChanged += new System.EventHandler(this.dataGridViewGrupos_SelectionChanged);
            this.dataGridViewGrupos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewGrupos_CellFormatting);
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEstado.Location = new System.Drawing.Point(0, 200);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lblEstado.Size = new System.Drawing.Size(884, 30);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Cargando grupos...";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormMisGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.dataGridViewGrupos);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.panelSuperior);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormMisGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mis Grupos - Administrador";
            this.Load += new System.EventHandler(this.FormMisGrupos_Load);
            this.panelSuperior.ResumeLayout(false);
            this.gbDatosGrupo.ResumeLayout(false);
            this.gbDatosGrupo.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            this.gbAgregarUsuario.ResumeLayout(false);
            this.gbAgregarUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupos)).EndInit();
            this.ResumeLayout(false);

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