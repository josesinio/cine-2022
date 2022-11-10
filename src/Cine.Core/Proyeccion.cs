namespace Cine.Core
{
    public class Proyeccion
    {
        public ushort id { get; set; }
        public DateTime fechaHora { get; set; }
        public Pelicula pelicula { get; set; } = null!;
        public Sala sala { get; set; } = null!;

        public Proyeccion(ushort id, DateTime fechaHora, Sala sala)
        {
            this.id = id;
            this.fechaHora = fechaHora;
            this.sala = sala;
        }
    }

}