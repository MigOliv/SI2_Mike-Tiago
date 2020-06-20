-- Inserir Seccao
CREATE PROC insert_Seccao (@new_sigla char(6), @new_siglaDep char(6), @new_descricao varchar(2500))
AS 
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
BEGIN TRY
	IF not exists (SELECT * FROM Departamento WHERE sigla = @new_siglaDep)
		THROW 50001,'Departamento não existe',1
	IF exists (SELECT * FROM Seccao WHERE sigla = @new_sigla AND siglaDepartamento = @new_siglaDep)
		THROW 50001,'Seccao já existe',1
		        
	INSERT INTO Seccao VALUES (@new_sigla, @new_siglaDep, @new_descricao)
									
END TRY
BEGIN CATCH
	THROW
	ROLLBACK
END CATCH
COMMIT

--DROP PROC insert_Seccao


-- Atualizar Seccao
CREATE PROC update_Seccao (@sigla2update char(6), @new_siglaDep char(6), @new_descricao varchar(2500))
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
BEGIN TRY
	IF not exists (SELECT * FROM Departamento WHERE sigla = @new_siglaDep)
		THROW 50001,'Departamento nao existe',1
	IF not exists (SELECT * FROM Seccao WHERE sigla = @sigla2update AND siglaDepartamento = @new_siglaDep)
		THROW 50001,'Seccao não existe',1
		        
	UPDATE Seccao SET siglaDepartamento = @new_siglaDep, descricao = @new_descricao WHERE sigla = @sigla2update
                  
END TRY
BEGIN CATCH
	THROW
	ROLLBACK
END CATCH
COMMIT

--DROP PROC update_Seccao

-- Remover Seccao
CREATE PROC remove_Seccao (@sigla char(6), @siglaDepartamento char(6))
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
BEGIN TRY
	IF not exists (SELECT * FROM Seccao WHERE sigla = @sigla AND siglaDepartamento = @siglaDepartamento)
		THROW 50001,'Secção nao existe',1

	DELETE FROM Seccao WHERE sigla = @sigla 
			
END TRY
BEGIN CATCH   
	THROW
	ROLLBACK
END CATCH
COMMIT

--DROP PROC remove_Seccao

-------------------------------------- Testes ---------------------------------------

-- testing insert
use TP1

begin transaction
	
	declare @new_sigla char(6) = 'STEST';
	declare @new_siglaDep char(6) = 'ADEETC';
	declare @new_descricao varchar(2500) = 'Seccao de Teste';

	exec insert_Seccao @new_sigla, @new_siglaDep, @new_descricao

	select * from Seccao

commit

-- testing update
begin transaction
	declare @sigla2update char(6) = 'STEST';
	declare @new_siglaDep char(6) = 'ADEETC';

	exec update_Seccao @sigla2update, @new_siglaDep, 'New description test'

	select * from Seccao

commit

-- testing remove
begin transaction
	declare @sigla2remove char(6) = 'STEST';
	declare @siglaDep char(6) = 'ADEETC';
	exec remove_Seccao @sigla2remove, @siglaDep

	select * from Seccao

commit
