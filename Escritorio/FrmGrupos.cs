using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FrmGrupos : Form
    {
        private int usuarioId;
        private ContextMenuStrip menuContextual;

        public FrmGrupos(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            this.Text = $"Mis Grupos - {Sesion.UsuarioActual.Nombre}";

            ConfigurarColumnasDataGridView();
            ConfigurarMenuContextual();

            _ = CargarGrupos();
        }

        private void ConfigurarMenuContextual()
        {
            menuContextual = new ContextMenuStrip();

            var itemPlan = new ToolStripMenuItem("📅 Crear Nuevo Plan");
            var itemTarea = new ToolStripMenuItem("✅ Crear Nueva Tarea");
            var itemGasto = new ToolStripMenuItem("💰 Registrar Gasto");

            itemPlan.Click += (s, e) => CrearPlan();
            itemTarea.Click += (s, e) => CrearTarea();
            itemGasto.Click += (s, e) => CrearGasto();

            menuContextual.Items.AddRange(new ToolStripItem[] { itemPlan, itemTarea, itemGasto });

            dgvGrupos.ContextMenuStrip = menuContextual;
        }

        private void ConfigurarColumnasDataGridView()
        {
            dgvGrupos.Columns.Clear();

            dgvGrupos.Columns.Add("colId", "ID");
            dgvGrupos.Columns.Add("colNombre", "Nombre");
            dgvGrupos.Columns.Add("colDescripcion", "Descripción");
            dgvGrupos.Columns.Add("colFechaAlta", "Fecha Alta");
            dgvGrupos.Columns.Add("colCantUsuarios", "Participantes");
            dgvGrupos.Columns.Add("colRol", "Mi Rol");

            dgvGrupos.Columns["colId"].Visible = false;
            dgvGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void FrmGrupos_Load(object sender, EventArgs e)
        {
            await CargarGrupos();
        }

        private async Task CargarGrupos()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvGrupos.Rows.Clear();

                var grupos = await GrupoApiClient.GetByUsuarioAsync(usuarioId);

                if (grupos == null || !grupos.Any())
                {
                    lblContador.Text = "0 grupos encontrados";
                    MessageBox.Show("No tienes grupos asignados. ¡Crea tu primer grupo!",
                        "Sin grupos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var grupo in grupos)
                {
                    dgvGrupos.Rows.Add(
                        grupo.Id,
                        grupo.Nombre ?? "Sin nombre",
                        grupo.Descripcion ?? "Sin descripción",
                        grupo.FechaAlta.ToString("dd/MM/yyyy"),
                        grupo.Usuarios?.Count ?? 0,
                        grupo.IdUsuarioAdministrador == usuarioId ? "Administrador" : "Miembro"
                    );
                }

                lblContador.Text = $"{dgvGrupos.Rows.Count} grupos encontrados";
                dgvGrupos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar grupos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            var frmNuevoGrupo = new FormMisGrupos();
            frmNuevoGrupo.FormClosed += async (s, args) =>
            {
                await CargarGrupos();
            };
            frmNuevoGrupo.ShowDialog();
        }

        private void CrearPlan()
        {
            if (dgvGrupos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un grupo primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var grupoId = Convert.ToInt32(dgvGrupos.CurrentRow.Cells["colId"].Value);
            var grupoNombre = dgvGrupos.CurrentRow.Cells["colNombre"].Value.ToString();

            try
            {
                var frmPlan = new FormPlanNoAdmin(grupoId);
                frmPlan.Text = $"📅 Crear Plan - Grupo: {grupoNombre}";
                frmPlan.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de Plan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearTarea()
        {
            if (dgvGrupos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un grupo primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var grupoId = Convert.ToInt32(dgvGrupos.CurrentRow.Cells["colId"].Value);
            var grupoNombre = dgvGrupos.CurrentRow.Cells["colNombre"].Value.ToString();

            try
            {
                var frmTarea = new FormTareaNoAdmin(grupoId);
                frmTarea.Text = $"✅ Crear Tarea - Grupo: {grupoNombre}";
                frmTarea.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de Tarea: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearGasto()
        {
            if (dgvGrupos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un grupo primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var grupoId = Convert.ToInt32(dgvGrupos.CurrentRow.Cells["colId"].Value);
            var grupoNombre = dgvGrupos.CurrentRow.Cells["colNombre"].Value.ToString();

            try
            {
                var frmGasto = new FormGastoNoAdmin(grupoId);
                frmGasto.Text = $"💰 Registrar Gasto - Grupo: {grupoNombre}";
                frmGasto.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de Gasto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccionesRapidas_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un grupo primero", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var grupoNombre = dgvGrupos.CurrentRow.Cells["colNombre"].Value.ToString();
            MostrarPanelOpciones(grupoNombre);
        }

        private void MostrarPanelOpciones(string grupoNombre)
        {
            var panelOpciones = new Panel
            {
                Size = new Size(300, 200),
                Location = new Point(
                    (this.Width - 300) / 2,
                    (this.Height - 200) / 2
                ),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = true
            };

            var lblTitulo = new Label
            {
                Text = $"Acciones para:\n{grupoNombre}",
                Location = new Point(10, 10),
                Size = new Size(280, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var btnPlan = new Button { Text = "📅 Crear Plan", Location = new Point(50, 60), Size = new Size(200, 30) };
            var btnTarea = new Button { Text = "✅ Crear Tarea", Location = new Point(50, 100), Size = new Size(200, 30) };
            var btnGasto = new Button { Text = "💰 Registrar Gasto", Location = new Point(50, 140), Size = new Size(200, 30) };

            btnPlan.Click += (s, e) => { this.Controls.Remove(panelOpciones); CrearPlan(); };
            btnTarea.Click += (s, e) => { this.Controls.Remove(panelOpciones); CrearTarea(); };
            btnGasto.Click += (s, e) => { this.Controls.Remove(panelOpciones); CrearGasto(); };

            panelOpciones.Controls.AddRange(new Control[] { lblTitulo, btnPlan, btnTarea, btnGasto });
            this.Controls.Add(panelOpciones);
            panelOpciones.BringToFront();
        }

        private void dgvGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var grupoNombre = dgvGrupos.CurrentRow.Cells["colNombre"].Value.ToString();
                MostrarPanelOpciones(grupoNombre);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarGrupos();
        }
    }
}