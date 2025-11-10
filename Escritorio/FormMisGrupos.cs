using API.Clients;
using DTOs;
using System.Diagnostics;

namespace Escritorio
{
    public partial class FormMisGrupos : Form
    {
        private bool confirma = false;
        private GrupoDTO? grupoSeleccionado = null;

        public FormMisGrupos()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewGrupos.AutoGenerateColumns = false;
            dataGridViewGrupos.Columns.Clear();

            dataGridViewGrupos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60,
                ReadOnly = true
            });

            dataGridViewGrupos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Nombre",
                DataPropertyName = "Nombre",
                HeaderText = "Nombre del Grupo",
                Width = 200,
                ReadOnly = true
            });

            dataGridViewGrupos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Descripcion",
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Width = 250,
                ReadOnly = true
            });

            dataGridViewGrupos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FechaAlta",
                DataPropertyName = "FechaAlta",
                HeaderText = "Fecha de Alta",
                Width = 120,
                ReadOnly = true
            });

            dataGridViewGrupos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "IdUsuarioAdministrador",
                DataPropertyName = "IdUsuarioAdministrador",
                HeaderText = "ID Admin",
                Width = 80,
                ReadOnly = true
            });
        }

        private async Task CargarMisGrupos()
        {
            try
            {
                int idAdmin = Sesion.UsuarioActual?.Id ?? 0;
                if (idAdmin == 0)
                {
                    MessageBox.Show("Debes iniciar sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var grupos = await GrupoApiClient.GetByAdministradorAsync(idAdmin);

                dataGridViewGrupos.DataSource = null;
                dataGridViewGrupos.DataSource = grupos.ToList();

                this.Text = $"Mis Grupos - Administrador ({grupos.Count()} grupos)";

                ActualizarEstadoControles();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
                MessageBox.Show($"Error al cargar grupos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadoControles()
        {
            bool hayGrupoSeleccionado = grupoSeleccionado != null;
            bool modoEdicion = !string.IsNullOrEmpty(txtID.Text);

            btnEditar.Enabled = hayGrupoSeleccionado && modoEdicion;
            btnEliminar.Enabled = hayGrupoSeleccionado;
            btnAgregarUsuario.Enabled = hayGrupoSeleccionado;
            txtUsuarioMail.Enabled = hayGrupoSeleccionado;


            if (dataGridViewGrupos.Rows.Count == 0)
            {
                lblEstado.Text = "No tienes grupos como administrador";
            }
            else
            {
                lblEstado.Text = $"Selecciona un grupo para editarlo ({dataGridViewGrupos.Rows.Count} grupos encontrados)";
            }


            if (!hayGrupoSeleccionado && string.IsNullOrEmpty(txtNombre.Text))
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtUsuarioMail.Text = "";
            grupoSeleccionado = null;
        }

        private GrupoDTO ObtenerGrupoDelFormulario()
        {
            var grupo = new GrupoDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            if (!string.IsNullOrEmpty(txtID.Text))
            {
                // If there's an ID in the textbox we treat it as editing an existing group.
                // Note: callers (e.g. btnCrear) may override Id/IdUsuarioAdministrador/FechaAlta explicitly when needed.
                grupo.Id = int.Parse(txtID.Text);
            }
            else
            {
                // New group: set admin and creation date
                grupo.IdUsuarioAdministrador = Sesion.UsuarioActual?.Id ?? 0;
                grupo.FechaAlta = DateTime.Now;
            }

            // Safety: if for any reason IdUsuarioAdministrador wasn't set above, ensure it's filled from session
            if (grupo.IdUsuarioAdministrador == 0)
            {
                grupo.IdUsuarioAdministrador = Sesion.UsuarioActual?.Id ?? 0;
            }

            return grupo;
        }

        private bool ValidarGrupo(GrupoDTO grupo)
        {
            if (string.IsNullOrWhiteSpace(grupo.Nombre))
            {
                MessageBox.Show("El nombre del grupo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (grupo.IdUsuarioAdministrador == 0)
            {
                MessageBox.Show("No se pudo identificar al administrador del grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private async void FormMisGrupos_Load(object sender, EventArgs e)
        {
            await CargarMisGrupos();
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure that creating a new group does not accidentally reuse the currently selected group's ID.
                // For example, if the user previously selected a group, txtID may have a value; when creating we must ignore it.
                var grupo = ObtenerGrupoDelFormulario();

                // Force creation semantics: reset Id (so the server creates a new entity) and ensure the admin comes from the current session.
                grupo.Id = 0;
                grupo.IdUsuarioAdministrador = Sesion.UsuarioActual?.Id ?? 0;
                grupo.FechaAlta = DateTime.Now;

                if (!ValidarGrupo(grupo))
                    return;

                await GrupoApiClient.AddAndReturnAsync(grupo);
                MessageBox.Show("Grupo creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                await CargarMisGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear grupo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un grupo para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var grupo = ObtenerGrupoDelFormulario();
                grupo.Id = grupoSeleccionado.Id;
                grupo.IdUsuarioAdministrador = grupoSeleccionado.IdUsuarioAdministrador;
                grupo.FechaAlta = grupoSeleccionado.FechaAlta;

                if (!ValidarGrupo(grupo))
                    return;

                await GrupoApiClient.UpdateAsync(grupo);
                MessageBox.Show("Grupo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarMisGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar grupo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
                return;

            if (!confirma)
            {
                btnEliminar.Text = "¿CONFIRMAR ELIMINACIÓN?";
                btnEliminar.BackColor = Color.Red;
                btnEliminar.ForeColor = Color.White;
                confirma = true;
                return;
            }

            try
            {
                var resultado = MessageBox.Show(
                    $"¿Estás seguro de eliminar el grupo '{grupoSeleccionado.Nombre}'? Esta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    await GrupoApiClient.DeleteAsync(grupoSeleccionado.Id);
                    MessageBox.Show("Grupo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    await CargarMisGrupos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar grupo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ResetearBotonEliminar();
            }
        }

        private void ResetearBotonEliminar()
        {
            btnEliminar.Text = "ELIMINAR GRUPO";
            btnEliminar.BackColor = SystemColors.Control;
            btnEliminar.ForeColor = SystemColors.ControlText;
            confirma = false;
        }

        private async void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un grupo primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mail = txtUsuarioMail.Text.Trim();
            if (string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("Ingrese el mail del usuario a agregar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioMail.Focus();
                return;
            }

            try
            {

                var usuarioAAgregar = await UsuarioApiClient.GetByMailAsync(mail);

                if (usuarioAAgregar == null)
                {
                    MessageBox.Show("Usuario no encontrado. Verifique el email ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                bool usuarioYaEnGrupo = false;
                try
                {
                    var usuariosDelGrupo = await UsuarioGrupoApiClient.GetUsuariosDeGrupoAsync(grupoSeleccionado.Id);
                    usuarioYaEnGrupo = usuariosDelGrupo.Any(u => u.Id == usuarioAAgregar.Id);
                }
                catch (Exception ex)
                {

                    Debug.WriteLine($"Advertencia: No se pudo verificar usuarios del grupo: {ex.Message}");
                    usuarioYaEnGrupo = false;
                }

                if (usuarioYaEnGrupo)
                {
                    MessageBox.Show("El usuario ya está en el grupo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                var relacion = new UsuarioGrupoDTO
                {
                    UsuarioId = usuarioAAgregar.Id,
                    GrupoId = grupoSeleccionado.Id
                };

                await UsuarioGrupoApiClient.AddAsync(relacion);
                MessageBox.Show($"Usuario '{usuarioAAgregar.Nombre}' agregado correctamente al grupo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuarioMail.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar usuario al grupo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewGrupos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewGrupos.CurrentRow != null &&
                dataGridViewGrupos.CurrentRow.DataBoundItem is GrupoDTO grupo)
            {
                grupoSeleccionado = grupo;
                txtID.Text = grupo.Id.ToString();
                txtNombre.Text = grupo.Nombre;
                txtDescripcion.Text = grupo.Descripcion;

                if (confirma)
                {
                    ResetearBotonEliminar();
                }
            }
            else
            {
                grupoSeleccionado = null;
            }

            ActualizarEstadoControles();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            dataGridViewGrupos.ClearSelection();
            ActualizarEstadoControles();
        }

        private void txtUsuarioMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregarUsuario_Click(sender, e);
                e.Handled = true;
            }
        }

        private void dataGridViewGrupos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewGrupos.Columns[e.ColumnIndex].Name == "FechaAlta" && e.Value != null)
            {
                if (e.Value is DateTime fecha)
                {
                    e.Value = fecha.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un grupo primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuariosDelGrupo = UsuarioGrupoApiClient.GetUsuariosDeGrupoAsync(grupoSeleccionado.Id).Result;
                if (usuariosDelGrupo.Any())
                {
                    string usuarios = string.Join("\n", usuariosDelGrupo.Select(u => $"- {u.Nombre} ({u.Mail})"));
                    MessageBox.Show($"Usuarios en el grupo '{grupoSeleccionado.Nombre}':\n\n{usuarios}",
                        "Usuarios del Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El grupo no tiene usuarios aún.", "Usuarios del Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener usuarios del grupo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}