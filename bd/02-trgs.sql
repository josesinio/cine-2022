-- 1 Realizar un trigger que verifique que al momento de insertar una entrada, no sobrepase la cantidad de entradas vendidas para la capacidad de la sala correspondiente a la proyección, en ese caso no se debe permitir la operación y se tiene que mostrar la leyenda “Sala Llena”.

SELECT 'Creando triggers' Estado ;

delimiter // 

drop trigger
    if exists BefInsEntrada / /
CREATE TRIGGER
    BefInsEntrada BEFORE
INSERT
    ON Entrada For Each row begin declare cantidadEntradas TINYINT;

declare cantidadButacas smallint unsigned;

Select
    COUNT(numEntrada) into cantidadEntradas
from Entrada
    join Proyeccion Using (idProyeccion)
WHERE
    idProyeccion = new.idProyeccion;

select
    count(capacidad) into cantidadButacas
from Sala
    join Proyeccion Using (idProyeccion)
where
    idProyeccion = new.idProyeccion;

if (
    cantidadButacas <= cantidadEntradas
) then signal sqlstate "45000"
set
    message_text = "La sala esta llena";

end if;

end / / -- Realizar un trigger para que cada vez que se da de alta una película nueva, se crea una proyección por cada sala y para la fecha y hora de creación.

delimiter $$

DROP TRIGGER
    IF EXISTS aftInsPelicula $$
CREATE TRIGGER
    aftInsPelicula AFTER
INSERT
    ON Pelicula FOR EACH ROW BEGIN
INSERT INTO
    Proyeccion(fechaHora, idPelicula, numSala)
SELECT
    now(),
    new.idPelicula,
    numSala
FROM Sala;

end $$ 