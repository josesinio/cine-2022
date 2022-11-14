using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores;
public class MapSala : Mapeador<Sala>
{
    public MapSala(AdoAGBD ado) : base(ado)
    {
        Tabla = "Sala";
    }

    public override Sala ObjetoDesdeFila(DataRow fila)
    => new Sala
    (
        NumSala: Convert.ToByte(fila["Id"]),
        Piso: Convert.ToByte(fila["Piso"]),
        Capacidad: Convert.ToInt32(fila["capacidad"])
    )
    {
        NumSala = Convert.ToByte(fila["Id"]),
        Piso = Convert.ToByte(fila["Piso"]),
        Capacidad = Convert.ToInt32(fila["capacidad"])
    };
    public void AltaSAla(Sala sala)
    => EjecutarComandoCon("altaSala", ConfigurarAltaSala, postAltaSala, sala);

    public void ConfigurarAltaSala(Sala sala)
    {
        SetComandoSP("altaSala");

        BP.CrearParametroSalida("unNumSala")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .AgregarParametro();

        BP.CrearParametroSalida("unPiso")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .AgregarParametro();

        BP.CrearParametroSalida("unaCapacidad")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
        .AgregarParametro();

    }

    public void postAltaSala(Sala sala)
    {
        var paramNumSala = GetParametro("unNumSala");
        sala.NumSala = Convert.ToByte(paramNumSala.Value);
    }

    public Sala SalaPorId(byte NumSala)
    {
        SetComandoSP("SalaPorId");

        BP.CrearParametro("unNumSala")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .SetValor(NumSala)
        .AgregarParametro();

        return ElementoDesdeSP();
    }

    public List<Sala> obtenerSalas() => ColeccionDesdeTabla();
}