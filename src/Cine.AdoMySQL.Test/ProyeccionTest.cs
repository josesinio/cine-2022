using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;


namespace Cine.AdoMySQL.Test;

public class ProyeccionTest
{
    public AdoCine AdoCine { get; set; }
    public ProyeccionTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        AdoCine = new AdoCine(adoAGBD);
    }
    [Fact]
    public void AltaProyeccion()
    {

        var proyeccion = new Proyeccion(2, DateTime.Now, 3, 4);
        var elementos = AdoCine.MapProyeccion.ColeccionDesdeTabla().Count;
        AdoCine.AltaProyeccion(proyeccion);
        var elementosnuevos = AdoCine.MapProyeccion.ColeccionDesdeTabla().Count;
        Assert.Equal(elementos + 1, elementosnuevos);

    }
}
