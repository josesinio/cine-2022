USE CINE;

SELECT 'Creando calls' Estado;

call AltaGenero (1, "comedia");

call AltaGenero(2, "Accion");

call AltaGenero(3, "Terror");

call altaSala(1, 7, 40);

call altaSala(2, 1, 70);

call altaSala (3, 2, 100);

call
    altaPelicula(
        1,
        "son como niños 2",
        "2004-03-1",
        1
    );

call
    altaPelicula(
        2,
        "Batman Ciudad Gotica",
        "1980-03-12"
    )
call
    altaProyeccion (1, "2004-03-1 14:30", 1, 1);

call
    registrarCliente(
        1,
        "dimitri12@gmail.com",
        "miguel angel",
        "barreiro",
        "12enletras"
    );

call venderEntrada(900, 1, 1);

call
    top10 (
        "2013-03-02 14:51",
        "2015-05-05 18:30"
    );

select
    RecaudacionPara(
        1,
        "12-03-12 12:16",
        "15-03-05 18:51"
    )