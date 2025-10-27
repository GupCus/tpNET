namespace Escritorio
{
    partial class FrmGrupos
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
            panelSuperior = new Panel();
            btnActualizar = new Button();
            btnBuscar = new Button();
            txtBusqueda = new TextBox();
            lblBuscar = new Label();
            dgvGrupos = new DataGridView();
            panelInferior = new Panel();
            lblContador = new Label();
            btnGestionarGastos = new Button();
            btnGestionarTareas = new Button();
            btnGestionarPlanes = new Button();
            btnNuevoGrupo = new Button();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = SystemColors.ControlLight;
            panelSuperior.Controls.Add(btnActualizar);
            panelSuperior.Controls.Add(btnBuscar);
            panelSuperior.Controls.Add(txtBusqueda);
            panelSuperior.Controls.Add(lblBuscar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Margin = new Padding(3, 4, 3, 4);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1000, 80);
            panelSuperior.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(375, 13);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(86, 31);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(290, 13);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 31);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(80, 15);
            txtBusqueda.Margin = new Padding(3, 4, 3, 4);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(200, 27);
            txtBusqueda.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 18);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(55, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // dgvGrupos
            // 
            dgvGrupos.AllowUserToAddRows = false;
            dgvGrupos.AllowUserToDeleteRows = false;
            dgvGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGrupos.BackgroundColor = SystemColors.Window;
            dgvGrupos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrupos.Dock = DockStyle.Fill;
            dgvGrupos.Location = new Point(0, 80);
            dgvGrupos.Margin = new Padding(3, 4, 3, 4);
            dgvGrupos.Name = "dgvGrupos";
            dgvGrupos.ReadOnly = true;
            dgvGrupos.RowHeadersWidth = 51;
            dgvGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrupos.Size = new Size(1000, 460);
            dgvGrupos.TabIndex = 1;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = SystemColors.ControlLight;
            panelInferior.Controls.Add(lblContador);
            panelInferior.Controls.Add(btnGestionarGastos);
            panelInferior.Controls.Add(btnGestionarTareas);
            panelInferior.Controls.Add(btnGestionarPlanes);
            panelInferior.Controls.Add(btnNuevoGrupo);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 540);
            panelInferior.Margin = new Padding(3, 4, 3, 4);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(1000, 60);
            panelInferior.TabIndex = 2;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(400, 23);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(73, 20);
            lblContador.TabIndex = 4;
            lblContador.Text = "0 grupos";
            // 
            // btnGestionarGastos
            // 
            btnGestionarGastos.Location = new Point(310, 18);
            btnGestionarGastos.Margin = new Padding(3, 4, 3, 4);
            btnGestionarGastos.Name = "btnGestionarGastos";
            btnGestionarGastos.Size = new Size(80, 31);
            btnGestionarGastos.TabIndex = 3;
            btnGestionarGastos.Text = "💰 Gastos";
            btnGestionarGastos.UseVisualStyleBackColor = true;
            // 
            // btnGestionarTareas
            // 
            btnGestionarTareas.Location = new Point(220, 18);
            btnGestionarTareas.Margin = new Padding(3, 4, 3, 4);
            btnGestionarTareas.Name = "btnGestionarTareas";
            btnGestionarTareas.Size = new Size(80, 31);
            btnGestionarTareas.TabIndex = 2;
            btnGestionarTareas.Text = "✅ Tareas";
            btnGestionarTareas.UseVisualStyleBackColor = true;
            // 
            // btnGestionarPlanes
            // 
            btnGestionarPlanes.Location = new Point(130, 18);
            btnGestionarPlanes.Margin = new Padding(3, 4, 3, 4);
            btnGestionarPlanes.Name = "btnGestionarPlanes";
            btnGestionarPlanes.Size = new Size(80, 31);
            btnGestionarPlanes.TabIndex = 1;
            btnGestionarPlanes.Text = "📅 Planes";
            btnGestionarPlanes.UseVisualStyleBackColor = true;
            // 
            // btnNuevoGrupo
            // 
            btnNuevoGrupo.Location = new Point(20, 18);
            btnNuevoGrupo.Margin = new Padding(3, 4, 3, 4);
            btnNuevoGrupo.Name = "btnNuevoGrupo";
            btnNuevoGrupo.Size = new Size(100, 31);
            btnNuevoGrupo.TabIndex = 0;
            btnNuevoGrupo.Text = "Nuevo Grupo";
            btnNuevoGrupo.UseVisualStyleBackColor = true;
            // 
            // FrmGrupos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvGrupos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmGrupos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mis Grupos";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Button btnActualizar;
        private Button btnBuscar;
        private TextBox txtBusqueda;
        private Label lblBuscar;
        private DataGridView dgvGrupos;
        private Panel panelInferior;
        private Label lblContador;
        private Button btnGestionarGastos;
        private Button btnGestionarTareas;
        private Button btnGestionarPlanes;
        private Button btnNuevoGrupo;
    }
}