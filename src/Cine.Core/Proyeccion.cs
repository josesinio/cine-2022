namespace Cine.Core
{
    public class Proyeccion
    {
        public Guid Id { get; set; }
        public DateTime FechaHora { get; set; }
        public Pelicula pelicula { get; set; } = null!;
        public Sala sala { get; set; } = null!;

        public Proyeccion(Guid Id, DateTime FechaHora)
        {
            this.Id = Id;
            this.FechaHora = FechaHora;

        }
    }

}