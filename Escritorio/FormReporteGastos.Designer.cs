// En Escritorio/Forms/FormReporteGastos.Designer.cs
namespace Escritorio.Forms
{
    partial class FormReporteGastos
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbGrupos;
        private Button btnGenerarReporte;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbGrupos = new ComboBox();
            btnGenerarReporte = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbGrupos
            // 
            cmbGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupos.FormattingEnabled = true;
            cmbGrupos.Location = new Point(150, 30);
            cmbGrupos.Name = "cmbGrupos";
            cmbGrupos.Size = new Size(250, 28);
            cmbGrupos.TabIndex = 0;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.Location = new Point(150, 64);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(150, 40);
            btnGenerarReporte.TabIndex = 2;
            btnGenerarReporte.Text = "Generar Reporte PDF";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 1;
            label1.Text = "Seleccionar Grupo:";
            // 
            // FormReporteGastos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 150);
            Controls.Add(btnGenerarReporte);
            Controls.Add(label1);
            Controls.Add(cmbGrupos);
            Name = "FormReporteGastos";
            Text = "Reporte de Gastos por Grupo";
            Load += FormReporteGastos_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}