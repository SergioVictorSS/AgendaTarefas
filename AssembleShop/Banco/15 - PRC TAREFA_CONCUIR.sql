CREATE PROCEDURE TAREFA_CONCLUIR  
(  
@IdTarefa INT  
)  
AS  
BEGIN  
UPDATE TAREFA SET TAR_STA_IdStatus = 4 WHERE TAR_Id = @IdTarefa   
END