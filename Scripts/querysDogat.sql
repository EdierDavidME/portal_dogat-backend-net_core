DROP DATABASE DogatDB;
CREATE DATABASE DogatDB;
USE DogatDB;

CREATE TABLE Paises(
	Id int IDENTITY(1,1) NOT NULL,
	Nombre varchar(30) NOT NULL,
	PRIMARY KEY (Id)
);

CREATE TABLE Departamentos(
	Id int IDENTITY(1,1) NOT NULL,
	PaisId int NOT NULL,
	Nombre varchar(30) NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (PaisId) REFERENCES Paises(Id)
);

CREATE TABLE Ciudades(
	Id int IDENTITY(1,1) NOT NULL,
	DepartamentoId int NOT NULL,
	Nombre varchar(30) NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (DepartamentoId) REFERENCES Departamentos(Id)
);

CREATE TABLE Planes(
	Id int IDENTITY(1,1) NOT NULL,
	Codigo int UNIQUE NOT NULL,
	Nombre varchar(30) NOT NULL,
	Precio float NULL,
	NumeroFotos int NOT NULL,
	NumeroPublicaciones int NOT NULL,
	Meses int NOT NULL,
	Prioridad float NOT NULL,
	PRIMARY KEY (Id)
);

CREATE TABLE Usuarios (
	Id int IDENTITY(1,1) NOT NULL,
	Cedula_Nit varchar UNIQUE NOT NULL,
	Nombre varchar(30) NOT NULL,
	Correo varchar(30) UNIQUE NOT NULL,
	Contrasena varchar(30) NOT NULL,
	PlanActivoId int NULL,
	FechaVencimiento DateTime NULL,
	PublicacionesRestantes int NULL,
	Rol int NOT NULL, -- 1: Admin, 2: Cliente
	PRIMARY KEY (Id),
	FOREIGN KEY (PlanActivoId) REFERENCES Planes(Id)
);

CREATE TABLE Compras (
	Id int IDENTITY(1,1) NOT NULL,
	UsuarioId int NOT NULL,
	PlanId int NOT NULL,
	FechaCompra DateTime NOT NULL,
	Valor float NOT NULL,
	Visible bit DEFAULT 0,
	Observacion varchar(200),
	PRIMARY KEY (Id),
	FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
	FOREIGN KEY (PlanId) REFERENCES Planes(Id)
);

CREATE TABLE Publicaciones (
	Id int IDENTITY(1,1) NOT NULL,
	UsuarioId int NOT NULL,
	CiudadId int NOT NULL,
	FechaCreacion DateTime NOT NULL,
	FechaVencimiento DateTime NOT NULL,
	NombreMascota varchar(30) NULL,
	Precio Float NULL,
	Tipo int NOT NULL, --1: 'Busqueda', 2: 'Adopcion', 3: 'Venta'
	Descripcion varchar(200) NULL,
	Visible bit DEFAULT 0,
	PRIMARY KEY (Id),
	FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
	FOREIGN KEY (CiudadId) REFERENCES Ciudades(Id)
);

CREATE TABLE Fotos (
	Id int IDENTITY(1,1) NOT NULL,
	PublicacionId int NOT NULL,
	Nombre varchar(200),
	Ruta varchar(200),
	PRIMARY KEY (Id),
	FOREIGN KEY (PublicacionId) REFERENCES Publicaciones(Id)
);