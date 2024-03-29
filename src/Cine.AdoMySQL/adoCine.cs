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
    public async Task AltaGeneroAsync(Genero genero)
        => await MapGenero.AltaGeneroAsync(genero);
    public List<Genero> ObtenerGenero()
        => MapGenero.ColeccionDesdeTabla();

    public void AltaSala(Sala sala)
        => MapSala.AltaSAla(sala);

    public async Task AltaSalaAsync(Sala sala)
        => await MapSala.AltaSalaAsync(sala);

    public List<Sala> ObtenerSala()
        => MapSala.ColeccionDesdeTabla();
    public void AltaPelicula(Pelicula pelicula)
        => PeliculaMap.AltaPelicula(pelicula);

    public async Task AltaPeliculaAsync(Pelicula pelicula)
        => await PeliculaMap.AltaPeliculaAsync(pelicula);

    public List<Pelicula> ObtenerPelicula()
        => PeliculaMap.ColeccionDesdeTabla();

    public void AltaProyeccion(Proyeccion proyeccion)
        => MapProyeccion.AltaProyeccion(proyeccion);

    public async Task AltaProyeccionAsync(Proyeccion proyeccion)
        => await MapProyeccion.AltaProyeccionAsync(proyeccion);

    public List<Proyeccion> ObtenerProyeccion()
        => MapProyeccion.ColeccionDesdeTabla();

    public void AltaCliente(Cliente cliente)
        => MapCliente.AltaCliente(cliente);

    public async Task AltaClienteAsync(Cliente cliente)
        => await MapCliente.AltaClienteAsync(cliente);

    public List<Cliente> ObtenerCliente()
        => MapCliente.ColeccionDesdeTabla();

    public void AltaEntrada(Entrada entrada)
        => MapEntrada.AltaEntrada(entrada);

    public async Task AltaEntradaAsync(Entrada entrada)
        => await MapEntrada.AltaEntradaAsync(entrada);

    public List<Entrada> ObtenerEntrada()
        => MapEntrada.ColeccionDesdeTabla();

    public Proyeccion ProyeccionPorId(ushort id)
        => MapProyeccion.ProyeccionPorId(id);

    public List<Entrada> EntradasCliente(byte id)
        => MapEntrada.ColeccionDesdeSP();

    public void EntradasCliente(Entrada entrada)
        => MapEntrada.ColeccionDesdeTabla();

}
