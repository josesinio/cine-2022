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
        idPelicula: Convert.ToUInt16(fila["idPelicula"]),
        nombre: fila["Nombre"].ToString()!,
        estreno: Convert.ToDateTime(fila["Estreno"]),
        IdGenero: Convert.ToByte(fila["idGenero"])
    );
    public void AltaPelicula(Pelicula pelicula)
    => EjecutarComandoCon("altaPelicula", ConfigurarAltaPelicula, PosAltaPelicula, pelicula);

    public void ConfigurarAltaPelicula(Pelicula pelicula)
    {
        SetComandoSP("altaPelicula");

        BP.CrearParametroSalida("unidPelicula")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
        .AgregarParametro();

        BP.CrearParametro("unNombre")
        .SetTipoVarchar(45)
        .SetValor(pelicula.nombre)
        .AgregarParametro();

        BP.CrearParametro("unEstreno")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Date)
        .SetValor(pelicula.estreno)
        .AgregarParametro();

        BP.CrearParametro("unIdGenero")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .SetValor(pelicula.IdGenero)
        .AgregarParametro();
    }

    public void PosAltaPelicula(Pelicula pelicula)
    {
        var paramIdPelicula = GetParametro("unidPelicula");
        pelicula.idPelicula = Convert.ToUInt16(paramIdPelicula.Value);
    }
    public Pelicula? PeliculaPorId(ushort id) => FiltrarPorPK("idPelicula", id);
    public List<Pelicula> obtenerPeliculas() => ColeccionDesdeTabla();
}