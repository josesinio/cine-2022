/* Administrador
Desde cualquier lado puede ver todas las tablas.
Desde la terminal donde corre el sistema puede agregar y modificar películas, proyecciones y salas.
*/
drop user  if exists "Administrador"@"%" ;
drop user  if exists "Administrador"@"localhost";
create user  "Administrador"@"%" identified by "adminpass";
create user "Administrador"@"%" identified by "adminpasss";

grant select on CINE.* to  "Administrador"@"%";
grant  insert, update on CINE.Proyeccion to  "Administrador"@"localhost";
grant  insert, update on CINE.Pelicula to  "Administrador"@"localhost";
grant select, insert, update on CINE.Sala to  "Administrador"@"localhost";

-- Cajero: desde la red 10.3.45.xxx puede ver todas las tablas y puede insertar filas nuevas en Entrada.
DROP USER IF EXISTS 'Cajero'@'10.3.45.%';
CREATE USER IF EXISTS 'Cajero'@'10.3.45.%' IDENTIFIED BY 'cajeropass';
GRANT SELECT ON CINE.* TO 'Cajero'@'10.3.45.%';
GRANT INSERT ON CINE.Entrada TO 'Cajero'@'10.3.45.%';
