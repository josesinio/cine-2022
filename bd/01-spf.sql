-- Primer ejercicio de STORED PROCEDURE 01-SPF.SQL

-- Se pide hacer los SP para dar de alta todas las entidades (menos Entrada y Cliente) con el prefijo ‘alta’.

delimiter $$ 

USE CINE $$
SELECT 'Creando procedimientos' Estado $$

DROP PROCEDURE IF EXISTS altaGenero $$
CREATE PROCEDURE altaGenero (
        OUT unidGenero tinyint unsigned,
        in ungenero varchar(45)
    ) BEGIN
INSERT INTO
    Genero (genero)
VALUES (ungenero);

SET unidGenero = LAST_INSERT_ID();

END $$ 

DELIMITER $$ 

DROP PROCEDURE
    IF EXISTS altaSala $$
CREATE PROCEDURE
    altaSala (
        in unNumSala tinyint unsigned,
        in unpiso tinyint unsigned,
        in unacapacidad smallint unsigned
    ) BEGIN
INSERT INTO
    Sala (NumSala, piso, capacidad)
VALUES (
        unNumSala,
        unpiso,
        unacapacidad
    );

END $$ 

DELIMITER $$ 

DROP PROCEDURE
    IF EXISTS altaPelicula $$
CREATE PROCEDURE
    altaPelicula (
        OUT unidPelicula smallint unsigned,
        in unnombre varchar(45),
        in unestreno date,
        in unidGenero tinyint unsigned
    ) BEGIN
INSERT INTO
    Pelicula (
        idPelicula,
        nombre,
        estreno,
        idGenero
    )
VALUES (
        unidPelicula,
        unnombre,
        unestreno,
        unidGenero
    );

END $$ 

DELIMITER $$
DROP PROCEDURE
    IF EXISTS altaProyeccion $$
CREATE PROCEDURE
    altaProyeccion (
        OUT unidProyeccion smallint unsigned,
        in unafechaHora datetime,
        in unidPelicula smallint unsigned,
        in unnumSala tinyint unsigned
    ) BEGIN
INSERT INTO
    Proyeccion (
        idProyeccion,
        fechahora,
        idPelicula,
        NumSala
    )
VALUES (
        unidProyeccion,
        unafechaHora,
        unidPelicula,
        unNumSala
    );

END $$ 
-- Segundo ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.

DELIMITER %% 

DROP PROCEDURE IF EXISTS registrarCliente %%
CREATE PROCEDURE
    registrarCliente (
        OUT unidCliente smallint unsigned,
        unEmail VARCHAR (45),
        unNombre VARCHAR (45),
        unApellido VARCHAR (45),
        unaClave CHAR(64)
    ) BEGIN
INSERT INTO
    Cliente (
        Email,
        Nombre,
        Apellido,
        Clave
    )
VALUES (
        unEmail,
        unNombre,
        unApellido,
        SHA2(unaClave, 256)
    );

    SET unidCliente = LAST_INSERT_ID();

END %% 
-- Tercer ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Se pide hacer el SP ‘venderEntrada’ que reciba por parámetro el id de la función, valor e identificación del cliente. Pensar en cómo hacer para darle valores consecutivos desde 1 al número de entrada por función.

DELIMITER $$

DROP PROCEDURE
    IF EXISTS venderEntrada $$
CREATE PROCEDURE
    venderEntrada (
        OUT unvalor decimal(6, 2),
        in unidProyeccion smallint unsigned,
        in unidCliente smallint unsigned
    ) BEGIN -- 1 ) declarar var para id, se asigna como la cantidad de entradas para esa func + 1.
    -- 2 ) usar ese id para el nro de entrada. 
    declare num int default 0;

SELECT count(*) + 1 into num
FROM entrada
WHERE
    idProyeccion = unidProyeccion;

INSERT INTO
    Entrada (
        numEntrada,
        valor,
        idProyeccion,
        idcliente
    )
VALUES (
        num,
        unvalor,
        unidProyeccion,
        unidCliente
    );

end $$ -- Cuarto Ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Realizar el SP ‘top10’ que reciba por parámetro 2 fechas, el SP tiene que devolver identificador y nombre de la película y la cantidad de entradas vendidas para la misma entre las 2 fechas. Ordenar por cantidad de entradas de mayor a menor.

DELIMITER %%

DROP PROCEDURE IF EXISTS top10 %%
CREATE PROCEDURE
    top10 (
        unMenorFecha datetime,
        unMayorFecha datetime
    ) begin
SELECT
    p.idPelicula,
    nombre,
    COUNT(*) 'Cantidad de Entradas Vendidas'
FROM Pelicula p
    JOIN Proyeccion pro ON p.idPelicula = pro.idPelicula
    JOIN Entrada e ON pro.idProyeccion = e.idProyeccion
WHERE
    fechahora BETWEEN unMenorFecha AND unMayorFecha
GROUP BY p.idPelicula
ORDER BY COUNT(*) DESC;

end %% -- Realizar el SF llamado ‘RecaudacionPara’ que reciba por parámetro un identificador de película y 2 fechas, la función tiene que retornar la recaudación de la película entre esas 2 fechas.

DELIMITER $$

DROP FUNCTION
    IF EXISTS RecaudacionPara $$
CREATE FUNCTION
    RecaudacionPara (
        unidPelicula smallint unsigned,
        inicio datetime,
        fin datetime
    ) returns decimal(12, 2) reads sql data begin declare recaudacion decimal(12, 2);

SELECT
    SUM(valor) into recaudacion
from proyeccion
    join entrada USING (idproyeccion)
WHERE
    idPelicula = unidPelicula
    and fechaHora BETWEEN inicio and fin;

return recaudacion;

end $$ 