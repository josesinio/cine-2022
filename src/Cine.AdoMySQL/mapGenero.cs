using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
namespace Cine.AdoMySQL.Mapeadores;
public class MapGenero : Mapeador<Genero>
{
    public MapGenero(AdoAGBD ado) : base(ado)
    {
        Tabla = "Genero";
    }
    public override Genero ObjetoDesdeFila(DataRow fila)
            => new Genero
            (
                Id: Convert.ToByte(fila["idGenero"]),
                Nombre: fila["Nombre"].ToString()
            );
    public void AltaGenero(Genero genero)
            => EjecutarComandoCon("altaGenero", ConfigurarAltaGenero, PostAltaGenero, genero);

    public void ConfigurarAltaGenero(Genero genero)
    {
        SetComandoSP("altaGenero");

        BP.CrearParametroSalida("unId")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .AgregarParametro();

        BP.CrearParametroSalida("unNombre")
        .SetTipoVarchar(45)
        .SetValor(genero.Nombre)
        .AgregarParametro();
    }

    public void PostAltaGenero(Genero genero)
    {
        var paramId = GetParametro("unId");
        genero.Id = Convert.ToByte(paramId.Value);
    }

    public Genero GeneroPorId(byte id)
    {
        SetComandoSP("GeneroPorId");

        BP.CrearParametro("unId")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .SetValor(id)
        .AgregarParametro();

        return ElementoDesdeSP();
    }

    public List<Genero> ObtenerGenero(Genero genero)
    {
        return FilasFiltradas("idGenero", genero.Id);
    }
}
