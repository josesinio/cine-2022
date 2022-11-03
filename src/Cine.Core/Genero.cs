namespace Cine.Core
{
    public class Genero
    {
        public byte Id { get; set; }
        public string? Nombre { get; set; }

        public Genero(byte Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
        }
    }
}