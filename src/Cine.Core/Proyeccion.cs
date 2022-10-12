using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Proyeccion
    {
        public int Id {get; set;}
        public DateTime FechaHora {get; set;}
        public Pelicula Pelicula {get; set;}
        public Sala Sala {get; set;}
    }

    public void  Proyeccion (int id, DateTime FechaHora)
    { 
        this.id = id;
        this.FechaHora = FechaHora;


    }

}