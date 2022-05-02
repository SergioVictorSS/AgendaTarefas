CREATE PROCEDURE PESQUISA_TAREFAS
(
@CodigoTarefa VARCHAR(50),
@DescricaoTarefa VARCHAR(100),
@DataInicioBusca DATETIME,
@DataFimBusca DATETIME,
@IdPrioridade INT,
@IdStatus INT
)
AS
BEGIN
SELECT TAR.*,PRI.PRI_CorTag AS CorExibicao, PRI.PRI_Descricao as TarefaPrioridadeExtenso,
PRI.PRI_Ordem AS OrdemPrioridade, STA.STA_Descricao AS StatusExtenso
FROM TAREFA (READUNCOMMITTED) TAR
INNER JOIN PRIORIDADE PRI ON PRI.PRI_Id = TAR.TAR_PRI_IdPrioridade
INNER JOIN STATUS_TAREFA STA ON STA.STA_Id = TAR.TAR_STA_IdStatus
WHERE (TAR_Codigo = @CodigoTarefa OR @CodigoTarefa = '')
AND (TAR.TAR_Descricao LIKE '%'+ @DescricaoTarefa +'%' OR @DescricaoTarefa = '')
AND (TAR.TAR_PRI_IdPrioridade = @IdPrioridade OR @IdPrioridade = 0)
AND TAR.TAR_DataHoraEntrega BETWEEN @DataInicioBusca AND @DataFimBusca
AND (@IdStatus = TAR.TAR_STA_IdStatus OR @IdStatus = 0)
ORDER BY 1 DESC
END