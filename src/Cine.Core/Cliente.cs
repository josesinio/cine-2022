namespace Cine.Core;

public class Cliente
{
    public byte id { get; set; }
    public string email { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string clave { get; set; }
    public List<Entrada> entradas { get; set; }

    public Cliente(byte id, string email, string nombre, string apellido, string clave)
    {
        this.id = id;
        this.email = email;
        this.nombre = nombre;
        this.apellido = apellido;
        this.clave = clave;
        this.entradas = new List<Entrada>();

    }
    public void AgregarEntrada(Entrada entrada) => this.entradas.Add(entrada);
}