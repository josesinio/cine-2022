using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;

namespace Cine.AdoMySQL.Test;

public class ClienteTest
{
    public AdoCine AdoCine { get; set; }
    public ClienteTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        AdoCine = new AdoCine(adoAGBD);
    }
    [Fact]
    public void registrarCliente()
    {
        var cliente = new Cliente(2, "quirogapabon11@gmail.com", "Esthefany", "Quiroga", "2516348");
        var elementos = AdoCine.MapCliente.ColeccionDesdeTabla().Count;
        AdoCine.AltaCliente(cliente);
        var elementosnuevos = AdoCine.MapCliente.ColeccionDesdeTabla().Count;
        Assert.Equal(elementos + 1, elementosnuevos);
    }

}
