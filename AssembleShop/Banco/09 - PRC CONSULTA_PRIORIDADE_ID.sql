CREATE PROCEDURE CONSULTA_PRIORIDADE_ID
(
@PRI_Id INT
)
AS
BEGIN
SELECT * FROM PRIORIDADE (READUNCOMMITTED) WHERE PRI_Id = @PRI_Id
END