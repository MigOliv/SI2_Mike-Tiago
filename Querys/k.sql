create proc insert_nota (@numAluno int, @siglaUC char(6), @nota numeric(3,1), @ano numeric(4))
as
set transaction isolation level read committed
begin transaction
	begin try
		if not exists (select * from Aluno where num = @numAluno)
			throw 50001,'O respetivo Aluno não existe',1

		if not exists (select * from UnidadeCurricular where sigla = @siglaUC)
			throw 50001,'A respetiva UC não existe',1

		if not exists (select * from Inscricao where numAluno = @numAluno and siglaUC = @siglaUC and ano = @ano)
			throw 50001,'O respetivo aluno nao esta inscrito na respetiva UC no respetivo ano',1

		update Inscricao set nota = @nota where numAluno = @numAluno and siglaUC = @siglaUC and ano = @ano

	end try
	begin catch
		throw
		rollback
	end catch
commit

--drop proc insert_nota

-------------------------------------- Testes ---------------------------------------

-- Insert nota
begin transaction

exec insert_nota 39156, 'SI2', 20.0, 1920

select * from Inscricao

rollback

-- verificacao Aluno inexistente
begin transaction

exec insert_nota 37482, 'SI2', 20.0, 1920

select * from Inscricao

rollback

-- verificacao de UC inexistente
begin transaction

exec insert_nota 39156, 'SI', 20.0, 1920

select * from Inscricao

rollback

-- verificacao de Aluno nao inscrito na UC
begin transaction

exec insert_nota 39156, 'AVE', 20.0, 1920

select * from Inscricao

rollback
