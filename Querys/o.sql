create view CreditosCurso
as
select ucs.siglaCurso, ucs.siglaUC, uc.numCreditos from UC_Semestre ucs
left join UnidadeCurricular uc on ucs.siglaUC = uc.sigla


--drop view CreditosCurso

-------------------------------------- Testes ---------------------------------------

-- test insert - suposto dar erro
insert into CreditosCurso values ( 'OK', 'KO', 7)

-- test updade sigla Curso - suposto dar erro
update CreditosCurso  set siglaCurso = 'DOT' where siglaCurso = 'LEIC'

-- test update sigla UC - suposto dar erro
update CreditosCurso set siglaUC = 'NEW' where siglaUC = 'SI2'

-- test update numero de creditos
update CreditosCurso set numCreditos = 0 where siglaCurso = 'LEIC'

select * from CreditosCurso
