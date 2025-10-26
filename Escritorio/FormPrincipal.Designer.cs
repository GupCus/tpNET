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
            miniToolStrip = new MenuStrip();
            categoriaGastosToolStripMenuItem = new ToolStripMenuItem();
            gastosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            tareaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            menuStrip2 = new MenuStrip();
            gastosToolStripMenuItem1 = new ToolStripMenuItem();
            categoriasDeGastosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem1 = new ToolStripMenuItem();
            tareasToolStripMenuItem = new ToolStripMenuItem();
            planesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "Selección de nuevo elemento";
            miniToolStrip.AccessibleRole = AccessibleRole.ComboBox;
            miniToolStrip.AutoSize = false;
            miniToolStrip.Dock = DockStyle.None;
            miniToolStrip.ImageScalingSize = new Size(20, 20);
            miniToolStrip.Location = new Point(294, 2);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Size = new Size(570, 24);
            miniToolStrip.TabIndex = 5;
            // 
            // categoriaGastosToolStripMenuItem
            // 
            categoriaGastosToolStripMenuItem.Name = "categoriaGastosToolStripMenuItem";
            categoriaGastosToolStripMenuItem.Size = new Size(12, 20);
            // 
            // gastosToolStripMenuItem
            // 
            gastosToolStripMenuItem.Name = "gastosToolStripMenuItem";
            gastosToolStripMenuItem.Size = new Size(12, 20);
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(12, 20);
            // 
            // tareaToolStripMenuItem
            // 
            tareaToolStripMenuItem.Name = "tareaToolStripMenuItem";
            tareaToolStripMenuItem.Size = new Size(12, 20);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { categoriaGastosToolStripMenuItem, gastosToolStripMenuItem, usuariosToolStripMenuItem, tareaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(570, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { gastosToolStripMenuItem1, categoriasDeGastosToolStripMenuItem, usuariosToolStripMenuItem1, tareasToolStripMenuItem, planesToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1104, 24);
            menuStrip2.TabIndex = 0;
            menuStrip2.Text = "menuStrip2";
            // 
            // gastosToolStripMenuItem1
            // 
            gastosToolStripMenuItem1.Name = "gastosToolStripMenuItem1";
            gastosToolStripMenuItem1.Size = new Size(54, 20);
            gastosToolStripMenuItem1.Text = "Gastos";
            gastosToolStripMenuItem1.Click += gastosToolStripMenuItem1_Click;
            // 
            // categoriasDeGastosToolStripMenuItem
            // 
            categoriasDeGastosToolStripMenuItem.Name = "categoriasDeGastosToolStripMenuItem";
            categoriasDeGastosToolStripMenuItem.Size = new Size(128, 20);
            categoriasDeGastosToolStripMenuItem.Text = "Categorias de gastos";
            categoriasDeGastosToolStripMenuItem.Click += categoriasDeGastosToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem1
            // 
            usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
            usuariosToolStripMenuItem1.Size = new Size(64, 20);
            usuariosToolStripMenuItem1.Text = "Usuarios";
            usuariosToolStripMenuItem1.Click += usuariosToolStripMenuItem1_Click;
            // 
            // tareasToolStripMenuItem
            // 
            tareasToolStripMenuItem.Name = "tareasToolStripMenuItem";
            tareasToolStripMenuItem.Size = new Size(52, 20);
            tareasToolStripMenuItem.Text = "Tareas";
            tareasToolStripMenuItem.Click += tareasToolStripMenuItem_Click;
            // 
            // planesToolStripMenuItem
            // 
            planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            planesToolStripMenuItem.Size = new Size(53, 20);
            planesToolStripMenuItem.Text = "Planes";
            planesToolStripMenuItem.Click += planesToolStripMenuItem_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 505);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip2;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Planificador";
            Shown += FormPrincipal_Shown;
            Resize += FormPrincipal_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip miniToolStrip;
        private ToolStripMenuItem categoriaGastosToolStripMenuItem;
        private ToolStripMenuItem gastosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem tareaToolStripMenuItem;
        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem gastosToolStripMenuItem1;
        private ToolStripMenuItem categoriasDeGastosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem1;
        private ToolStripMenuItem tareasToolStripMenuItem;
        private ToolStripMenuItem planesToolStripMenuItem;
    }
}