<!-- Completa abajo cambiando ET12DE1Computacion a tu user|organización y template a tu repo, te recomiendo usar el Find & Replace de tu editor -->
![main build.NET5](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/workflows/main-build.NET5/badge.svg?branch=main) ![main test.NET5](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/workflows/main-test.NET5/badge.svg?branch=main)
![dev build.NET5](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/workflows/dev-build.NET5/badge.svg?branch=dev) ![dev test.NET5](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/workflows/dev-test.NET5/badge.svg?branch=dev)
[![Abrir en Visual Studio Code](https://open.vscode.dev/badges/open-in-vscode.svg)](https://open.vscode.dev/ET12DE1Computacion/simpleTemplateCSharp)
<!-- Borra este comentario y linea después haber cambiado arriba las ocurrencias de tu usuario/repo -->

<h1 align="center">E.T. Nº12 D.E. 1º "Libertador Gral. José de San Martín"</h1>
<p align="center">
  <img src="https://et12.edu.ar/imgs/et12.png">
</p>

## Computación 2021

**Asignatura**: base de datos

**Nombre TP**:TP Anual: Entrega 0 

**Apellido y nombre Alumno**: Jose cruz rojas

**Curso**: 5°7

# Título del Proyecto

cine 2022

## Comenzando 🚀

Clonar el repositorio github, desde Github Desktop o ejecutar en la terminal o CMD:
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
primary key (idCliente)
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
capacidad smallint unsigned not null,
primary key (numEntrada),
constraint fk_Entrada_Proyeccion  foreign key (idProyeccion)
references CINE.Proyeccion 	(idProyeccion),
constraint fk_Entrada_Cliente foreign key (idCliente)
references CINE.Cliente (idCliente)
);

<!-- cambia el link de abajo al de tu repositorio y BORRA ESTE COMENTARIO -->
```
git clone https://github.com/ET12DE1Computacion/simpleTemplateCSharp
```

### Pre-requisitos 📋

- .NET 5.0.7 (SDK .NET 5.0.301) [Descargar](https://dotnet.microsoft.com/download/dotnet/5.0)

## Despliegue 📦

_Agrega notas adicionales sobre que cosas se debe instalar, configurar y como hacer deploy_

## Construido con 🛠️

MySQL Workbench

* [Visual Studio Code](https://code.visualstudio.com/#alt-downloads) - Editor de código.

## Versionado 📌

Usamos [SemVer](http://semver.org/) para el versionado. Para todas las versiones disponibles, mira los [tags en este repositorio](https://github.com/ET12DE1Computacion/simpleTemplateCSharp/tags).

## Autores ✒️

Jose cruz, Estefany quiroga y Brenda duran

* **brenda duran** - *Desarrollo* - [Maxpower](https://github.com/maxpower)
* **jose cruz** - *Documentación* - [Cosmefulanito](#Cosmefulanito)

## Licencia 📄

Este proyecto está bajo la Licencia (Tu Licencia) - mira el archivo [LICENSE.md](LICENSE.md) para detalles.
