CREATE TABLE [dbo].Estados
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Nombre] VARCHAR(20) NOT NULL, 
    CONSTRAINT [PK_Estados] PRIMARY KEY ([Id])
)
