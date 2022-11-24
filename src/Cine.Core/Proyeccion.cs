namespace Cine.Core
{
    public class Proyeccion
    {
        public ushort id { get; set; }
        public DateTime fechaHora { get; set; }
        public ushort IdPelicula { get; set; }
        public byte IdSala { get; set; }

        public Proyeccion(ushort id, DateTime fechaHora, ushort IdPelicula, byte IdSala)
        {
            this.id = id;
            this.fechaHora = fechaHora;
            this.IdPelicula = IdPelicula;
            this.IdSala = IdSala;
        }
    }

}