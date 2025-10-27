using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            FormLogin appLogin = new();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btnCategoriaGastos_Click(object sender, EventArgs e)
        {
            new FormCategoriaGastos().ShowDialog();
        }

        private void btnTareas_Click(object sender, EventArgs e)
        {
            new FormTarea().ShowDialog();
        }

        private void btnGasto_Click(object sender, EventArgs e)
        {
            new FormGasto().ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FormUsuario().ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void gastosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGasto form = new FormGasto();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void categoriasDeGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategoriaGastos form = new FormCategoriaGastos();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormUsuario form = new FormUsuario();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void tareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTarea form = new FormTarea();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void FormPrincipal_Resize(object sender, EventArgs e)
        {


            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Dock = DockStyle.Fill;
            }

        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPlan form = new FormPlan();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;

            form.Show();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;

            form.Show();
        }

        private void agregarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMisGrupos form = new FormMisGrupos();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;

            form.Show();
        }
    }
}
