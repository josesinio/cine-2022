-- 1 Realizar un trigger que verifique que al momento de insertar una entrada, no sobrepase la cantidad de entradas vendidas para la capacidad de la sala correspondiente a la proyección, en ese caso no se debe permitir la operación y se tiene que mostrar la leyenda “Sala Llena”.

Delimiter // 
drop trigger if exists  BefInsEntrada //
CREATE TRIGGER BefInsEntrada BEFORE INSERT ON Entrada For Each row 
begin 
	DECLARE cantidadEntradas TINYINT; 
    Select COUNT(numEntrada) Into cantidadEntradas
    from Entrada 
    join Proyeccion Using (idProyeccion) 
    WHERE idProyeccion = new.idProyeccion;
    
    IF (capacidad <= cantidadEntradas) then 
    signal sqlstate "45000"
	set message_text = "La sala esta llena";
    end if;
end //

 
-- Realizar un trigger para que cada vez que se da de alta una película nueva, se crea una proyección por cada sala y para la fecha y hora de creación.
DELIMITER $$
DROP TRIGGER IF EXISTS aftInsPelicula $$
CREATE TRIGGER afInsPelicula AFTER INSERT ON Pelicula FOR EACH ROW
BEGIN
INSERT INTO Proyeccion(fechaHora, idPelicula, numSala)
    SELECT now(), new.idPelicula, numSala
    FROM Sala;
end $$