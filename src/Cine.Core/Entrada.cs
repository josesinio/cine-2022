namespace Cine.Core
{
    public class Entrada
    {
        public byte NumEntrada { get; set; }
        public byte IdProyeccion { get; set; }
        public byte IdCliente { get; set; }
        public byte IdSala { get; set; }
        public int Capacidad { get; set; }
        public float Valor { get; set; }

        public Entrada(byte numEntrada, byte IdProyeccion, byte IdCliente, byte IdSala, int capacidad, float valor)
        {
            this.NumEntrada = numEntrada;
            this.IdProyeccion = IdProyeccion;
            this.IdCliente = IdCliente;
            this.IdSala = IdSala;
            this.Capacidad = capacidad;
            this.Valor = valor;
        }



    }
}