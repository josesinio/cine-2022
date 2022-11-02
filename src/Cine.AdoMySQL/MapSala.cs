using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Cine.AdoMySQL.Mapeadores;

public class MapSala : Mapeador<Sala>
{
    public MapSala(AdoAGBD ado) : base(ado)
    {
        Tabla = "Sala";
    }
    public override Sala ObjetoDesdeFila(DataRow fila)
            => new Sala(
                numSala: Convert.ToByte(fila["numSala"]),
                piso: Convert.ToByte(fila["piso"]),
                capacidad: Convert.ToUInt16(fila["capacidad"])
            );
    public void AltaSala(Sala sala)
    => EjecutarComandoCon("altaSala", ConfigurarAltaSala, PostAltaSala, sala);

    public void ConfigurarAltaSala(Sala sala)
    {
        SetComandoSP("altaSala");

        BP.CrearParametroSalida("unnumSala")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .AgregarParametro();

        BP.CrearParametro("unaSala")
        .SetTipoVarchar(45)
        .SetValor(sala.NumSala)
        .AgregarParametro();
    }
    public void PostAltaSala(Sala sala)
    {
        var paramnumSala = GetParametro("unnumSala");
        sala.NumSala = Convert.ToByte(paramnumSala.Value);
    }

    public Sala SalaPornumSala(byte id)
    {
        SetComandoSP("SalapornumSala");

        BP.CrearParametro("unnumSala")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .SetValor(id)
        .AgregarParametro();

        return ElementoDesdeSP();
    }

    public List<Sala> ObtenerSalas() => ColeccionDesdeTabla();

    public override Sala ObjetoDesdeFila(DataRow fila)
    {
        throw new NotImplementedException();
    }
}

