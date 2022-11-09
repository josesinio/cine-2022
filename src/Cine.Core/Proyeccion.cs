namespace Cine.Core
{
    public class Proyeccion
    {
        public ushort Id { get; set; }
        public DateTime FechaHora { get; set; }
        public Pelicula pelicula { get; set; } = null!;
        public Sala sala { get; set; } = null!;

        public Proyeccion(ushort Id, DateTime FechaHora, Sala sala)
        {
            this.Id = Id;
            this.FechaHora = FechaHora;
            this.sala = sala;
        }
    }

}