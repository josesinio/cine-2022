using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp
{
    public class Sala
    {
        public int NumSala {get; set;}
        public int Piso {get; set;}
        public int Capacidad {get; set;}
    }
    public Sala(int NumSala, int Piso, int capacidad)
    {
        this.NumSala = NumSala;
        this.Piso = Piso;
        this.Capacidad = Capacidad;
    }
}

