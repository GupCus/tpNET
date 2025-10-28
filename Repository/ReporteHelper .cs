using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio.Dominio;

namespace Dominio.Repository  
{
    public class ReporteHelper
    {
        private readonly DbContext _context;

        public ReporteHelper(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Método original corregido
        public decimal GetTotalGastadoPorUsuarioEnGrupo(int usuarioId, int grupoId)
        {
            if (usuarioId <= 0) throw new ArgumentException("ID de usuario inválido", nameof(usuarioId));
            if (grupoId <= 0) throw new ArgumentException("ID de grupo inválido", nameof(grupoId));

            return _context.Set<Gasto>()
                .Where(g => g.UsuarioId == usuarioId &&
                           g.Tarea != null &&
                           g.Tarea.Plan != null &&
                           g.Tarea.Plan.GrupoId == grupoId)
                .Sum(g => (decimal)g.Monto);
        }

        // Versión asíncrona
        public async Task<decimal> GetTotalGastadoPorUsuarioEnGrupoAsync(int usuarioId, int grupoId)
        {
            if (usuarioId <= 0) throw new ArgumentException("ID de usuario inválido", nameof(usuarioId));
            if (grupoId <= 0) throw new ArgumentException("ID de grupo inválido", nameof(grupoId));

            return await _context.Set<Gasto>()
                .Where(g => g.UsuarioId == usuarioId &&
                           g.Tarea != null &&
                           g.Tarea.Plan != null &&
                           g.Tarea.Plan.GrupoId == grupoId)
                .SumAsync(g => (decimal)g.Monto);
        }

        // ... (todos los demás métodos se mantienen igual)
        // Métodos adicionales útiles para reportes

        public decimal GetTotalGastadoPorUsuario(int usuarioId)
        {
            if (usuarioId <= 0) throw new ArgumentException("ID de usuario inválido", nameof(usuarioId));

            return _context.Set<Gasto>()
                .Where(g => g.UsuarioId == usuarioId)
                .Sum(g => (decimal)g.Monto);
        }

        public decimal GetTotalGastadoPorGrupo(int grupoId)
        {
            if (grupoId <= 0) throw new ArgumentException("ID de grupo inválido", nameof(grupoId));

            return _context.Set<Gasto>()
                .Where(g => g.Tarea != null &&
                           g.Tarea.Plan != null &&
                           g.Tarea.Plan.GrupoId == grupoId)
                .Sum(g => (decimal)g.Monto);
        }

        public Dictionary<int, decimal> GetGastosPorUsuarioEnGrupo(int grupoId)
        {
            if (grupoId <= 0) throw new ArgumentException("ID de grupo inválido", nameof(grupoId));

            return _context.Set<Gasto>()
                .Where(g => g.Tarea != null &&
                           g.Tarea.Plan != null &&
                           g.Tarea.Plan.GrupoId == grupoId)
                .GroupBy(g => g.UsuarioId)
                .ToDictionary(g => g.Key, g => g.Sum(x => (decimal)x.Monto));
        }

        // ... resto de los métodos igual
    }

    // Clase para el balance completo
    public class BalanceUsuario
    {
        public decimal TotalGastado { get; set; }
        public decimal PorcentajeDelTotal { get; set; }
        public decimal PromedioGrupo { get; set; }
        public decimal DiferenciaConPromedio { get; set; }
        public int NumeroUsuariosEnGrupo { get; set; }
        public decimal TotalGastadoGrupo { get; set; }
    }
}