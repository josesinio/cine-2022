using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores;

public class PeliculaMap : Mapeador<Pelicula>
{
    public MapGenero MapGenero { set; get; }
    public PeliculaMap(MapGenero mapGenero) : base(mapGenero.AdoAGBD)
    {
        MapGenero = mapGenero;
        Tabla = "Pelicula";
    }
    public override Pelicula ObjetoDesdeFila(DataRow fila)
    => new Pelicula
    (
        idPelicula: Convert.ToUInt16(fila["id"]),
        nombre: fila["Nombre"].ToString()!,
        estreno: Convert.ToDateTime(fila["Estreno"]),
        IdGenero: Convert.ToByte(fila["idGenero"])
    );
    public void AltaPelicula(Pelicula pelicula)
    => EjecutarComandoCon("altaPelicula", ConfigurarAltaPelicula, PosAltaPelicula, pelicula);

    public void ConfigurarAltaPelicula(Pelicula pelicula)
    {
        SetComandoSP("altaPelicula");

        BP.CrearParametroSalida("unIdPelicula")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
        .AgregarParametro();

        BP.CrearParametroSalida("unNombre")
        .SetTipoVarchar(45)
        .SetValor(pelicula.nombre)
        .AgregarParametro();

        BP.CrearParametroSalida("unEstreno")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Date)
        .AgregarParametro();

        BP.CrearParametroSalida("unIdGenero")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .AgregarParametro();
    }

    public void PosAltaPelicula(Pelicula pelicula)
    {
        var paramIdPelicula = GetParametro("unIdPelicula");
        pelicula.idPelcula = Convert.ToUInt16(paramIdPelicula.Value);
    }
    public Pelicula PeliculaPorId(ushort id)
    {
        return FiltrarPorPK("idPelicula", id);
    }
    public List<Pelicula> obtenerPeliculas() => ColeccionDesdeTabla();
}