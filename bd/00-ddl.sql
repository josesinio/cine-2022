DROP DATABASE IF EXISTS CINE;
CREATE DATABASE CINE;

CREATE TABLE CINE.Genero(
    idGenero tinyint unsigned not null,
    genero varchar(45) not null,
    primary key (idGenero)
);

CREATE TABLE CINE.Sala(
    numSala tinyint unsigned not null,
    piso int not null,
    capacidad smallint unsigned not null,
    primary key (numSala)
);

CREATE TABLE CINE.Pelicula(
    idPelicula smallint unsigned not null,
    nombre varchar(45) not null,
    estreno date not null,
    idGenero tinyint unsigned not null,
    primary key (idPelicula),
    constraint FK_Pelicula_Genero foreign key (idGenero)
        references CINE.Genero (idGenero)
);

CREATE TABLE CINE.Cliente(
    idCliente smallint unsigned not null,
    email int not null,
    nombre varchar (45) not null,
    apellido varchar (45) not null,
    clave char(64) not null,
    numEntrada int not null,
    primary key (idCliente),
    constraint UQ_Cliente_email unique (email)
);

CREATE TABLE CINE.Proyeccion(
    idProyeccion smallint unsigned not null,
    fechaHora datetime not null,
    idPelicula smallint unsigned not null,
    numSala tinyint unsigned not null,
    primary key (idProyeccion),
    constraint fk_Proyeccion_Sala foreign key (numSala)
        references CINE.Sala (numSala),
    constraint fk_Proyeccion_Pelicula foreign key (idPelicula)
        references CINE.Pelicula (idPelicula)
);


CREATE TABLE  CINE.Entrada(
    numEntrada int not null,
    idProyeccion smallint unsigned not null,
    idCliente smallint unsigned not null,
    numSala tinyint unsigned not null,
    capacidad smallint unsigned not null,
    primary key (numEntrada, idProyeccion,numSala),
    constraint fk_Entrada_Sala foreign key (numSala)
        references CINE.Sala (numSala),
    constraint fk_Entrada_Proyeccion  foreign key (idProyeccion)
        references CINE.Proyeccion (idProyeccion),
    constraint fk_Entrada_Cliente foreign key (idCliente)
        references CINE.Cliente (idCliente)
);