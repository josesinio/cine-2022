using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;

namespace Cine.AdoMySQL.Test;

public class EntradaTest
{
    public AdoCine AdoCine { get; set; }
    public EntradaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        AdoCine = new AdoCine(adoAGBD);
    }


    [Fact]
    public void AltaEntrada()
    {
        var proyeccion = new Proyeccion(1, DateTime.Now, 3, 2);
        var entrada = new Entrada(2, 3, 3, 30, 300);
        AdoCine.AltaEntrada(entrada);
        Assert.Equal(2, entrada.NumEntrada);
    }
}