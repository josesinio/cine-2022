using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;

namespace Cine.AdoMySQL.Test;

public class EntradaTest
{
    public AdoCine Ado { get; set; }
    public EntradaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSetting.json", "test");
        Ado = new AdoCine(adoAGBD);
    }


    [Fact]
    public void AltaEntrada()
    {
        var proyeccion = Ado.mappro

        var entrada = new Entrada(2, 3, 3, 3, 30, 300);
        AdoCine.AltaEntrada(entrada);
        Assert.Equal(2, entrada.numEntrada);
    }
}