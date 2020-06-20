create function dbo.getTotalCredits (@siglaCurso char(6))
returns numeric(3)
as
begin
	declare @totalCredits numeric(3) = (select totalCreditos from Curso where sigla = @siglaCurso)
	return(@totalCredits)
end
go

--drop function dbo.getTotalCredits

-------------------------------------- Testes ---------------------------------------

-- teste 1
use TP1
print dbo.getTotalCredits('LEIC')


