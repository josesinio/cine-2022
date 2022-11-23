using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
namespace Cine.AdoMySQL.Test;
using et12.edu.ar.AGBD.Ado;

namespace Cine.AdoMySQL.Test;
public class PeliculaTest
{
    public AdoCine AdoCine { get; set; }
    public PeliculaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appeSetting.json", "test");
        AdoCine = new AdoCine(adoAGBD);
    }
    [Fact]
    public void AltaPelicula()
    {
        var pelicula = new Pelicula(1, "son como niños 2", new DateTime(2004 - 09 - 25), 1);
        AdoCine.AltaPelicula(pelicula);
        Assert.Equal(1, nombre, estreno, idGenero);
    }
}