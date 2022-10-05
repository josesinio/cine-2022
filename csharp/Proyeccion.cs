using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp
{
    public class Proyeccion
    {
        public int Id {get; set;}
        public int FechaHora {get; set;}
        public Pelicula Pelicula {get; set;}
        public Sala Sala {get; set;}
    }
    public void AgregarEntrada(int NumEntrada) =>
    
        this.Entradas.add(new Entrada(NumEntrada));
    
    
    
    

}