Create table TipoUsuario (
	PK_TipoUsuario int primary key not null,
	Descripcion varchar(30) not null
	);
	
Create table Usuarios (
	PK_IdUsuario int primary key not null,
    Nombre varchar(30) not null,
    Apellido varchar(30) not null,
    Direccion varchar(30) not null,
    Telefono int not null,
	Usuario varchar(50) not null,
	Correo varchar(100) not null,
	Contraseña varchar(20) not null,
	FK_TipoUsuario int not null,
	FOREIGN KEY (FK_TipoUsuario) REFERENCES TipoUsuario(PK_TipoUsuario)
	);


Create table Rutinas (
	PK_IdRutina int IDENTITY(1,1) primary key not null,
	ID_Cliente int not null,
	ID_Entrenador int not null,
	Ejercicio1 varchar(30) not null,
	Ejercicio2 varchar(30) not null,
	Ejercicio3 varchar(30) not null,
	Ejercicio4 varchar(30) not null,
	FOREIGN KEY (ID_Cliente) REFERENCES Usuarios(PK_IdUsuario),
	FOREIGN KEY (ID_Entrenador) REFERENCES Usuarios(PK_IdUsuario)
	);

Create table Facturas (
	PK_IdFactura int IDENTITY(1,1) primary key not null,
	ID_Cliente int not null,
	Mensualidad int not null,
	Iva int not null,
	Total int not null,
	FOREIGN KEY (ID_Cliente) REFERENCES Usuarios(PK_IdUsuario),
	);