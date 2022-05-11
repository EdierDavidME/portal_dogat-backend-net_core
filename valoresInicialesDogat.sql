USE DogatDB
INSERT INTO Paises (Nombre) VALUES ('Colombia');
INSERT INTO Departamentos (PaisId, Nombre) VALUES ((SELECT TOP 1 Id FROM Paises where Nombre like 'Colombia'), 'Antioquia');
INSERT INTO Ciudades(DepartamentoId, Nombre) VALUES ((SELECT TOP 1 Id FROM Departamentos where Nombre like 'Antioquia'), 'Antioquia');

INSERT INTO Planes (Codigo, Nombre, Precio, NumeroFotos, NumeroPublicaciones, Meses, Prioridad) VALUES (1, 'Gratis', 0, 3, 1, 1, 1);
INSERT INTO Planes (Codigo, Nombre, Precio, NumeroFotos, NumeroPublicaciones, Meses, Prioridad) VALUES (2, 'Bronce', 40000, 5, 2, 3, 2);
INSERT INTO Planes (Codigo, Nombre, Precio, NumeroFotos, NumeroPublicaciones, Meses, Prioridad) VALUES (3, 'Plata', 75000, 5, 3, 3, 3);
INSERT INTO Planes (Codigo, Nombre, Precio, NumeroFotos, NumeroPublicaciones, Meses, Prioridad) VALUES (4, 'Oro', 140000, 5, 4, 3, 4);
INSERT INTO Planes (Codigo, Nombre, Precio, NumeroFotos, NumeroPublicaciones, Meses, Prioridad) VALUES (5, 'Diamante', 190000, 8, 6, 4, 5);

INSERT INTO Usuarios (Cedula_Nit, Nombre, Correo, Contraseña, Rol) VALUES (1, 'ADMIN', 'admin', '12345', 1);

--Para pruebas
INSERT INTO Usuarios (Cedula_Nit, Nombre, Correo, Contraseña, Rol, PlanActivoId , FechaVencimiento, PublicacionesRestantes) VALUES (2, 'cDiamante', 'cdiamante', '12345', 2,
	(SELECT TOP 1 Id FROM Planes WHERE Codigo = 5), '2022-12-12', 6
);