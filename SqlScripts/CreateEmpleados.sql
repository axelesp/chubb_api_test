CREATE TABLE [dbo].Empleados
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Fotografia] BINARY(3000) NULL, 
    [Nombre] VARCHAR(20) NOT NULL, 
    [Apellido] VARCHAR(50) NOT NULL, 
    [PuestoId] INT NOT NULL, 
    [FechaNacimiento] DATE NULL, 
    [FechaContratacion] DATE NULL, 
    [Direccion] VARCHAR(80) NULL, 
    [Telefono] VARCHAR(25) NULL, 
    [CorreoElectronico] VARCHAR(100) NOT NULL, 
    [EstadoId] INT NOT NULL,
	CONSTRAINT FK_Estados FOREIGN KEY (EstadoId) REFERENCES Estados(Id),
	CONSTRAINT FK_Puestos FOREIGN KEY (PuestoId) REFERENCES Puestos(Id)
)
