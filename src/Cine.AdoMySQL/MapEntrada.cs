using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores
{
    public class MapEntrada : Mapeador<Entrada>
    {
        public MapProyeccion MapProyeccion { get; set; }
        public MapSala MapSala { get; set; }
        public MapCliente MapCliente { get; set; }
        public MapEntrada(MapProyeccion mapProyeccion, MapSala mapSala, MapCliente mapCliente) : base(mapProyeccion.AdoAGBD)
        {
            MapProyeccion = mapProyeccion;
            MapSala = mapSala;
            MapCliente = mapCliente;
            Tabla = "Entrada";
        }

        public override Entrada ObjetoDesdeFila(DataRow fila) => new Entrada
        (
            NumEntrada: Convert.ToByte(fila["Id"]),
            IdProyeccion: Convert.ToUInt16(fila["IdProyeccion"]),
            IdCliente: Convert.ToByte(fila["IdCliente"]),
            capacidad: Convert.ToInt32(fila["capacidad"]),
            valor: Convert.ToSingle(fila["valor"])
        );

        public void AltaEntrada(Entrada entrada)
        {
            EjecutarComandoCon("AltaEntrada", ConfigurarAltaEntrada, PostAltaEntrada, entrada);
        }


        public void ConfigurarAltaEntrada(Entrada entrada)
        {
            SetComandoSP("AltaEntrada");

            BP.CrearParametroSalida("unIdEntrada")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .AgregarParametro();

            BP.CrearParametroSalida("unidproyeccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(entrada.IdProyeccion)
            .AgregarParametro();

            BP.CrearParametroSalida("unIdCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(entrada.IdCliente);

            BP.CrearParametroSalida("Capacidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

            BP.CrearParametroSalida("valor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Float)
            .AgregarParametro();
        }

        public void PostAltaEntrada(Entrada entrada)
        {
            var paramIdEntrada = GetParametro("unIdEntrada");
            entrada.NumEntrada = Convert.ToByte(paramIdEntrada.Value);
        }
        public Entrada EntradaPorId(byte numEntrada)
        {
            return FiltrarPorPK("idEntrada", numEntrada)!;
        }

    }
}