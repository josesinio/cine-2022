/* Administrador
Desde cualquier lado puede ver todas las tablas.
Desde la terminal donde corre el sistema puede agregar y modificar películas, proyecciones y salas.
*/
SELECT 'Creando usuarios' Estado ;
drop user  if exists 'Administrador'@'%';
create user  'Administrador'@'%' identified by 'adminpass';
drop user  if exists 'Administrador'@'localhost';
create user 'Administrador'@'localhost' identified by 'adminpasss';

grant select on CINE.* to  'Administrador'@'%';
grant  insert, update on CINE.Proyeccion to  'Administrador'@'localhost';
grant  insert, update on CINE.Pelicula to  'Administrador'@'localhost';
grant insert, update on CINE.Sala to  'Administrador'@'localhost';

-- Cajero: desde la red 10.3.45.xxx puede ver todas las tablas y puede insertar filas nuevas en Entrada.
DROP USER IF EXISTS 'Cajero'@'10.3.45.%';
CREATE USER 'Cajero'@'10.3.45.%' IDENTIFIED BY 'cajeropass';
GRANT SELECT ON CINE.* TO 'Cajero'@'10.3.45.%';
GRANT INSERT ON CINE.Entrada TO 'Cajero'@'10.3.45.%';

-- Cliente: desde cualquier lado puede ver su información personal, entrada, proyección y película.
DROP USER IF EXISTS 'cliente'@'%';
CREATE USER 'cliente'@'%' IDENTIFIED BY 'Cliente';
GRANT INSERT ON CINE.Cliente TO 'cliente'@'%';
GRANT INSERT ON CINE.Entrada TO 'cliente'@'%';
GRANT INSERT ON CINE.Proyeccion TO 'cliente'@'%';
GRANT INSERT ON CINE.Pelicula TO 'cliente'@'%';