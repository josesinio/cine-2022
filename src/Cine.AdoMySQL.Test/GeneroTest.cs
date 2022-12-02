using Cine.AdoMySQL.Mapeadores;
namespace Cine.AdoMySQL.Test;
using et12.edu.ar.AGBD.Ado;
using global::Cine.Core;

public class GeneroTest
{
    public AdoCine AdoCine { get; set; }
    public GeneroTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        AdoCine = new AdoCine(adoAGBD);
    }
    [Fact]
    public void AltaGenero()
    {
        var genero = new Genero(5, "Romance");
        var elementos = AdoCine.MapGenero.ColeccionDesdeTabla().Count;
        AdoCine.AltaGenero(genero);
        var elementosnuevos = AdoCine.MapGenero.ColeccionDesdeTabla().Count;
        Assert.Equal(elementos + 1, elementosnuevos);
    }
}