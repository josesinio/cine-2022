using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Mapeadores;

namespace Cine.AdoMySQL.Mapeadores;
public class MapProyeccion : Mapeador<Proyeccion>
{
    public MapSala MapSala { get; set; }
    public PeliculaMap MapPelicula { get; set; }
    public MapProyeccion(MapSala mapSala, PeliculaMap mapPelicula) : base(mapSala.AdoAGBD)
    {
        MapSala = mapSala;
        MapPelicula = mapPelicula;
        Tabla = "Proyeccion";
    }

    public override Proyeccion ObjetoDesdeFila(DataRow fila)
    => new Proyeccion(
        id: Convert.ToByte(fila["idProyeccion"]),
        fechaHora: Convert.ToDateTime(fila["Fechahora"]),
        pelicula: MapPelicula.PeliculaPorId(Convert.ToUInt16(fila["IdPelicula"]))!,
        sala: MapSala.SalaPorId(Convert.ToByte(fila["numSala"]))
    );

    public void AltaProyeccion(Proyeccion proyeccion)
    {
        EjecutarComandoCon("altaProyeccion", ConfigurarAltaProyeccion, PostAltaProyeccion, proyeccion);
    }

    public void ConfigurarAltaProyeccion(Proyeccion proyeccion)
    {
        SetComandoSP("altaProyeccion");

        BP.CrearParametroSalida("unIdProyeccion")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .AgregarParametro();

        BP.CrearParametroSalida("unaFechaHora")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
        .AgregarParametro();

        BP.CrearParametroSalida("unIdPelicula")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .AgregarParametro();

        BP.CrearParametroSalida("unIdSala")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .AgregarParametro();

    }

    public void PostAltaProyeccion(Proyeccion proyeccion)
    {
        var paramIdProyeccion = GetParametro("unIdProyeccion");
        proyeccion.id = Convert.ToByte(paramIdProyeccion.Value);
    }

    public Proyeccion ProyeccionPorId(byte id)
    {
        return FiltrarPorPK("idProyeccion", id)!;
    }

    public List<Proyeccion> ObtenerProyecciones(Pelicula pelicula)
    {
        return FilasFiltradas("idPelicula", pelicula.idPelcula);
    }
}