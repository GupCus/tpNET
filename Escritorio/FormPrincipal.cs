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
            else
            {
                ConfigurarOpcionesSegunRol();
                MostrarBienvenida();
            }
        }

        private void ConfigurarOpcionesSegunRol()
        {

            cmbOpciones.Items.Clear();
            cmbOpciones.SelectedIndexChanged -= CmbOpciones_SelectedIndexChanged;

            if (Sesion.EsAdmin())
            {
                lblTituloOpciones.Text = "🔧 Navegación Administrador:";
                lblTituloOpciones.ForeColor = Color.DarkRed;

                cmbOpciones.Items.AddRange(new object[]
                {
                    "🚀 Seleccionar opción...",
                    "👥 Gestión de Usuarios (FormUsuario)",
                    "📊 Categorías de Gastos (FormCategoriaGastos)",
                    "🏢 Gestión de Grupos del Sistema (FormGrupo)",
                    "📅 Gestión de Planes del Sistema (FormPlan)",
                    "✅ Gestión de Tareas del Sistema (FormTarea)",
                    "💰 Gestión de Gastos del Sistema (FormGasto)"
                });
            }
            else
            {
                lblTituloOpciones.Text = "👤 Navegación Usuario:";
                lblTituloOpciones.ForeColor = Color.DarkGreen;

                cmbOpciones.Items.AddRange(new object[]
                {
                    "👋 ¿Qué quieres hacer?",
                    "🏠 Ver Mis Grupos de Viaje (FrmGrupos)",
                    "➕ Crear/Editar Grupo y Participantes (FormMisGrupos)"
                    // Solo grupos para usuarios normales
                });
            }

            cmbOpciones.SelectedIndex = 0;
            cmbOpciones.SelectedIndexChanged += CmbOpciones_SelectedIndexChanged;
        }

        private void CmbOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOpciones.SelectedIndex <= 0) return;

            try
            {
                if (Sesion.EsAdmin())
                {
                    ProcesarOpcionAdmin();
                }
                else
                {
                    ProcesarOpcionUsuario();
                }
            }
            finally
            {
                cmbOpciones.SelectedIndex = 0;
            }
        }

        private void ProcesarOpcionAdmin()
        {
            switch (cmbOpciones.SelectedIndex)
            {
                case 1: // Gestión de Usuarios
                    AbrirFormUsuario();
                    break;
                case 2: // Categorías de Gastos
                    AbrirFormCategoriaGastos();
                    break;
                case 3: // Gestión de Grupos del Sistema
                    AbrirFormGrupo();
                    break;
                case 4: // Gestión de Planes del Sistema
                    AbrirFormPlan();
                    break;
                case 5: // Gestión de Tareas del Sistema
                    AbrirFormTarea();
                    break;
                case 6: // Gestión de Gastos del Sistema
                    AbrirFormGasto();
                    break;
            }
        }

        private void ProcesarOpcionUsuario()
        {
            switch (cmbOpciones.SelectedIndex)
            {
                case 1: // Ver Mis Grupos de Viaje
                    AbrirFrmGrupos();
                    break;
                case 2: // Crear/Editar Grupo y Participantes
                    AbrirFormMisGrupos();
                    break;
                    // Usuarios normales solo tienen acceso a grupos
            }
        }

        // ========== MÉTODOS PARA ABRIR FORMS ==========

        private void AbrirFormUsuario()
        {
            FormUsuario form = new FormUsuario();
            AbrirFormMDI(form, "Gestión de Usuarios");
        }

        private void AbrirFormCategoriaGastos()
        {
            FormCategoriaGastos form = new FormCategoriaGastos();
            AbrirFormMDI(form, "Categorías de Gastos");
        }

        private void AbrirFormGrupo()
        {
            FormGrupo form = new FormGrupo();
            AbrirFormMDI(form, "Gestión de Grupos del Sistema");
        }

        private void AbrirFormPlan()
        {
            FormPlan form = new FormPlan();
            AbrirFormMDI(form, "Gestión de Planes del Sistema");
        }

        private void AbrirFormTarea()
        {
            FormTarea form = new FormTarea();
            AbrirFormMDI(form, "Gestión de Tareas del Sistema");
        }

        private void AbrirFormGasto()
        {
            FormGasto form = new FormGasto();
            AbrirFormMDI(form, "Gestión de Gastos del Sistema");
        }

        private void AbrirFrmGrupos()
        {
            FrmGrupos form = new FrmGrupos(Sesion.UsuarioActual.Id);
            AbrirFormMDI(form, "Mis Grupos de Viaje");
        }

        private void AbrirFormMisGrupos()
        {
            FormMisGrupos form = new FormMisGrupos();
            AbrirFormMDI(form, "Crear/Editar Grupo");
        }

        private void AbrirFormMDI(Form form, string titulo = "")
        {
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            if (!string.IsNullOrEmpty(titulo))
            {
                form.Text = titulo;
            }
            form.Show();
        }

        private void MostrarBienvenida()
        {
            string rol = Sesion.EsAdmin() ? "Administrador" : "Usuario";
            string mensaje = Sesion.EsAdmin()
                ? "Tienes acceso completo al sistema."
                : "Puedes gestionar tus grupos de viaje.";

            MessageBox.Show($"¡Bienvenido {Sesion.UsuarioActual.Nombre}!\n\nRol: {rol}\n\n{mensaje}",
                "Inicio de Sesión Exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void FormPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Dock = DockStyle.Fill;
            }
        }
    }
}