CREATE PROCEDURE [dbo].[spInsEmpleado]
	@Fotografia binary = null,
	@Nombre varchar(20),
	@Apellido varchar(50),
	@PuestoId int,
	@FechaNac date,
	@FechaCont date,
	@Dir varchar(80),
	@Telefono varchar(25),
	@CorreoE varchar(100),
	@EstadoId int
AS
	DECLARE @Result varchar(500);
	BEGIN TRY
		INSERT INTO Empleados (Fotografia, Nombre, Apellido, PuestoId, FechaNacimiento, FechaContratacion, Direccion, Telefono, CorreoElectronico, EstadoId)
		VALUES(@Fotografia, @Nombre, @Apellido, @PuestoId, @FechaNac, @FechaCont, @Dir, @Telefono, @CorreoE, @EstadoId);
		SET @Result = '1';
	END TRY
	BEGIN CATCH
		SET @Result = 'Error: ' + CAST(ERROR_NUMBER() as varchar) + ' - ' + ERROR_MESSAGE(); 
	END CATCH

SELECT @Result;