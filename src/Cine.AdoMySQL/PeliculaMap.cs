using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores;

public class PeliculaMap : Mapeador<Pelicula>
{
    public MapGenero mapGenero { set; get; }
    public PeliculaMap(AdoAGBD ado) : base(ado) => Tabla = "Pelicula";

    public PeliculaMap(MapGenero mapGenero) : this(mapGenero.AdoAGBD)
    {
        mapGenero = mapGenero;
    }
    public override Pelicula ObjetoDesdeFila(DataRow fila)
    => new Pelicula
    (
        id: Convert.ToUInt16(fila["id"]),
        nombre: fila["Nombre"].ToString()!,
        estreno: Convert.ToDateTime(fila["Estreno"]),
        genero: mapGenero.GeneroPorId(Convert.ToByte(fila["idGenero"]))
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
        pelicula.id = Convert.ToUInt16(paramIdPelicula.Value);
    }
    public Pelicula PeliculaPorId(ushort id)
    {
        SetComandoSP("PeliculaPorId");
        BP.CrearParametro("unIdPelicula")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
        .SetValor(id)
        .AgregarParametro();

        return ElementoDesdeSP();
    }
    public List<Pelicula> obtenerPeliculas() => ColeccionDesdeTabla();
}