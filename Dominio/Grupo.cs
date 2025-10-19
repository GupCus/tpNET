namespace Dominio
{
    public class Grupo : BaseClass
    {
        public List<Usuario>? Usuarios { get; set; }

        public List<Plan>? Planes { get; set; }

        public string Nombre { get; set; }

    }
}
