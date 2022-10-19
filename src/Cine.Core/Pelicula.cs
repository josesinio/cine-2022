using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Pelicula
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Estreno { get; set; }
        public Genero Genero { get; set; }

        public Pelicula(Guid id, string? Nombre)
        {
            this.Id = id;
            this.Nombre = Nombre;
        }
    }
}