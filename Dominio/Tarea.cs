namespace Dominio
{
    public class Tarea : BaseClass
    {
        public string Nombre { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? Duracion { get; set; }
        public string Descripcion { get; set; }
        public EstadoTarea Estado { get; set; }
        public List<Gasto>? Gastos { get; set; }
        public Tarea() { }
    }
    public enum EstadoTarea
    {
        Activo,
        Pendiente
    }
}