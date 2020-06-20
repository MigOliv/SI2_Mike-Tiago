create proc insert_Aluno_Curso (@numAluno int, @siglaCurso char(6), @ano numeric(4))
as
set transaction isolation level read committed
begin transaction
	begin try
		if not exists(select * from Aluno where num = @numAluno)
			throw 50001,'O respetivo aluno nao existe',1

		if not exists(select * from Curso where sigla = @siglaCurso)
			throw 50001,'O respetivo curso nao existe',1

		if exists(select * from Matricula where numAluno = @numAluno and siglaCurso = @siglaCurso and ano = @ano)
			throw 50001,'O respetivo aluno ja esta matriculado neste Curso neste Ano',1

		insert into Matricula values (@numAluno, @siglaCurso, @ano)
	end try
	begin catch
		throw
		rollback
	end catch
commit


--DROP PROC insert_Aluno_Curso
-------------------------------------- Testes ---------------------------------------

 
-- teste aluno nao existe
begin transaction
declare @num int = 39196;
declare @curso char(6) = 'LEC';
declare @ano numeric(4) = 1920;

exec insert_Aluno_Curso @num, @curso, @ano

select * from Matricula

rollback

--teste curso nao existe
begin transaction
declare @num int = 39156;
declare @curso char(6) = 'LIC';
declare @ano numeric(4) = 1920;

exec insert_Aluno_Curso @num, @curso, @ano

select * from Matricula

rollback


-- teste aluno ja esta matriculado
begin transaction
declare @num int = 39156;
declare @curso char(6) = 'LEIC';
declare @ano numeric(4) = 1920;

exec insert_Aluno_Curso @num, @curso, @ano

select * from Matricula

rollback

-- teste insert
begin transaction
declare @num int = 39156;
declare @curso char(6) = 'LEIC';
declare @ano numeric(4) = 1718;

exec insert_Aluno_Curso @num, @curso, @ano

select * from Matricula

rollback