using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Repository;
using DTOs;

namespace Services
{
    public interface IReporteService
    {
        Task<ReporteGastosGrupoDto> ObtenerReporteGastosPorGrupo(int grupoId);
    }

    public class ReporteService : IReporteService
    {
        private readonly GastoRepository _gastoRepository;
        private readonly GrupoRepository _grupoRepository;
        private readonly UsuarioRepository _usuarioRepository;

        public ReporteService()
        {
            _gastoRepository = new GastoRepository();
            _grupoRepository = new GrupoRepository();
            _usuarioRepository = new UsuarioRepository();
        }

        public async Task<ReporteGastosGrupoDto> ObtenerReporteGastosPorGrupo(int grupoId)
        {
            // Obtener el grupo usando tu repository existente
            var grupo = _grupoRepository.Get(grupoId);
            if (grupo == null)
                throw new ArgumentException($"No se encontró el grupo con ID {grupoId}");

            // Obtener usuarios del grupo
            var usuariosGrupo = _usuarioRepository.GetUsuariosPorGrupo(grupoId);
            var reporte = new ReporteGastosGrupoDto
            {
                NombreGrupo = grupo.Nombre,
                FechaGeneracion = DateTime.Now,
                GastosUsuarios = new List<ReporteGastosUsuarioDto>()
            };

            // Calcular gastos por usuario
            foreach (var usuario in usuariosGrupo)
            {
                var totalGastado = _gastoRepository.GetTotalGastadoPorUsuarioEnGrupo(usuario.Id, grupoId);

                reporte.GastosUsuarios.Add(new ReporteGastosUsuarioDto
                {
                    NombreUsuario = usuario.Nombre,
                    Mail = usuario.Mail,
                    TotalGastado = totalGastado
                });
            }

            return await Task.FromResult(reporte);
        }
    }
}