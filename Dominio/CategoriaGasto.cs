namespace Dominio
{
    public class CategoriaGasto : BaseClass
    {
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public CategoriaGasto(int id, string tipo, string desc)
        {
            Id = id;
            Tipo = tipo;
            Descripcion = desc;
        }

        public CategoriaGasto() { }
    }
}