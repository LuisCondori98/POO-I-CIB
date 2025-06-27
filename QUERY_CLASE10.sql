USE Negocios2022;

CREATE OR ALTER PROC spU_listar_paises
AS
	SELECT * FROM paises
GO

EXEC spU_listar_paises

CREATE OR ALTER PROC spU_listar_clientes
AS
	SELECT
		c.IdCliente,
		c.NombreCia,
		c.Direccion,
		c.Telefono,
		c.IdPais,
		p.NombrePais
	FROM Clientes c
	INNER JOIN paises p ON c.Idpais = p.Idpais
	ORDER BY c.IdCliente
GO

spU_listar_clientes

CREATE OR ALTER PROC spU_Insertar_Cliente
@id VARCHAR(5),
@nomCli VARCHAR(40),
@dirCli VARCHAR(60),
@idPais CHAR(3),
@fonoCli VARCHAR(25)
AS
	INSERT INTO Clientes VALUES(@id, @nomCli, @dirCli, @idPais, @fonoCli)
GO

EXEC spU_Insertar_Cliente 'A0S18', 'Waikiky', 'Miraflores', '001', '159756248'

CREATE OR ALTER PROC spU_actualizar_cliente
	@id VARCHAR(5),
	@nomCli VARCHAR(40),
	@dirCli VARCHAR(60),
	@idPais CHAR(3),
	@fonoCli VARCHAR(25)
AS
	UPDATE 
		Clientes
	SET
		Clientes.NombreCia = @nomCli,
		Clientes.Direccion = @dirCli,
		Clientes.Idpais = @idPais,
		Clientes.Telefono = @fonoCli
	WHERE Clientes.IdCliente = @id
GO

EXEC spU_actualizar_cliente 'A0S18', 'Waikiky', 'SJL', '001', 159756248

CREATE PROC spU_eliminar_cliente
@id VARCHAR(5)
AS
	DELETE FROM Clientes
	WHERE Clientes.IdCliente = @id
GO

EXEC spU_eliminar_cliente 'A0S18'

SELECT * FROM paises;

INSERT INTO paises VALUES('021','Madagascar')