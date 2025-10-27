namespace Escritorio
{
    partial class FormPrincipal
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
            lblTituloUsuarioNormal = new Label();
            cmbUsuarioNormal = new ComboBox();
            lblTituloOpciones = new Label();
            cmbOpciones = new ComboBox();
            panelSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.LightSteelBlue;
            panelSuperior.Controls.Add(lblTituloUsuarioNormal);
            panelSuperior.Controls.Add(cmbUsuarioNormal);
            panelSuperior.Controls.Add(lblTituloOpciones);
            panelSuperior.Controls.Add(cmbOpciones);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Margin = new Padding(3, 4, 3, 4);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1262, 100);
            panelSuperior.TabIndex = 0;
            // 
            // lblTituloUsuarioNormal
            // 
            lblTituloUsuarioNormal.AutoSize = true;
            lblTituloUsuarioNormal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloUsuarioNormal.ForeColor = Color.DarkGreen;
            lblTituloUsuarioNormal.Location = new Point(500, 15);
            lblTituloUsuarioNormal.Name = "lblTituloUsuarioNormal";
            lblTituloUsuarioNormal.Size = new Size(167, 23);
            lblTituloUsuarioNormal.TabIndex = 3;
            lblTituloUsuarioNormal.Text = "👤 Opciones Usuario:";
            // 
            // cmbUsuarioNormal
            // 
            cmbUsuarioNormal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarioNormal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUsuarioNormal.FormattingEnabled = true;
            cmbUsuarioNormal.Location = new Point(500, 45);
            cmbUsuarioNormal.Margin = new Padding(3, 4, 3, 4);
            cmbUsuarioNormal.Name = "cmbUsuarioNormal";
            cmbUsuarioNormal.Size = new Size(300, 28);
            cmbUsuarioNormal.TabIndex = 2;
            // 
            // lblTituloOpciones
            // 
            lblTituloOpciones.AutoSize = true;
            lblTituloOpciones.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloOpciones.ForeColor = Color.DarkBlue;
            lblTituloOpciones.Location = new Point(50, 15);
            lblTituloOpciones.Name = "lblTituloOpciones";
            lblTituloOpciones.Size = new Size(103, 23);
            lblTituloOpciones.TabIndex = 1;
            lblTituloOpciones.Text = "Navegación:";
            // 
            // cmbOpciones
            // 
            cmbOpciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpciones.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbOpciones.FormattingEnabled = true;
            cmbOpciones.Location = new Point(50, 45);
            cmbOpciones.Margin = new Padding(3, 4, 3, 4);
            cmbOpciones.Name = "cmbOpciones";
            cmbOpciones.Size = new Size(400, 28);
            cmbOpciones.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(panelSuperior);
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Planificador de Viajes";
            Shown += FormPrincipal_Shown;
            Resize += FormPrincipal_Resize;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTituloOpciones;
        private ComboBox cmbOpciones;
        private Label lblTituloUsuarioNormal;
        private ComboBox cmbUsuarioNormal;
    }
}