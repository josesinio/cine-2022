namespace Cine.Core
{
    public class Proyeccion
    {
        public ushort id { get; set; }
        public DateTime fechaHora { get; set; }
        public Pelicula pelicula { get; set; } = null!;
        public Sala sala { get; set; } = null!;

        public Proyeccion(ushort id, DateTime fechaHora, Pelicula pelicula, Sala sala)
        {
            this.id = id;
            this.fechaHora = fechaHora;
            this.pelicula = pelicula;
            this.sala = sala;
        }
    }

}