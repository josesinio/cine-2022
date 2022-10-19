namespace Cine.Core
{
    public class Genero
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public Genero() { }
        public Genero(byte id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}