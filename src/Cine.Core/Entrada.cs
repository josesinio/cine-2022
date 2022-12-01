namespace Cine.Core
{
    public class Entrada
    {
        public byte NumEntrada { get; set; }
        public ushort IdProyeccion { get; set; }
        public byte IdCliente { get; set; }
        public decimal Valor { get; set; }

        public Entrada(byte NumEntrada, ushort IdProyeccion, byte IdCliente, decimal valor)
        {
            this.NumEntrada = NumEntrada;
            this.IdProyeccion = IdProyeccion;
            this.IdCliente = IdCliente;
            this.Valor = valor;
        }
    }
}