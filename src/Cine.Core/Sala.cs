using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Sala
    {
        public Guid NumSala {get; set;}
        public int Piso {get; set;}
        public int Capacidad {get; set;}
    
    public Sala(Guid NumSala, int Piso, int capacidad)
    {
        this.NumSala = NumSala;
        this.Piso = Piso;
        this.Capacidad = Capacidad;
    }
    public void agragarProyeccion (Proyeccion proyeccion) => this.proyecciones.Add(proyeccion);

    public void agregarPelicula(Pelicula pelicula) => this.peliculas.Add(pelicula);
}

