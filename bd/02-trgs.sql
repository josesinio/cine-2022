-- Realizar un trigger que verifique que al momento de insertar una entrada, no sobrepase la cantidad de entradas vendidas para la capacidad de la sala correspondiente, en ese caso no se debe permitir la operación y se tiene que mostrar la leyenda “Sala Llena”.

Delimiter $$
drop trigger if exists 	befinsentrada $$
create trigger befinsentrada before insert on entrada for each row
begin
			if (exists( select count(numEntrada)
						from Entrada 
                        join Proyeccion using (idProyeccion)
                        join Sala S using (numSala)
                        where S.numSala = new.numSala
                        and count(numEntrada) > capacidad)) then 
						signal sqlstate "45000"
                        set message_text = "La sala esta llena";
				end if;
end $$ 
-- Realizar un trigger para que cada vez que se da de alta una película nueva, se crea una proyección por cada sala y para la fecha y hora de creación.