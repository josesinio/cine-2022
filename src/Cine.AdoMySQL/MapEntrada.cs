using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Cine.Core;
using static System.Convert;

namespace Cine.AdoMySQL.Mapeadores
{
    public class MapEntrada : Mapeador<Entrada>
    {
        public MapEntrada(AdoAGBD ado) : base(ado)
        {
            Tabla = "Entrada";
        }

        public override Entrada ObjetoDesdeFila(DataRow fila) => new Entrada
        (
            NumEntrada: ToByte(fila["numEntrada"]),
            valor: ToDecimal(fila["valor"]),
            IdProyeccion: ToUInt16(fila["IdProyeccion"]),
            IdCliente: ToByte(fila["IdCliente"])
        );

        public void AltaEntrada(Entrada entrada)
        {
            EjecutarComandoCon("venderEntrada", ConfigurarAltaEntrada, PostAltaEntrada, entrada);
        }


        public void ConfigurarAltaEntrada(Entrada entrada)
        {
            SetComandoSP("venderEntrada");

            BP.CrearParametroSalida("numEntrada")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .AgregarParametro();

            BP.CrearParametro("unvalor")
            .SetTipoDecimal(6, 2)
            .SetValor(entrada.Valor)
            .AgregarParametro();

            BP.CrearParametro("unIdproyeccion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(entrada.IdProyeccion)
            .AgregarParametro();

            BP.CrearParametro("unIdCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(entrada.IdCliente)
            .AgregarParametro();
        }

        public void PostAltaEntrada(Entrada entrada)
        {
            var paramnumEntrada = GetParametro("numEntrada");
            entrada.NumEntrada = Convert.ToByte(paramnumEntrada.Value);
        }
        public Entrada EntradaPorId(byte NumEntrada)
        {
            return FiltrarPorPK("numEntrada", NumEntrada)!;
        }

        public List<Entrada> EntradasHabilitadas(byte IdCliente)
        {
            SetComandoSP("EntradasCliente");

            BP.CrearParametro("unidCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(IdCliente)
            .AgregarParametro();


            return ColeccionDesdeSP();
        }
    }
}