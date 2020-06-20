
CREATE PROC remove_Departamento (@sigla CHAR(6))
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
BEGIN TRY
	IF not exists (SELECT * FROM Departamento WHERE sigla = @sigla)
		THROW 50001,'O respetivo Departamento nao existe',1
		 
	DELETE FROM Departamento WHERE sigla = @sigla 

					
END TRY
BEGIN CATCH           
	THROW
END CATCH
COMMIT

--DROP PROC remove_Departamento

CREATE PROC insert_Departamento (@new_sigla CHAR(6), @new_descricao VARCHAR(2500))
AS 
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
BEGIN TRY
	IF exists (SELECT * FROM Departamento WHERE sigla = @new_sigla)
		THROW 50001,'O respetivo Departamento já existe',1
		        
	INSERT INTO Departamento VALUES (@new_sigla, @new_descricao)
									
END TRY
BEGIN CATCH
	THROW
END CATCH
COMMIT


--DROP PROC insert_Departamento


CREATE PROC update_Departamento (@sigla CHAR(6), @new_descricao VARCHAR(2500))
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
BEGIN TRY
	IF not exists (SELECT * FROM Departamento WHERE sigla = @sigla)
		THROW 50001,'O respetivo Departamento nao existe',1
		        
	UPDATE Departamento SET  descricao=@new_descricao WHERE sigla=@sigla
                  
END TRY
BEGIN CATCH
	THROW
END CATCH
COMMIT

--DROP PROC update_Departamento

-------------------------------------- Testes ---------------------------------------


-- testing insert
begin transaction

exec insert_Departamento 'ADPV', 'Area Departamental das Plantas Vermelhas'

select * from Departamento
rollback

-- testing insert already exist 
begin transaction

exec insert_Departamento 'ADEETC', 'Area Departamental de Engenharia Eletronica e Telecomunicacoes e de Computadores'

select * from Departamento
rollback

-- testing update 
begin transaction

exec update_Departamento 'ADEETC', 'Area Departamental de Engenharia Teste'

select * from Departamento
rollback

-- testing update DEP not exist
begin transaction

exec update_Departamento 'ADO', 'Area Departamental de Engenharia Teste'

select * from Departamento
rollback


-- testing remove and verify it is removed from othe tables
begin transaction

exec remove_Departamento'ADEETC'

select * from Departamento
select * from CoordenadorSeccao
rollback

-- testing remove DEP not exist
begin transaction

exec remove_Departamento'ADO'

select * from Departamento
rollback
