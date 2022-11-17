using et12.edu.ar.AGBD.Ado;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores;

public class AdoCine
{
    public AdoAGBD Ado { get; set; }
    public MapGenero MapGenero { get; set; }
    public AdoCine(AdoAGBD ado)
    {
        Ado = ado;
        MapGenero = new MapGenero(Ado);
    }
    public void AltaGenero(Genero genero) => MapGenero.AltaGenero(genero);
    public List<Genero> ObtenerGenero() => MapGenero.ColeccionDesdeTabla();

    public void AltaSala(Sala sala)
    {
        throw new NotImplementedException();
    }

    public void altaPelicula(Pelicula pelicula)
    {
        throw new NotImplementedException();
    }

    public void AltaPelicula(Pelicula pelicula)
    {
        throw new NotImplementedException();
    }
}
