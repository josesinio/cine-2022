using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Cine.AdoMySQL.Mapeadores;
public class MapCliente : Mapeador<Cliente>
{
    public MapCliente(AdoAGBD ado) : base(ado)
    {
        Tabla = "Cliente";
    }
    public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente
            (
                id: Convert.ToByte(fila["idCliente"]),
                email: fila["Email"].ToString()!,
                nombre: fila["Nombres"].ToString()!,
                apellido: fila["apellido"].ToString()!,
                clave: fila["clave"].ToString()!
            );
    public void AltaCliente(Cliente cliente)
            => EjecutarComandoCon("", ConfigurarAltaCliente, PostAltaCliente, cliente);

    public void ConfigurarAltaCliente(Cliente cliente)
    {
        SetComandoSP("registrarCliente");

        BP.CrearParametroSalida("unidcliente")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .AgregarParametro();

        BP.CrearParametro("unemail")
        .SetTipoVarchar(45)
        .SetValor(cliente.email)
        .AgregarParametro();

        BP.CrearParametro("unnombre")
        .SetTipoVarchar(45)
        .SetValor(cliente.nombre)
        .AgregarParametro();

        BP.CrearParametro("unapellido")
        .SetTipoVarchar(45)
        .SetValor(cliente.apellido)
        .AgregarParametro();

        BP.CrearParametro("unaclave")
        .SetTipoVarchar(45)
        .SetValor(cliente.clave)
        .AgregarParametro();
    }
    public void PostAltaCliente(Cliente cliente)
    {
        var paramId = GetParametro("unid");
        cliente.id = Convert.ToByte(paramId.Value);
    }

    public Cliente ClientePorId(byte id)
    {
        SetComandoSP("ClientePorId");

        BP.CrearParametro("unidCliente")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .SetValor(id)
        .AgregarParametro();

        return ElementoDesdeSP();
    }
    public List<Cliente> ObtenerCliente(Cliente cliente)
    {
        return FilasFiltradas("idCliente", cliente.id);
    }
}
