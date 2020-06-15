create database acaidb;
use acaidb;
CREATE TABLE tamanhos (
  Id smallint PRIMARY KEY,
  Description varchar(255) NOT NULL,
  Valor decimal(5) NOT NULL,
  TempoPreparo bigint
)

CREATE TABLE sabores (
  Id smallint PRIMARY KEY,
  Description varchar(255) NOT NULL,
  TempoAdicional bigint
)

CREATE TABLE pedidos (
  Id bigint PRIMARY KEY IDENTITY (1, 1),
  TempoPreparo bigint NOT NULL,
  ValorTotal decimal(5) NOT NULL,
  SaborId smallint NOT NULL,
  TamanhoId smallint NOT NULL,
  FOREIGN KEY (SaborId) REFERENCES sabores (Id),
  FOREIGN KEY (TamanhoId) REFERENCES tamanhos (Id)
)

CREATE TABLE personalizacoes (
  Id smallint PRIMARY KEY,
  Description varchar(255) NOT NULL,
  ValorAdicional decimal(5) NULL,
  TempoAdicional bigint  NULL
)

create table pedidospersonalizacoes (
   PedidoId bigint NOT NULL,
   PersonalizacaoId smallint NOT NULL,
   FOREIGN KEY (PedidoId) REFERENCES pedidos(Id),
   FOREIGN KEY (PersonalizacaoId) REFERENCES personalizacoes (Id)
)

insert into tamanhos(Id, Description, Valor, TempoPreparo) values(1, 'pequeno (300ml)', 10, 5);
insert into tamanhos(Id, Description, Valor, TempoPreparo) values(2, 'médio (500ml)', 13, 7);
insert into tamanhos(Id, Description, Valor, TempoPreparo) values(3, 'grande (700ml)', 15, 10);

insert into sabores(Id, Description, TempoAdicional) values(1, 'morango', 0);
insert into sabores(Id, Description, TempoAdicional) values(2, 'banana', 0);
insert into sabores(Id, Description, TempoAdicional) values(3, 'kiwi', 5);

insert into personalizacoes(Id, Description, ValorAdicional, TempoAdicional) values(1, 'granola', 0, 0);
insert into personalizacoes(Id, Description, ValorAdicional, TempoAdicional) values(2, 'paçoca', 3, 3);
insert into personalizacoes(Id, Description, ValorAdicional, TempoAdicional) values(3, 'leite ninho', 3, 0);