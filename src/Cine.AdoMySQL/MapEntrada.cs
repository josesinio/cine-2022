using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using Cine.Core;

namespace Cine.AdoMySQL.Mapeadores
{
    public class MapEntrada : Mapeador<Entrada>
    {
        public MapProyeccion mapProyeccion { get; set; }
        public MapSala mapSala { get; set; }
        public MapEntrada(AdoAGBD ado) : base(ado) => Tabla = "Entrada";
        public MapEntrada(MapProyeccion mapProyeccion, MapSala mapSala) : this(mapProyeccion.AdoAGBD)
        {
            MapProyeccion = mapProyeccion;
            MapSala = mapSala;
        }

        public override Entrada ObjetoDesdeFila(DataRow fila)
        {


        }
    }