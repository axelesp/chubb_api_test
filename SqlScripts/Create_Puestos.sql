CREATE TABLE [dbo].Puestos
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Nombre] VARCHAR(30) NOT NULL, 
    CONSTRAINT [PK_Puestos] PRIMARY KEY ([Id])
)
