namespace Cine.Core
{
    public class Pelicula
    {
        public ushort id { get; set; }
        public string nombre { get; set; }
        public DateTime estreno { get; set; }
        public Genero genero { get; set; }

        public Pelicula(ushort id, string nombre, DateTime estreno, Genero genero)
        {
            this.id = id;
            this.nombre = nombre;
            this.estreno = estreno;
            this.genero = genero;
        }
    }
}