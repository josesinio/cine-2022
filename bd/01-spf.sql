-- Primer ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Se pide hacer los SP para dar de alta todas las entidades (menos Entrada y Cliente) con el prefijo ‘alta’.
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

-- Segundo ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.
DELIMITER %% 
DROP PROCEDURE IF EXISTS registrarCliente %% 
CREATE PROCEDURE registrarCliente (unidCliente INT, unEmail VARCHAR (45), unNombre VARCHAR (45), unApellido VARCHAR (45), unaClave CHAR(64), unNumEntrada INT)
BEGIN
    INSERT INTO Cliente (idCliente, Email, Nombre, Apellido, Clave, NumEntrada)
        VALUES (unidCliente, unEmail, unNombre, unApellido, SHA256 (unaClave, 256), unNumEntrada)
END %% 

-- Tercer ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Se pide hacer el SP ‘venderEntrada’ que reciba por parámetro el id de la función, valor e identificación del cliente. Pensar en cómo hacer para darle valores consecutivos desde 1 al número de entrada por función.


DELIMITER $$
DROP PROCEDURE IF EXISTS venderEntrada $$
CREATE PROCEDURE venderEntrada (in unidProyeccion smallint unsigned, in unidCliente smallint unsigned, in numEntrada int not null)  returns smallint reads sql data

BEGIN

        -- 1 ) declarar var para id, se asigna como la cantidad de entradas para esa func + 1.
        -- 2 ) usar ese id para el nro de entrada. 

        declare valor int;

        SELECT count(*)+1 into valor
        FROM Proyeccion 
        JOIN entrada using (numEntrada)
        WHERE idProyeccion = unidProyeccion;
        AND idCliente = unidCliente
        WHERE IF EXISTS (
            SELECT *
            FROM Proyeccion
            where idProyeccion = unidProyeccion) then
            update Proyeccion
            set valor = valor  +1
            where idProyeccion = unidProyeccion
            and idCliente = unidCliente

end $$

-- Cuarto Ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Realizar el SP ‘top10’ que reciba por parámetro 2 fechas, el SP tiene que devolver identificador y nombre de la película y la cantidad de entradas vendidas para la misma entre las 2 fechas. Ordenar por cantidad de entradas de mayor a menor.
DELIMITER %%
DROP PROCEDURE IF EXISTS  top10 %%
CREATE PROCEDURE top10 (unMenorFecha DATETIME, unMayorFecha DATETIME) 
begin 
    SELECT p.idPelicula, nombre, COUNT(*) 'Cantidad de Entradas Vendidas' 
    FROM Pelicula p
    JOIN Proyeccion pro ON p.idPelicula = pro.idPelicula 
    JOIN Entrada e ON pro.idProyeccion = e.idProyeccion
    WHERE fechahora BETWEEN unMenorFecha 
    AND unMayorFecha
    GROUP BY p.idPelicula
    ORDER BY COUNT(*) DESC
end%% 

-- Realizar el SF llamado ‘RecaudacionPara’ que reciba por parámetro un identificador de película y 2 fechas, la función tiene que retornar la recaudación de la película entre esas 2 fechas.

DELIMITER $$
DROP FUNCTION IF EXISTS  RecaudacionPara $$
CREATE FUNCTION RecaudacionPara (in idPelicula smallint unsigned, )