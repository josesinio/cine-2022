DELIMITER $$
DROP PROCEDURE IF EXISTS altaGenero $$
CREATE PROCEDURE altaGenero ( in unidGenero tinyint unsigned, in ungenero varchar(45))
BEGIN

            INSERT INTO Genero (idGenero , genero)
                VALUES (unidGenero, ungenero)

END $$

DELIMITER $$ 
DROP PROCEDURE IF EXISTS altaSala $$
CREATE PROCEDURE altaSala (in unnumSala tinyint unsigned, in unpiso int, in unacapacidad smallint unsigned)
BEGIN 

            INSERT  INTO Sala (numSala, piso, capacidad)
                VALUES (unnumSala, unpiso, unacapacidad)

END $$

DELIMITER $$ 
DROP PROCEDURE IF EXISTS altaPelicula $$
CREATE PROCEDURE altaPelicula (in unidPelicula smallint unsigned, in unnombre varchar(45), in unestreno date, in unidGenero tinyint unsigned)
BEGIN 

            INSERT INTO Pelicula ( idPelicula, nombre, estreno,idGenero)
                    VALUES (unidPelicula, unnombre,unestreno, unidGenero)

END $$

DELIMITER $$
DROP PRoCEDURE IF EXISTS altaProyeccion $$
CREATE PROCEDURE altaProyeccion (in unidProyeccion smallint unsigned, in unafechaHora datetime, in unidPelicula smallint unsigned, in unnumSala tinyint unsigned)
BEGIN 

            INSERT INTO Proyeccion (idProyeccion, fechahora, idPelicula, numSala)
                VALUES (unidProyeccion, unafechaHora, unidPelicula, unnumSala)

END

# Se pide hacer el SP ‘venderEntrada’ que reciba por parámetro el id de la función, valor e identificación del cliente. Pensar en cómo hacer para darle valores consecutivos desde 1 al número de entrada por función.


DELIMITER $$
DROP PROCEDURE IF EXISTS venderEntrada $$
CREATE PROCEDURE venderEntrada (in unidProyeccion smallint unsigned, in unidCliente smallint unsigned)
BEGIN

            SELECT * 
            FROM proyeccion 
            where EXISTS ( SELECT *
            FROM proyeccion 
            WHERE idProyeccion = unidProyeccion

            )
            