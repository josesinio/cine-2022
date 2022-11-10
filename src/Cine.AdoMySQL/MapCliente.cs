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
                email: fila["Email"].ToString(),
                nombre: fila["Nombres"].ToString(),
                apellido: fila["Apellido"].ToString(),
                clave: fila["clave"].ToString()
            )
            {
                id = Convert.ToByte(fila["idCliente"]),
                email = fila["Email"].ToString(),
                nombre = fila["Nombre"].ToString(),
                apellido = fila["Apellido"].ToString(),
                clave = fila["Clave"].ToString()
            };
    public void AltaCliente(Cliente cliente)
            => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);

    public void ConfigurarAltaCliente(Cliente cliente)
    {
        SetComandoSP("altaCliente");

        BP.CrearParametroSalida("unid")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .AgregarParametro();

        BP.CrearParametroSalida("unemail")
        .SetTipoVarchar(45)
        .SetValor(cliente.email)
        .AgregarParametro();

        BP.CrearParametroSalida("unnombre")
        .SetTipoVarchar(45)
        .SetValor(cliente.nombre)
        .AgregarParametro();

        BP.CrearParametroSalida("unapellido")
        .SetTipoVarchar(45)
        .SetValor(cliente.apellido)
        .AgregarParametro();

        BP.CrearParametroSalida("unaclave")
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

        BP.CrearParametro("unid")
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
