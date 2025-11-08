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
            dgvGrupos = new DataGridView();
            panelInferior = new Panel();
            lblContador = new Label();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = SystemColors.ControlLight;
            panelSuperior.Controls.Add(lblContador);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Margin = new Padding(3, 4, 3, 4);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1000, 80);
            panelSuperior.TabIndex = 0;
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
            lblContador.Location = new Point(12, 37);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(67, 20);
            lblContador.TabIndex = 4;
            lblContador.Text = "0 grupos";
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private DataGridView dgvGrupos;
        private Panel panelInferior;
        private Label lblContador;
    }
}