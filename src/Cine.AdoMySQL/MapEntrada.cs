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
            NumEntrada: Convert.ToByte(fila["numEntrada"]),
            IdProyeccion: Convert.ToUInt16(fila["IdProyeccion"]),
            IdCliente: Convert.ToByte(fila["IdCliente"]),
            valor: Convert.ToDecimal(fila["valor"])
        );

        public void AltaEntrada(Entrada entrada)
        {
            EjecutarComandoCon("AltaEntrada", ConfigurarAltaEntrada, PostAltaEntrada, entrada);
        }


        public void ConfigurarAltaEntrada(Entrada entrada)
        {
            SetComandoSP("venderEntrada");

            BP.CrearParametroSalida("numEntrada")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

            BP.CrearParametroSalida("unIdproyeccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(entrada.IdProyeccion)
            .AgregarParametro();

            BP.CrearParametroSalida("unIdCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(entrada.IdCliente)
            .AgregarParametro();

            BP.CrearParametroSalida("unvalor")
            .SetTipoDecimal(6, 2)
            .SetValor(entrada.Valor)
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