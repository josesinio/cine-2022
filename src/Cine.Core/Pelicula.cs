namespace Cine.Core
{
    public class Pelicula
    {
        public ushort idPelcula { get; set; }
        public string nombre { get; set; }
        public DateTime estreno { get; set; }
        public Genero genero { get; set; }

        public Pelicula(ushort idPelicula, string nombre, DateTime estreno, Genero genero)
        {
            this.idPelcula = idPelicula;
            this.nombre = nombre;
            this.estreno = estreno;
            this.genero = genero;
        }
    }
}