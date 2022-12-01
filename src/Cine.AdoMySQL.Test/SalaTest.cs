using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;

namespace Cine.AdoMySQL.Test;
public class SalaTest
{
    public AdoCine AdoCine { get; set; }
    public SalaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        AdoCine = new AdoCine(adoAGBD);
    }
    [Fact]
    public void AltaSala()
    {
        var sala = new Sala(4, 3, 200);
        var elementos = AdoCine.MapSala.ColeccionDesdeTabla().Count;

        AdoCine.AltaSala(sala);
        var elementosnuevos = AdoCine.MapSala.ColeccionDesdeTabla().Count;

        Assert.Equal(elementosnuevos, elementos + 1);
    }
}