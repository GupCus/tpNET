using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Tarea : BaseClass
    {
        public string Nombre { get; set; }
        public DateTime? FechaHora { get; set; }
        public TimeOnly? Duracion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        //public List<Gasto> Gastos { get; set; }

        // "Repositorio en memoria [TEMPORAL], con contador y metodo de acceso"
        public static readonly List<Tarea> RepoMemory = new List<Tarea>
            {
                new Tarea(1, "Revisar emails", "Revisar y responder emails pendientes", "Pendiente"),
                new Tarea(2, "Reunión equipo", "Reunión semanal del equipo", "Pendiente"),
                new Tarea(3, "Documentar API", "Crear documentación de la API", "Completada"),
                new Tarea(4, "Testing", "Pruebas unitarias", "En Progreso")
            };
        private static int ultimoId = 0;
        public static int ObtenerProximoId()
        {
            ultimoId += 1;
            return ultimoId - 1;
        }

        public Tarea(int id, string nombre, string descripcion, string estado)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Estado = estado;
        }
        public Tarea() { }
    }
}