namespace Cine.Core;

public class Cliente
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Clave { get; set; }

    List<Entrada> Entradas;

    public void AgregarEntrada(Entrada entrada) =>
        this.Entradas.Add(entrada);
}