﻿using API.Clients;
using DTOs;
using Microsoft.IdentityModel.Tokens;
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
    public partial class FormPlanNoAdmin : Form
    {
        private int grupoId;
        private List<PlanDTO> planesDelGrupo;

        public FormPlanNoAdmin(int grupoId)
        {
            InitializeComponent();
            this.grupoId = grupoId;
            this.Text = $"Gestión de Planes - Grupo ID: {grupoId}";
        }

        private async void FormPlanNoAdmin_Load(object sender, EventArgs e)
        {
            await CargarPlanes();
        }

        private async Task CargarPlanes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvPlanes.Rows.Clear();

                // Obtener todos los planes y filtrar por grupo (esto puede mejorarse con un endpoint específico)
                var todosLosPlanes = await PlanApiClient.GetAllAsync();
                planesDelGrupo = todosLosPlanes.ToList(); // Por ahora mostramos todos

                foreach (var plan in planesDelGrupo)
                {
                    dgvPlanes.Rows.Add(
                        plan.Id,
                        plan.Nombre,
                        plan.Descripcion,
                        plan.FechaInicio.ToString("dd/MM/yyyy"),
                        plan.FechaFin.ToString("dd/MM/yyyy")
                    );
                }

                lblContador.Text = $"{dgvPlanes.Rows.Count} planes encontrados";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnNuevoPlan_Click(object sender, EventArgs e)
        {
            CrearNuevoPlan();
        }

        private async void CrearNuevoPlan()
        {
            try
            {
                var nombre = txtNombre.Text.Trim();
                var descripcion = txtDescripcion.Text.Trim();

                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre del plan es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoPlan = new PlanCreateDTO
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    FechaInicio = DateOnly.FromDateTime(dtpFechaInicio.Value),
                    FechaBaja = DateOnly.FromDateTime(dtpFechaFin.Value),
                    FechaAlta = DateOnly.FromDateTime(DateTime.Now),
                    GrupoId = this.grupoId // ASIGNAR EL GRUPO ID
                };

                await PlanApiClient.AddAsync(nuevoPlan);

                MessageBox.Show("Plan creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                await CargarPlanes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear plan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddMonths(1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPlanes();
        }

        private void BuscarPlanes()
        {
            var textoBusqueda = txtBusqueda.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                dgvPlanes.Rows.Clear();
                foreach (var plan in planesDelGrupo)
                {
                    dgvPlanes.Rows.Add(
                        plan.Id,
                        plan.Nombre,
                        plan.Descripcion,
                        plan.FechaInicio.ToString("dd/MM/yyyy"),
                        plan.FechaFin.ToString("dd/MM/yyyy")
                    );
                }
            }
            else
            {
                dgvPlanes.Rows.Clear();
                var planesFiltrados = planesDelGrupo.Where(p =>
                    p.Nombre.ToLower().Contains(textoBusqueda) ||
                    p.Descripcion.ToLower().Contains(textoBusqueda)
                );

                foreach (var plan in planesFiltrados)
                {
                    dgvPlanes.Rows.Add(
                        plan.Id,
                        plan.Nombre,
                        plan.Descripcion,
                        plan.FechaInicio.ToString("dd/MM/yyyy"),
                        plan.FechaFin.ToString("dd/MM/yyyy")
                    );
                }
            }

            lblContador.Text = $"{dgvPlanes.Rows.Count} planes encontrados";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarPlanes();
        }
    }
}
