
create proc inscrever_Aluno_UC (@numAluno int, @siglaUC char(6), @ano numeric(4))
as
set transaction isolation level read committed
begin transaction
	begin try
		if not exists(select * from UnidadeCurricular where sigla = @siglaUC)
			throw 50001,'A UC não existe',1
		if not exists(select * from Matricula where numAluno = @numAluno AND ano = @ano)
			throw 50001,'O respetivo aluno nao está matriculado neste ano',1
		
		declare @siglaCurso char(6) = (select siglaCurso from Matricula where numAluno = @numAluno AND ano = @ano)
		if not exists(Select * from UC_Semestre WHERE siglaCurso = @siglaCurso AND siglaUC = @siglaUC)
			throw 50001,'A UC não é lecionada no curso a que o aluno está matriculado neste ano',1
		
		if exists(select * from Inscricao Where numAluno=@numAluno AND siglaUC=@siglaUC AND nota > 9.5)
			throw 50001,'O aluno já está aprovado a esta UC, se pretende fazer melhoria contacte a os servicos academicos.',1
		
		
		declare @siglaSemestreLetivo char(6);
		declare @numSemestreUC numeric(1) = (Select numSemestre from UC_Semestre WHERE siglaCurso = @siglaCurso and siglaUC = @siglaUC and ano = @ano)
		set @numSemestreUC = (@numSemestreUC % 2)

		if(@numSemestreUC = 0)
			set @siglaSemestreLetivo = 'SV'
		else
			set @siglaSemestreLetivo = 'SI'


		insert into Inscricao values (@numAluno, @siglaCurso, @siglaSemestreLetivo, @ano, @siglaUC, null)
		
	end try
	begin catch
		throw
		rollback
	end catch
commit


--drop proc inscrever_Aluno_UC

-------------- Teste ---------------------

Select * From UnidadeCurricular
Select * From Aluno
SELECT * FROM INSCRICAO


--VERIFICAÇÃO DE CADEIRA JÁ APROVADA
begin transaction

Insert into Inscricao values (40623, 'LEIC', 'SV', 1819, 'SI2', 15.00)
exec inscrever_Aluno_UC 40623, 'SI2', 1920

Select * from Inscricao
rollback

-- verificacao de UC nao existente
begin transaction

exec inscrever_Aluno_UC 40623, 'SI3', 1920

Select * from Inscricao
rollback

-- verificacao de Aluno nao matriculado
begin transaction

exec inscrever_Aluno_UC 38285, 'SI2', 1819

Select * from Inscricao
rollback

-- verificacao de UC nao lecionada nesse ano
begin transaction

exec inscrever_Aluno_UC 40623, 'LS', 1920

Select * from Inscricao
rollback

-- Inscricao Correcta
begin transaction

exec inscrever_Aluno_UC 40623, 'AVE', 1920

Select * from Inscricao
rollback
