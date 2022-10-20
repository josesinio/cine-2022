namespace Cine.Core
{
    public class Pelicula
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Estreno { get; set; }
        public Genero Genero { get; set; }

        public Pelicula(Guid id, string Nombre, DateTime Estreno, Genero genero)
        {
            this.Id = id;
            this.Nombre = Nombre;
            this.Estreno = Estreno;
            this.Genero = Genero;
        }
    }
}