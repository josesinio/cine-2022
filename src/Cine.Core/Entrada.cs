namespace Cine.Core
{
    public class Entrada
    {
        public byte NumEntrada { get; set; }
        public Proyeccion Proyeccion { get; set; }
        public Cliente Cliente { get; set; }
        public int NumSala { get; set; }
        public int Capacidad { get; set; }
        public float Valor { get; set; }

        public Entrada(byte numEntrada, Proyeccion proyeccion, Cliente cliente, int numSala, int capacidad, float valor)
        {
            this.NumEntrada = numEntrada;
            this.Proyeccion = proyeccion;
            this.Cliente = cliente;
            this.NumSala = numSala;
            this.Capacidad = capacidad;
            this.Valor = valor;
        }

    }
}