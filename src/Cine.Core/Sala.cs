using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Sala
    {
        public Guid NumSala {get; set;}
        public int   Piso {get; set;}
        public int Capacidad {get; set;}

        public List<Proyeccion> proyecciones  {get; set;}

        public List<Pelicula> peliculas {get; set;}

        
    
    public Sala(Guid NumSala, int Piso, int capacidad)
    {
        this.NumSala = NumSala;
        this.Piso = Piso;
        this.Capacidad = Capacidad;
        this.proyecciones = new List<Proyeccion>();
        this.peliculas= new List<Pelicula>();
    }
    public void agragarProyeccion (Proyeccion proyeccion) => this.proyecciones.Add(proyeccion);

    public void agregarPelicula(Pelicula pelicula) => this.peliculas.Add(pelicula);
    
    public void EliminarProyeccion (Guid id)
    {
        var peli= this.peliculas.SingleOrDefault(x=> x.Id == id );
        if (peli is null)
            throw new Exception($"No existe esta pelicula{id}.");
        
        this.peliculas.Remove(peli);
    }

    }
}

