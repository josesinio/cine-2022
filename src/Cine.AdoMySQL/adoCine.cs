using et12.edu.ar.AGBD.Ado;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores;

public class AdoCine : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapGenero MapGenero { get; set; }
    public PeliculaMap PeliculaMap { get; set; }
    public MapProyeccion MapProyeccion { get; set; }
    public MapCliente MapCliente { get; set; }
    public MapSala MapSala { get; set; }
    public MapEntrada MapEntrada { get; set; }
    public AdoCine(AdoAGBD ado)
    {
        Ado = ado;
        MapGenero = new MapGenero(ado);
        PeliculaMap = new PeliculaMap(MapGenero);
        MapSala = new MapSala(ado);
        MapProyeccion = new MapProyeccion(MapSala, PeliculaMap);
        MapCliente = new MapCliente(ado);
        MapEntrada = new MapEntrada(ado);

    }

    public void AltaGenero(Genero genero)
        => MapGenero.AltaGenero(genero);
    public List<Genero> ObtenerGenero()
        => MapGenero.ColeccionDesdeTabla();

    public void AltaSala(Sala sala)
        => MapSala.AltaSAla(sala);

    public List<Sala> ObtenerSala()
        => MapSala.ColeccionDesdeTabla();
    public void AltaPelicula(Pelicula pelicula)
        => PeliculaMap.AltaPelicula(pelicula);

    public List<Pelicula> ObtenerPelicula()
        => PeliculaMap.ColeccionDesdeTabla();

    public void AltaProyeccion(Proyeccion proyeccion)
        => MapProyeccion.AltaProyeccion(proyeccion);

    public List<Proyeccion> ObtenerProyeccion()
        => MapProyeccion.ColeccionDesdeTabla();

    public void AltaCliente(Cliente cliente)
        => MapCliente.AltaCliente(cliente);

    public List<Cliente> ObtenerCliente()
        => MapCliente.ColeccionDesdeTabla();

    public void AltaEntrada(Entrada entrada)
        => MapEntrada.AltaEntrada(entrada);

    public List<Entrada> ObtenerEntrada()
        => MapEntrada.ColeccionDesdeTabla();

    public Proyeccion ProyeccionPorId(byte id)
        => MapProyeccion.ProyeccionPorId(id);

    public List<Entrada> EntradasCliente()
        => MapEntrada.ColeccionDesdeSP();
}
