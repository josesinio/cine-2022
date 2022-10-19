using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
namespace Cine.AdoMySQL.Mapeadores;
public class MapGenero : Mapeador<Genero>
{
    public MapGenero(AdoAGBD ado) : base(ado)
    {
        Tabla = "Genero";
    }
    public override Genero ObjetoDesdeFila(DataRow fila)
            => new Genero()
            {
                Id = Convert.ToByte(fila["idGenero"]),
                Nombre = fila["genero"].ToString()
            };
}
