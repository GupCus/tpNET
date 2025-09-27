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
            btnCategoriaGastos = new Button();
            titulo = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnTareas = new Button();
            btnGasto = new Button();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCategoriaGastos
            // 
            btnCategoriaGastos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCategoriaGastos.Location = new Point(269, 84);
            btnCategoriaGastos.Name = "btnCategoriaGastos";
            btnCategoriaGastos.Size = new Size(260, 29);
            btnCategoriaGastos.TabIndex = 0;
            btnCategoriaGastos.Text = "Categoria Gastos";
            btnCategoriaGastos.UseVisualStyleBackColor = true;
            btnCategoriaGastos.Click += btnCategoriaGastos_Click;
            // 
            // titulo
            // 
            titulo.Anchor = AnchorStyles.Bottom;
            titulo.AutoSize = true;
            titulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titulo.ImageAlign = ContentAlignment.MiddleRight;
            titulo.Location = new Point(282, 40);
            titulo.Name = "titulo";
            titulo.Size = new Size(233, 41);
            titulo.TabIndex = 1;
            titulo.Text = "Listado de APIs";
            titulo.TextAlign = ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(btnCategoriaGastos, 1, 1);
            tableLayoutPanel1.Controls.Add(titulo, 1, 0);
            tableLayoutPanel1.Controls.Add(btnTareas, 1, 2);
            tableLayoutPanel1.Controls.Add(btnGasto, 1, 3);
            tableLayoutPanel1.Controls.Add(button1, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.181818F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.4545441F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // btnTareas
            // 
            btnTareas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnTareas.Location = new Point(269, 124);
            btnTareas.Name = "btnTareas";
            btnTareas.Size = new Size(260, 29);
            btnTareas.TabIndex = 2;
            btnTareas.Text = "Tarea";
            btnTareas.UseVisualStyleBackColor = true;
            btnTareas.Click += btnTareas_Click;
            // 
            // btnGasto
            // 
            btnGasto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnGasto.Location = new Point(269, 164);
            btnGasto.Name = "btnGasto";
            btnGasto.Size = new Size(260, 29);
            btnGasto.TabIndex = 3;
            btnGasto.Text = "Gasto";
            btnGasto.UseVisualStyleBackColor = true;
            btnGasto.Click += btnGasto_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(269, 204);
            button1.Name = "button1";
            button1.Size = new Size(260, 29);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "FormPrincipal";
            Text = "Planificador";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCategoriaGastos;
        private Label titulo;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnTareas;
        private Button btnGasto;
        private Button button1;
    }
}