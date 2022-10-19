namespace Cine.Core
{
    public class Genero
    {
        public Guid Id {get; set;}
        public string? genero {get; set;}
    

    public  Genero(Guid id, string? genero)
        {
        this.Id = id;
        this.genero = genero;
        }


    }
}