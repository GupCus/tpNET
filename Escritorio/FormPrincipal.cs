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
    }
}
