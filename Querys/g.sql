-- Criar Estrutura geral de um Curso

create proc estruturaCurso (@siglaDepartamento char(6), @siglaCurso char(6), @descricaoCurso varchar(255))
as
set transaction isolation level read committed
begin transaction
	begin try

		if not exists (select * from Departamento where sigla = @siglaDepartamento)
			throw 50001,'O respetivo Departamento não existe',1

		insert into Curso values (@siglaCurso, @descricaoCurso, @siglaDepartamento, 180)
		insert into Semestre values (1, @siglaCurso)
		insert into Semestre values (2, @siglaCurso)
		insert into Semestre values (3, @siglaCurso)
		insert into Semestre values (4, @siglaCurso)
		insert into Semestre values (5, @siglaCurso)
		insert into Semestre values (6, @siglaCurso)

	end try
	begin catch
		throw
		rollback
	end catch
commit

--drop proc estruturaCurso

-------------------------------------- Testes ---------------------------------------


-- teste Departamento nao existe
begin transaction

exec estruturaCurso 'ADEETS', 'SIP', 'Seguranca da Informacao Partilhada'

select * from Curso

rollback

-- teste create Curso Struct
begin transaction

exec estruturaCurso 'ADEETC', 'SIP', 'Seguranca da Informacao Partilhada'

select * from Curso
Select * from Semestre

rollback