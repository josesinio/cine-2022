using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Cine.AdoMySQL.Mapeadores;
{
    public class MapProyeccion : Mapeador<Proyeccion>
{
    public MapSala MapSala { get; set; }
    public PeliculaMap MapPelicula { get; set; }
    public MapProyeccion(AdoAGBD ado) : base(ado) => Tabla = "Proyeccion";
    public MapProyeccion(MapSala mapSala, PeliculaMap mapPelicula) : this(mapSala.AdoAGBD)
    {
        MapSala = mapSala;
        MapPelicula = MapPelicula;
    }

    public override Proyeccion ObjetoDesdeFila(DataRow fila)
    => new Proyeccion(
        Id: Convert.ToByte(fila["idProyeccion"]),
        FechaHora: Convert.ToDateTime(fila["Fechahora"]),
        sala: MapSala.SalaPorId(Convert.ToByte(fila["numSala"]))
    )
    {
        Id = Convert.ToByte(fila["idProyeccion"]),
        sala = MapSala.SalaPorId(Convert.ToByte(fila["numSala"])),
    };

    public List<Proyeccion> ObtenerProyecciones() => ColeccionDesdeTabla();
    public List<Proyeccion> ObtenerProyecciones(numSala numSala)
    {
        SetComandoSP("ProyeccionPornumSala");
    }