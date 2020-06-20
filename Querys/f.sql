-- Remover Unidade Curricular
CREATE PROC remove_UC(@sigla char(6))
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
BEGIN TRY
	IF not exists (select * from UnidadeCurricular where sigla = @sigla)
		throw 50001,'UC nao existe',1

	delete from UnidadeCurricular where sigla=@sigla 
			
END TRY
BEGIN CATCH           
	THROW
	ROLLBACK
END CATCH
COMMIT

--drop proc remove_UC

-- Inserir Unidade Curricular
CREATE PROC insert_UC(@new_sigla char(6), @new_descricao varchar(2500), @nrCreditos numeric(3,1))
AS 
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
BEGIN TRY
	IF exists (select * from UnidadeCurricular where sigla = @new_sigla)
		throw 50001,'UC já existe',1
		        
	insert into UnidadeCurricular (sigla, descricao, numCreditos) values (@new_sigla, @new_descricao, @nrCreditos)
									
END TRY
BEGIN CATCH
	THROW
	ROLLBACK
END CATCH
COMMIT

--drop proc insert_UC

-- Atualizar Unidade Curricular
CREATE PROC update_UC (@UC2update char(6), @new_descricao varchar(2500), @new_numCreditos numeric(3,1))
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
BEGIN TRY
	if not exists (select * from UnidadeCurricular where sigla = @UC2update)
		throw 50001,'UC nao existe',1
		        
	update UnidadeCurricular SET descricao=@new_descricao, numCreditos=@new_numCreditos where sigla=@UC2update
                  
END TRY
BEGIN CATCH
	THROW
	ROLLBACK
END CATCH
COMMIT


-- drop proc update_UC

-------------------------------------- Testes ---------------------------------------

-- testing insert
use TP1

begin transaction
	
	declare @new_sigla char(6) = 'UCT';
	declare @new_descricao varchar(2500) = 'Unidade Curricular de Teste';
	declare @nrCreditos numeric(3,1) = 6.5;

	exec insert_UC @new_sigla, @new_descricao, @nrCreditos

	select * from UnidadeCurricular

commit

-- testing update
begin transaction
	declare @UC2update char(6) = 'UCT';
	declare @new_descricao varchar(2500) = 'New description for Unidade Curricular';
	declare @new_numCreditos numeric(3,1) = 6.5;

	exec update_UC @UC2update, @new_descricao, @new_numCreditos

	select * from UnidadeCurricular

commit

-- testing remove
begin transaction
	declare @sigla2remove char(6) = 'UCT';

	exec remove_UC @sigla2remove

	select * from UnidadeCurricular

commit
