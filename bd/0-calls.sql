-- Active: 1646654372192@@127.0.0.1@3306@cine

delimiter ;

USE CINE ;

SELECT 'Creando calls' Estado ;

call AltaGenero (@idComedia, 'comedia');

call AltaGenero(@idAccion, 'Accion');

call AltaGenero(@idTerror, 'Terror');

call altaSala(1, 7, 40);

call altaSala(2, 1, 70);

call altaSala (3, 2, 100);

call
    altaPelicula(
        @idNinos,
        'son como ninos 2',
        '2004-03-1',
        @idComedia
    );

call
    altaPelicula(
        @idBatman,
        'Batman Ciudad Gotica',
        '1980-03-12',
        @idAccion
    );

call
    altaPelicula(
        @it,
        'it',
        '1980-03-12',
        @idTerror
    );

call
    altaProyeccion (
        @idProyeccion1,
        '2004-03-1 14:30',
        @idBatman,
        1
    );

call
    altaProyeccion (
        @idProyeccion2,
        '2100-03-1 14:30',
        @it,
        2
    );

call
    registrarCliente(
        @idCliente1,
        'dimitri12@gmail.com',
        'miguel angel',
        'barreiro',
        '12enletras'
    );

call venderEntrada(@NumEntrada1, 200, @idProyeccion1, @idCliente1);
call venderEntrada(@NumEntrada2, 202, @idProyeccion2, @idCliente1);

call
    top10 (
        '2013-03-02 14:51',
        '2015-05-05 18:30'
    );

select
    RecaudacionPara(
        @idBatman,
        '2020-03-12 12:16',
        '2020-03-17 18:51'
    );