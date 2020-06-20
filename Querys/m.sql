create TRIGGER emitirCertificadoConclusao
ON Inscricao
FOR INSERT,UPDATE
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			SET NOCOUNT ON;
			SET ISOLATION LEVEL REPEATABLE READ;

			DECLARE @nrAluno INT,
					@sigCurso CHAR(6),
					@ano NUMERIC(4);

			SELECT @nrAluno = numAluno, @sigCurso = siglaCurso, @ano=ano FROM inserted

			DECLARE @totalCreditosCurso NUMERIC(3);
			SET @totalCreditosCurso = dbo.getTotalCredits(@sigCurso);

			DECLARE @totalCreditosAluno NUMERIC(3)
			SET @totalCreditosAluno = (
				SELECT sum(numCreditos) FROM UnidadeCurricular uc
										INNER JOIN Inscricao i ON (i.siglaUC = uc.sigla)
										WHERE i.numAluno = @nrAluno AND i.nota >= 9.5 AND i.siglaCurso=@sigCurso

			)
			
			IF (@totalCreditosAluno >= @totalCreditosCurso)
			BEGIN
					
				DECLARE curs CURSOR FOR SELECT i.nota,uc.numCreditos FROM UnidadeCurricular uc
																	 INNER JOIN Inscricao i ON (i.siglaUC = uc.sigla)
																	 WHERE i.numAluno = @nrAluno AND i.nota >= 9.5 AND i.siglaCurso=@sigCurso

				OPEN curs;
				DECLARE @nota NUMERIC(3,1), 
						@numCreditos NUMERIC(3,1),
						@sumNotaAluno NUMERIC(6,2);

			
				SET @sumNotaAluno = 0.00;

				FETCH NEXT FROM curs INTO @nota, @numCreditos;
				
				WHILE(@@FETCH_STATUS) = 0
				BEGIN
					SET @sumNotaAluno = @sumNotaAluno + (@nota*@numCreditos);
					FETCH NEXT FROM curs INTO @nota, @numCreditos;
				END
				CLOSE curs;
				DEALLOCATE curs;


				DECLARE @notaFinal numeric(6,2);
				SET @notaFinal = @sumNotaAluno/@totalCreditosCurso;


				INSERT INTO ConclusaoCurso VALUES (@nrAluno, @sigCurso, @notaFinal, @ano); 


			END

		COMMIT
	END TRY
	BEGIN CATCH
	THROW
	ROLLBACK
	END CATCH
END


------------------- TESTE -----------------------------

--DROP TRIGGER emitirCertificadoConclusao

BEGIN TRANSACTION

insert into UnidadeCurricular values ('TRY1', 'TESTE 1', 90)
insert into UnidadeCurricular values ('TRY2', 'TESTE 2', 90)
insert into UC_Semestre values (2, 'LEIC', 'TRY1', 1920)
insert into UC_Semestre values (4, 'LEIC', 'TRY2', 1920)
insert into Inscricao values (40606, 'LEIC', 'SV', 1920, 'TRY1', NULL);
exec insert_nota 40606, 'TRY1', 10.0, 1920

SELECT * FROM Inscricao
Select * from ConclusaoCurso
insert into Inscricao values (40606, 'LEIC', 'SV', 1920, 'TRY2', NULL);
exec insert_nota 40606, 'TRY2', 10.0, 1920
Select * from ConclusaoCurso
SELECT * FROM Inscricao

ROLLBACK


