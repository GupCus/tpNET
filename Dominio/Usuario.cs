using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Usuario : BaseClass
    {
        public List<Grupo> Grupos { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        //VER: como se manejan las contraseñas
        public string Contrasena { get; set; }


    }
}