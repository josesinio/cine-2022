call altaGenero (1,"comedia");
call altaSala (1,2,100);
call altaPelicula(1,"son como niños 2", "2004-03-1", 1);
call altaProyeccion (1, "2004-03-1 14:30",1,1);
call registrarCliente(1,"dimitri12@gmail.com", "miguel angel","barreiro","12enletras");
call venderEntrada(900,1,1);
call top10 ("2013-03-02 14:51", "2015-05-05 18:30");
select RecaudacionPara() 