CREATE PROCEDURE TAREFA_ALTERAR
(
@TAR_Id INT,
@TAR_Codigo VARCHAR(50),
@TAR_Descricao VARCHAR(100),
@TAR_PRI_IdPrioridade INT,
@TAR_STA_IdStatus INT,
@TAR_DataHoraEntrega DATETIME
)
AS
BEGIN
UPDATE TAREFA SET
TAR_Codigo = @TAR_Codigo,
TAR_Descricao = @TAR_Descricao,
TAR_PRI_IdPrioridade = @TAR_PRI_IdPrioridade,
TAR_DataHoraEntrega = @TAR_DataHoraEntrega,
TAR_STA_IdStatus = @TAR_STA_IdStatus
WHERE TAR_ID = @TAR_Id
END