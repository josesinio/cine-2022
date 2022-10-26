using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Cine.AdoMySQL.Mapeadores;
{
    public class MapProyeccion : Mapeador<Proyeccion>
    {
        public MapnumSala MapSala { get; set; }
        public MapPelicula MapPelicula { get; set; }
        public MapProyeccion(AdoAGBD ado) : base(ado) => Tabla = "Proyeccion";
        public MapProyeccion(MapnumSala mapSala, MapPelicula mapPelicula) : this(mapSala.AdoAGBD)
        {
             MapSala = mapSala;
             mapPelicula = mapPelicula;
        }

        public override Proyeccion ObjetoDesdeFila(DataRow fila) => new Proyeccion()
        {
            Id = Convert.ToInt16(fila["idProyeccion"]),
            numSala = MapSala.numSalaPorId(Convert.ToByte(fila[""])),
        };

        public List<Proyeccion> ObtenerProyecciones() => ColeccionDesdeTabla();
        public List<Proyeccion> ObtenerProyecciones(numSala numSala)
        {
            SetComandoSP("ProyeccionPornumSala");

            BP.CrearParametro("numSala")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(rubro.Id)
            .AgregarParametro();

            return ColeccionDesdeSP();
        }

        public void AltaProducto(Producto producto)
        {
            EjecutarComandoCon("altaProducto", ConfigurarAltaProducto, PostAltaProducto, producto);
        }

        private void ConfigurarAltaProducto(Producto producto)
        {
            SetComandoSP("altaProducto");

            BP.CrearParametroSalida("unIdProducto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .AgregarParametro();

            BP.CrearParametro("unIdRubro")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(producto.Rubro.Id)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(producto.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unPrecioUnitario")
            .SetTipoDecimal(7, 2)
            .SetValor(producto.PrecioUnitario)
            .AgregarParametro();

            BP.CrearParametro("unaCantidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(producto.Cantidad)
            .AgregarParametro();
        }
        private void PostAltaProducto(Producto producto)
            => producto.Id = Convert.ToInt16(GetParametro("unIdProducto").Value);
    }
}