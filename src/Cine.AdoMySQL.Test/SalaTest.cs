using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;

namespace Cine.AdoMySQL.Test;
public class SalaTest
{
    public AdoCine AdoCine { get; set; }
    public SalaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "tests");
        AdoCine = new AdoCine(adoAGBD);
    }
    [Fact]
    public void AltaSala()
    {
        var sala = new Sala(1, 3, 200);
        AdoCine.AltaSala(sala);
        Assert.Equal(2, 4, 201);
    }
}