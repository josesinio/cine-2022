using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores;

public class PeliculaMap : Mapeador<Pelicula>
{
    public MapGenero mapGenero { set; get; }
    public PeliculaMap(AdoAGBD ado) : base(ado) => Tabla = "Pelicula";

    public PeliculaMap(MapGenero mapGenero) : this(mapGenero.AdoAGBD) => MapGenero = mapGenero;

    public override Pelicula ObjetoDesdeFila(DataRow fila)
    => new Pelicula
    (
        Id: Convert.ToUInt16(fila["Id"]),
        Nombre: fila["Nombre"].ToString(),
        Estreno: Convert.ToDateTime(fila["Estreno"]),
        Genero: Convert.ToByte(fila["Genero"])
    )
    {
        Id = Convert.ToUInt16(fila["Id"]),
        Nombre = fila["Nombre"].ToString(),
        Estreno = Convert.ToDateTime(fila["Estreno"]),
        Genero =

    };
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
        .SetValor(pelicula.Nombre)
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
        pelicula.Id = Convert.ToUInt16(paramIdPelicula.Value);
    }
    public Pelicula PeliculaPorId(ushort Id)
    {
        SetComandoSP("PeliculaPorId");
        BP.CrearParametro("unIdPelicula")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
        .SetValor(Id)
        .AgregarParametro();

        return ElementoDesdeSP();
    }
    public List<Pelicula> obtenerPeliculas() => ColeccionDesdeTabla();
}