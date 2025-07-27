namespace Dominio
{
    public class Grupo
    {
        public int Id { get; set; }
        public List<Participante> Participantes { get; set; }

        public List<Plan> Planes { get; set; }

        public string Nombre { get; set; }
        
    }
}
