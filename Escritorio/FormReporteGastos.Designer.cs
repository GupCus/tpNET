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
            this.cmbGrupos = new ComboBox();
            this.btnGenerarReporte = new Button();
            this.label1 = new Label();
            this.SuspendLayout();

            // cmbGrupos
            this.cmbGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGrupos.FormattingEnabled = true;
            this.cmbGrupos.Location = new System.Drawing.Point(120, 30);
            this.cmbGrupos.Name = "cmbGrupos";
            this.cmbGrupos.Size = new System.Drawing.Size(250, 28);
            this.cmbGrupos.TabIndex = 0;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar Grupo:";

            // btnGenerarReporte
            this.btnGenerarReporte.Location = new System.Drawing.Point(150, 80);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(150, 40);
            this.btnGenerarReporte.TabIndex = 2;
            this.btnGenerarReporte.Text = "Generar Reporte PDF";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);

            // FormReporteGastos
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 150);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbGrupos);
            this.Name = "FormReporteGastos";
            this.Text = "Reporte de Gastos por Grupo";
            this.Load += new System.EventHandler(this.FormReporteGastos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}