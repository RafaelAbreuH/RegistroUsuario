create database UsuariosDb
go
use UsuariosDb
go
create table Usuario
(
	UsuarioId int primary key identity,
	Nombre varchar(30),
	email varchar(max),
	NivelUsuario varchar(30),
	Usuario varchar(30),
	Clave varchar(30),
	fechaIngreso Datetime
)