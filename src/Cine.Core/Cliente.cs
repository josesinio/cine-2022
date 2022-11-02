namespace Cine.Core;

public class Cliente
{
    public byte Id { get; set; }
    public string Email { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Clave { get; set; }
    public List<Entrada> entradas { get; set; }

    public Cliente(byte id, string email, string nombre, string apellido, string clave)
    {
        this.Id = id;
        this.Email = email;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Clave = clave;
        this.entradas = new List<Entrada>();

    }
    public void AgregarEntrada(Entrada entrada) => this.entradas.Add(entrada);
}