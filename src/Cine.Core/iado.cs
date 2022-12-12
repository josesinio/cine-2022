namespace Cine.Core;

public interface IAdo
{
    void AltaGenero(Genero genero);
    List<Genero> ObtenerGenero();

    void AltaPelicula(Pelicula pelicula);
    List<Pelicula> ObtenerPelicula();

    void AltaSala(Sala sala);
    List<Sala> ObtenerSala();

    void AltaProyeccion(Proyeccion proyeccion);
    List<Proyeccion> ObtenerProyeccion();

    void AltaCliente(Cliente cliente);
    List<Cliente> ObtenerCliente();

    void AltaEntrada(Entrada entrada);
    List<Entrada> ObtenerEntrada();
    public Proyeccion ProyeccionPorId(ushort id);
}
