create proc listUCwithNoInsc (@anoInicial numeric(4), @anoFinal numeric(4))
as
set transaction isolation level repeatable read
begin transaction
	begin try
		set nocount on
		declare @mySiglaUC char(6), @myAno numeric(4);
		declare @toRet as table(siglaUC char(6), ano numeric(4))
		declare curs cursor for select siglaUC, ano from UC_Semestre
		open curs
		fetch next from curs into @mySiglaUC, @myAno
		while (@@FETCH_STATUS = 0)
		begin
			if (@myAno >= @anoInicial and @myAno <= @anoFinal)
			begin
				if not exists (select siglaUC, ano from Inscricao where siglaUC = @mySiglaUC and ano = @myAno)
					insert into @toRet values (@mySiglaUC, @myAno)
			end
			fetch next from curs into @mySiglaUC, @myAno
		end
		close curs;
		deallocate curs;
		select * from @toRet
	
	end try
	begin catch
		throw
		rollback
	end catch
commit


--drop proc listUCwithNoInsc

--------------------TESTES---------
-- inserir UCs oferecidas aos cursos

insert into UC_Semestre values (5, 'LEIC', 'SI2', 1718)
insert into UC_Semestre values (5, 'LEIC', 'AVE', 1718)
insert into UC_Semestre values (5, 'LEIC', 'SI2', 1819)

-- verificar todas as UCs com inscricoes
select siglaUC, ano from Inscricao

-- verificar todas as UCs oferecidas aos cursos
select siglaUC, ano from UC_Semestre

-- testar - SI2 1920 nao deve aparecer
use TP1
begin transaction
exec listUCwithNoInsc 1516, 1920

rollback

-- testar - SI2 1920 nao deve aparecer e so devem aparecer as cadeiras entre 1819 e 1920 inclusive
begin transaction
exec listUCwithNoInsc 1819, 1920

rollback

-- testar - AVE 1718 e SI2 1920 nao deve aparecer e so devem aparecer as cadeiras entre 1617 e 1920 inclusive
begin transaction
insert into SemestreLetivo values ('SV', 1718, 'Semestre de Verao')
insert into Matricula values (39156, 'LEIC', 1718)
insert into Inscricao values (39156, 'LEIC', 'SV', 1718, 'AVE', null)

exec listUCwithNoInsc 1617, 1920

rollback

-- testar - Nao deve aparecer nenhuma cadeira
begin transaction
exec listUCwithNoInsc 1516, 1617

rollback
