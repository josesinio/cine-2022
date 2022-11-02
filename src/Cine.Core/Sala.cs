namespace Cine.Core;

public class Sala
{
    public byte NumSala { get; set; }
    public byte Piso { get; set; }
    public int Capacidad { get; set; }

    public List<Proyeccion> proyecciones { get; set; }

    public List<Pelicula> peliculas { get; set; }

    public Sala(byte numSala, byte piso, int capacidad)
    {
        this.NumSala = numSala;
        this.Piso = piso;
        this.Capacidad = capacidad;
        this.proyecciones = new List<Proyeccion>();
        this.peliculas = new List<Pelicula>();
    }
    public void agragarProyeccion(Proyeccion proyeccion) => this.proyecciones.Add(proyeccion);

    public void agregarPelicula(Pelicula pelicula) => this.peliculas.Add(pelicula);

    public void EliminarProyeccion(Guid Id)
    {
        var peli = this.peliculas.SingleOrDefault(x => x.numSala ==  NumSala);
        if (peli is null)
            throw new Exception($"No existe esta pelicula{Id}.");

        this.peliculas.Remove(peli);
    }

}

