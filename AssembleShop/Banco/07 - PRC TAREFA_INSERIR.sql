CREATE PROCEDURE TAREFA_INSERIR
(
@TAR_Codigo VARCHAR(50),
@TAR_Descricao VARCHAR(100),
@TAR_PRI_IdPrioridade INT,
@TAR_STA_IdStatus INT,
@TAR_DataHoraCadastro DATETIME,
@TAR_DataHoraEntrega DATETIME
)
AS
BEGIN
INSERT INTO TAREFA 
(TAR_Codigo,TAR_Descricao,TAR_PRI_IdPrioridade,TAR_STA_IdStatus,TAR_DataHoraCadastro,TAR_DataHoraEntrega)
VALUES (@TAR_Codigo,@TAR_Descricao,@TAR_PRI_IdPrioridade,@TAR_STA_IdStatus,@TAR_DataHoraCadastro,@TAR_DataHoraEntrega)
SELECT @@IDENTITY
END