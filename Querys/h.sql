
-- Inserir uma UC num semestre de um Curso num dado ano
create proc insert_UC_Curso (@numSemestre numeric(1), @siglaCurso char(6), @siglaUC char(6), @ano numeric(4))
as
set transaction isolation level read committed
begin transaction
	begin try
		if not exists (select * from UnidadeCurricular where sigla = @siglaUC) -- verificar se a UC existe
			throw 50001,'A UC nao existe',1
		if not exists (select * from Curso where sigla = @siglaCurso) -- verificar se a UC existe
			throw 50001,'Curso nao existe',1
		if exists (select * from UC_Semestre where siglaCurso = @siglaCurso and siglaUC = @siglaUC and ano = @ano) -- verificar se a UC ja foi inserida para este curso no respetivo ano
			throw 50001,'A UC ja existe neste curso neste ano',1

		insert into UC_Semestre values (@numSemestre, @siglaCurso, @siglaUC, @ano)
	end try
	begin catch
		throw
		rollback
	end catch
commit

--drop proc insert_UC_Curso

-- Remover uma UC de um semestre num Curso num dado ano
create proc remove_UC_Curso (@siglaCurso char(6), @siglaUC char(6), @ano numeric(4))
as
set transaction isolation level read uncommitted
begin transaction
	begin try
		if not exists (select * from UnidadeCurricular where sigla = @siglaUC) -- verificar se a UC existe
			throw 50001,'A UC nao existe',1
		if not exists (select * from Curso where sigla = @siglaCurso) -- verificar se a UC existe
			throw 50001,'Curso nao existe',1
		if not exists (select * from UC_Semestre where siglaCurso = @siglaCurso and siglaUC = @siglaUC and ano = @ano) -- verificar se a UC existe neste curso no respetivo ano
			throw 50001,'A UC nao existe neste curso neste ano',1

		delete from UC_Semestre where siglaCurso = @siglaCurso and siglaUC = @siglaUC and ano = @ano

	end try
	begin catch
		throw
		rollback
	end catch
commit

--drop proc remove_UC_Curso



-------------------------------------- Testes ---------------------------------------

-- testing insert
use TP1
begin transaction
declare @numSemestre numeric(1) = 3;
declare @siglaCurso char(6) = 'LEIC';
declare @siglaUC char(6) = 'PC';
declare @ano numeric(4) = 1920;

exec insert_UC_Curso @numSemestre, @siglaCurso, @siglaUC, @ano

select * from UC_Semestre where ano = @ano

commit

-- testing remove
use TP1
begin transaction
declare @numSemestre numeric(1) = 3;
declare @siglaCurso char(6) = 'LEIC';
declare @siglaUC char(6) = 'PC';
declare @ano numeric(4) = 1920;

exec remove_UC_Curso @siglaCurso, @siglaUC, @ano

select * from UC_Semestre where ano = @ano

commit
