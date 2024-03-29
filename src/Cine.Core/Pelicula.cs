namespace Cine.Core
{
    public class Pelicula
    {
        public ushort idPelicula { get; set; }
        public string nombre { get; set; }
        public DateTime estreno { get; set; }
        public byte IdGenero { get; set; }

        public Pelicula(ushort idPelicula, string nombre, DateTime estreno, byte IdGenero)
        {
            this.idPelicula = idPelicula;
            this.nombre = nombre;
            this.estreno = estreno;
            this.IdGenero = IdGenero;
        }
    }
}