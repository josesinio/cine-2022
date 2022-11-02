using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Cine.AdoMySQL.Mapeadores;
{
    public class MapProyeccion : Mapeador<Proyeccion>
    {
        public MapSala MapSala { get; set; }
        public MapPelicula MapPelicula { get; set; }
        public MapProyeccion(AdoAGBD ado) : base(ado) => Tabla = "Proyeccion";
        public MapProyeccion(MapSala mapSala, MapPelicula mapPelicula) : this(mapSala.AdoAGBD)
        {
            MapSala = mapSala;
            MapPelicula = mapPelicula;
        }

        public override Proyeccion ObjetoDesdeFila(DataRow fila) => new Proyeccion()
        {
            Id = Convert.ToInt16(fila["idProyeccion"]),
            sala = MapSala.SalaPorId(Convert.ToByte(fila["numSala"])),
        };

        public List<Proyeccion> ObtenerProyecciones() => ColeccionDesdeTabla();
        public List<Proyeccion> ObtenerProyecciones(numSala numSala)
        {
            SetComandoSP("ProyeccionPornumSala");
}