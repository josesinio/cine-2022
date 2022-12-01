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
        var genero = new Genero(4, "Accion");
        AdoCine.AltaGenero(genero);
        Assert.Equal(3, genero.Id);
    }
}