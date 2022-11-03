namespace Cine.Core
{
    public class Pelicula
    {
        public ushort Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Estreno { get; set; }
        public Genero Genero { get; set; }

        public Pelicula(ushort id, string nombre, DateTime estreno, Genero genero)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Estreno = estreno;
            this.Genero = genero;
        }
    }
}