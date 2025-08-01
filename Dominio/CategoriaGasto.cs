using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class CategoriaGasto : BaseClass
    {
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        // "Repositorio en memoria [TEMPORAL], con contador y metodo de acceso"
        public static readonly List<CategoriaGasto> RepoMemory = new(){
                new CategoriaGasto(1, "Alimentación","..."),
                new CategoriaGasto(2, "Transporte", "..."),
                new CategoriaGasto(3, "Salud", "..."),
                new CategoriaGasto(4, "Entretenimiento", "..."),
                new CategoriaGasto(5, "Vivienda", "...")
            };
        private static int ultimoId = 5;
        public static int ObtenerProximoId()
        {
            ultimoId += 1;
            return ultimoId - 1;
        }

        public CategoriaGasto(int id, string tipo, string desc)
        {
            Id = id;
            Tipo = tipo;
            Descripcion = desc;
        }

        public CategoriaGasto() { }
    }
}