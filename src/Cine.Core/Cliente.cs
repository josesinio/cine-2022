namespace Cine.Core;

public class Cliente
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Clave { get; set; }
    public List<Entrada> entradas {get; set;}

    public Cliente (Guid Id, string? Email, string? Nombre, string? Apellido, string? Clave)
    {
        this.Id= Id;
        this.Email = Email;
        this.Nombre = Nombre;
        this.Apellido= Apellido;
        this.Clave = Clave;
        this.entradas = new List<Entrada>();

    }
    public void AgregarEntrada(Entrada entrada) => this.entradas.Add(entrada);
}