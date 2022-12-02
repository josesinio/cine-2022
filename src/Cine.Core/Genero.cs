namespace Cine.Core
{
    public class Genero
    {
        public byte Id { get; set; }
        public string? genero { get; set; }

        public Genero(byte Id, string genero)
        {
            this.Id = Id;
            this.genero = genero;
        }
    }
}