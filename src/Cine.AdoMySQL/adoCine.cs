using et12.edu.ar.AGBD.Ado;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores;

public class AdoCine
{
    public AdoAGBD Ado { get; set; }
    public MapGenero MapGenero { get; set; }
    public PeliculaMap PeliculaMap { get; set; }
    public MapProyeccion MapProyeccion { get; set; }
    public MapCliente MapCliente { get; set; }
    public AdoCine(AdoAGBD ado)
    {
        Ado = ado;
        MapGenero = new MapGenero(Ado);
        PeliculaMap = new PeliculaMap(ado);
        MapProyeccion = new MapProyeccion(ado);
        MapCliente = new MapCliente(ado);

    }
    public void AltaGenero(Genero genero) => MapGenero.AltaGenero(genero);
    public List<Genero> ObtenerGenero() => MapGenero.ColeccionDesdeTabla();

    public void AltaCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }
}
