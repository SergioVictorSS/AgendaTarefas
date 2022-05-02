CREATE PROCEDURE PESQUISA_PRIORIDADE
(
@CodigoPrioridade VARCHAR(50),
@DescricaoPrioridade VARCHAR(100),
@OrdemPrioridade INT
)
AS
BEGIN
SELECT * FROM PRIORIDADE WHERE
(PRI_Codigo = @CodigoPrioridade OR @CodigoPrioridade = '') AND
(PRI_Descricao LIKE '%' + @DescricaoPrioridade + '%' OR @DescricaoPrioridade = '') AND
(PRI_Ordem = @OrdemPrioridade OR @OrdemPrioridade = 0)
ORDER BY PRI_Ordem
END