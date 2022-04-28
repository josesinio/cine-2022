-- Segundo ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.
DELIMITER %% 
DROP PROCEDURE IF EXISTS registrarCliente %% 
CREATE PROCEDURE registrarCliente (unidCliente INT, unEmail VARCHAR (45), unNombre VARCHAR (45), unApellido VARCHAR (45), unaClave CHAR(64), unNumEntrada INT)
BEGIN
    INSERT INTO Cliente (idCliente, Email, Nombre, Apellido, Clave, NumEntrada)
        VALUES (unidCliente, unEmail, unNombre, unApellido, SHA256 (unaClave, 256), unNumEntrada)
END %% 

-- Cuarto Ejercicio de STORED PROCEDURE 01-SPF.SQL
-- Realizar el SP ‘top10’ que reciba por parámetro 2 fechas, el SP tiene que devolver identificador y nombre de la película y la cantidad de entradas vendidas para la misma entre las 2 fechas. Ordenar por cantidad de entradas de mayor a menor.
DELIMITER %%
DROP PROCEDURE IF EXISTS  top10 %%
CREATE PROCEDURE top10 ()