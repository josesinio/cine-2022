using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp
{
    public class Pelicula
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public DateTime Estreno {get; set;} 
        public Genero Genero { get; set; }
    }
}