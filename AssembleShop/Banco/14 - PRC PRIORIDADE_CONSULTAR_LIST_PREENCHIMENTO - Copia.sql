CREATE PROCEDURE PRIORIDADE_CONSULTAR_LIST_PREENCHIMENTO  
AS  
BEGIN  
SELECT PRI_Descricao AS Texto, PRI_Id as Valor FROM PRIORIDADE (READUNCOMMITTED)
ORDER BY PRI_Ordem DESC
END  