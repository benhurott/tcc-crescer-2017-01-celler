/*
*
* SCRIPT DE POPULA��O DE BANCO
* Os testes unit�rios s�o feitos com base em um banco com essas informa��es populadas
*/


select * from anuncio


/*usuario n�o log�vel*/
insert into usuario (nome, email, senha, 
					 notificacaocomentarioanuncioemail,
					 notificacaocomentarioanuncioslack,
					 notificacaocomentarioanunciobrowser,
					 notificacaopresencaemail,
					 notificacaopresencaslack,
					 notificacaopresencabrowser,
					 notificacaointeresseemail,
					 notificacaointeresseslack,
					 notificacaointeressebrowser,
					 notificacaodoacaovaquinhaemail,
					 notificacaodoacaovaquinhaslack,
					 notificacaodoacaovaquinhabrowser)
values('admin', 'admin@admin', 'sem_hash',
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1);

/*usuario log�vel*/
insert into usuario (nome, email, senha, 
					 notificacaocomentarioanuncioemail,
					 notificacaocomentarioanuncioslack,
					 notificacaocomentarioanunciobrowser,
					 notificacaopresencaemail,
					 notificacaopresencaslack,
					 notificacaopresencabrowser,
					 notificacaointeresseemail,
					 notificacaointeresseslack,
					 notificacaointeressebrowser,
					 notificacaodoacaovaquinhaemail,
					 notificacaodoacaovaquinhaslack,
					 notificacaodoacaovaquinhabrowser)
values('teste', 'teste@teste', 'af51a138526519a7ae40c41e7cae5d5c',
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1);



/*anuncio*/
insert into anuncio (titulo, descricao, foto1, foto2, foto3, dataanuncio, idcriador, tipoanuncio,status)

values ('Churras dos Cresceres', 'Churrasco dos cresceres com v�rias op��es de carne e jogos', 
'https://upload.wikimedia.org/wikipedia/commons/5/5c/Churrasco_carioca.jpg', 
'https://www.auxiliadorapredial.com.br/images/vendas/imoveis/210563/i5uU689O93v97_2105635847081e19135.jpg',
null,'20171001',1,'Evento', 'a')


/*evento*/
insert into evento (id,datarealizacao, local, datamaximaconfirmacao, valorporpessoa)
values (1,'20171003', 'CWI Software, 6� andar', '20171001', 10.0)

/*confirmado*/
insert into confirmadoevento(idevento, idusuario)
values (1,1)

/*comentario*/
insert into comentario (texto, datacomentario, idusuario, idanuncio)
values ('Uhul!', '20171002', 1, 1)

insert into comentario (texto, datacomentario, idusuario, idanuncio)
values ('Massa!', '20171002', 2, 1)


/*anuncio*/
insert into anuncio (titulo, descricao, foto1, foto2, foto3, dataanuncio, idcriador, tipoanuncio,status)

values ('Palestra motivacional', 'Palestra motivacional com um tema diferenciado, que o far� se sentir muito melhor e muito mais entediado', 
'http://3.bp.blogspot.com/-X14NwlGRyLk/T2QfWLbOvkI/AAAAAAAAHV0/Y79Ooj2Gweg/s1600/SUCESSO.jpg', 
null,
null,'20171001',2,'Evento', 'd')

/*evento*/
insert into evento (id,datarealizacao, local, datamaximaconfirmacao, valorporpessoa)
values (2,'20171003', 'Audit�rio do Tecnosinos', '20171001', 0.0)

/*comentario*/
insert into comentario (texto, datacomentario, idusuario, idanuncio)
values ('Que chato!', '20171002', 1, 2)







/*anuncio*/
insert into anuncio (titulo, descricao, foto1, foto2, foto3, dataanuncio, idcriador, tipoanuncio, status)

values ('Comic do Batman', 'Comic raro do batman da minha cole��o pessoal, pechincha!', 
'https://images-na.ssl-images-amazon.com/images/I/51L4f5ztm0L._SY344_BO1,204,203,200_.jpg', 
null,
null,'20171001',2,'Produto', 'a')

/*produto*/
insert into produto (id, idcomprador, valor)
values (3,null, 35.0)

/*comentario*/
insert into comentario (texto, datacomentario, idusuario, idanuncio)
values ('Why so serious, S�o Leopoldo?', '20171002', 1, 3)






/*anuncio*/
insert into anuncio (titulo, descricao, foto1, foto2, foto3, dataanuncio, idcriador, tipoanuncio, status)

values ('X�cara personalizada', 'Fa�o x�caras personalizadas', 
null, 
null,
null,'20171001',2,'Produto', 'a')

/*produto*/
insert into produto (id, idcomprador, valor)
values (4,null, 35.0)

/*interessado*/
insert into interessadoproduto(idproduto, idusuario)
values (4,1)








/*anuncio*/
insert into anuncio (titulo, descricao, foto1, foto2, foto3, dataanuncio, idcriador, tipoanuncio, status)

values ('Vaquinha para comparar mi�angas', 'Ajude-nos a fazer um estoque de mi�angas para o inverno', 
'http://www.fishingtur.com.br/imagens/artigos/100/f2.jpg', 
null,
null,'20171001',1,'Vaquinha', 'a')

/*vaquinha*/
insert into vaquinha (id, arrecadamentoprevisto, totalarrecadado, datetermino)
values (5,1500.0, 35.0, '20171225')

/*interessado*/
insert into doador(valordoado, idusuario, status)
values (35.0,2,'n')

insert into doadorvaquinha (idvaquinha, iddoador)
values (5,1)