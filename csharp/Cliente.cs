using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp
{
    public class Cliente
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Clave {get; set;}
    }

    List <Entrada> Entradas;

    public void AgregarEntrada(int NumEntrada) =>
        this.Entradas.add(new Entrada(NumEntrada));
    public void CrearCuenta(string Email, string clave)=>
        this.Cuentas.add(new Entrada(Email, clave));
    public void EliminarEntrada()=>
        this.Entradas.remove(Entrada);
    public void EliminarCuenta()=>
        this.Cuentas.remove(Cuenta) ;
}