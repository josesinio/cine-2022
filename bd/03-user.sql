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
