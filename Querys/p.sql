create proc alunosMatriculadosMaisTresAnos (@currentYear numeric(4), @siglaCurso char(6))
as
set transaction isolation level read uncommitted
begin transaction
	begin try

		if not exists (select * from Curso where sigla = @siglaCurso)
			throw 50001,'O respetivo Curso não existe',1

		select distinct numAluno from Matricula
		where siglaCurso = @siglaCurso and (@currentYear - ano) > 300
			and numAluno not in(
								select numAluno from ConclusaoCurso where siglaCurso = @siglaCurso
								)
		end try
		begin catch
			throw
			rollback
		end catch
commit
	
--drop proc alunosMatriculadosMaisTresAnos

-------------------------------------- Testes ---------------------------------------

-- testar aluno ha mais de 3 anos no respetivo curso sem ter concluido o curso
begin transaction

insert into Matricula values (39156, 'LEIC', 1617)

exec alunosMatriculadosMaisTresAnos 1920, 'LEIC'

rollback

-- testar aluno ha mais de 3 anos no respetivo curso com o curso concluido
begin transaction

insert into Matricula values (39156, 'LEIC', 1617)
insert into ConclusaoCurso values (39156, 'LEIC', 20, 1920)

exec alunosMatriculadosMaisTresAnos 1920, 'LEIC'

rollback
