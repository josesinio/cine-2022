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
        AdoCine?.AltaCliente(cliente);
        Assert.Equal(2, cliente.id);
    }

    [Fact]
    public void ClientePorId()
    {
        var cliente = new Cliente(101, "javiermereleQgmail.com", "Javier", "Merele", "946281");
        AdoCine?.ClientePorId(cliente);
        Assert.Equal(1, cliente.id);
    }
}
