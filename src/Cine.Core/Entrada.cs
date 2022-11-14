namespace Cine.Core
{
    public class Entrada
    {
        public byte NumEntrada { get; set; }
        public Proyeccion Proyeccion { get; set; }
        public Cliente Cliente { get; set; }
        public Sala NumSala { get; set; }
        public int Capacidad { get; set; }
        public float Valor { get; set; }

        public Entrada(byte numEntrada, Proyeccion proyeccion, Cliente cliente, Sala sala, int capacidad, float valor)
        {
            this.NumEntrada = numEntrada;
            this.Proyeccion = proyeccion;
            this.Cliente = cliente;
            this.NumSala = sala;
            this.Capacidad = capacidad;
            this.Valor = valor;
        }

    }
}