namespace Cine.Core;

public class Sala
{
    public byte NumSala { get; set; }
    public byte Piso { get; set; }
    public int Capacidad { get; set; }

    public List<Proyeccion> proyecciones { get; set; }

    public List<Pelicula> peliculas { get; set; }

    public Sala(byte NumSala, byte Piso, int Capacidad)
    {
        this.NumSala = NumSala;
        this.Piso = Piso;
        this.Capacidad = Capacidad;
        this.proyecciones = new List<Proyeccion>();
        this.peliculas = new List<Pelicula>();
    }
    public void agragarProyeccion(Proyeccion proyeccion) => this.proyecciones.Add(proyeccion);

    public void agregarPelicula(Pelicula pelicula) => this.peliculas.Add(pelicula);

    public void EliminarProyeccion(byte Id)
    {
        var pelicula = this.peliculas.SingleOrDefault(x => x.idPelicula == Id);
        if (pelicula is null)
            throw new Exception($"No existe esta pelicula{Id}.");

        this.peliculas.Remove(pelicula);
    }

}

