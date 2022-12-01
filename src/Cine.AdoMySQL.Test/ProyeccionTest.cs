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
        var proyeccion = new Proyeccion(2, DateTime.Now, 6, 6);
        AdoCine.AltaProyeccion(proyeccion);
        Assert.Equal(6, proyeccion.id);

    }
}
