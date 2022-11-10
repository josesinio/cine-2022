using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
namespace Cine.AdoMySQL.Test;

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
        var genero = new Genero(1, "Accion");
        AdoCine.AltaGenero(genero);
        Assert.Equal(3, genero.Id);
    }
}