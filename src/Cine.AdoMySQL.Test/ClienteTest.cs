using Cine.AdoMySQL.Mapeadores;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;

namespace Cine.AdoMySQL.Test;

public class ClienteTest
{
    public AdoCine? AdoCine { get; set; }
    public ClienteTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        AdoCine = new AdoCine(adoAGBD);
    }
    [Fact]
    public void AltaCliente()
    {
        var cliente = new Cliente(100, "quirogapabon11@gmail.com", "Esthefany", "Quiroga", "2516348");
        AdoCine.AltaCliente(cliente);
        Assert.Equal(2, cliente.id);
    }
}
