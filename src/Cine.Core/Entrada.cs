using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Core
{
    public class Entrada
    {
        public int NumEntrada { get; set; }
        public Proyeccion Proyeccion { get; set; }
        public Cliente Cliente { get; set; }
        public int NumSala { get; set; }
        public int Capacidad { get; set; }
        public float Valor { get; set; }

        public Entrada(int NumEntrada, Proyeccion Proyeccion, Cliente Cliente, int NumSala, int capacidad, float valor)
        {
            this.NumEntrada = NumEntrada;
            this.Proyeccion = Proyeccion;
            this.Cliente = Cliente;
            this.NumSala = NumSala;
            this.Capacidad = Capacidad;
            this.Valor = Valor;
        }

    }
}