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
    public void venderEntrada()
    {
        
        var entrada = new Entrada(2, 1, 1, 300);
        var elementos = AdoCine.MapEntrada.ColeccionDesdeTabla().Count;

        AdoCine.AltaEntrada(entrada);
        var elementosnuevos = AdoCine.MapEntrada.ColeccionDesdeTabla().Count;
        Assert.Equal(elementos + 1, elementosnuevos);
    }
}