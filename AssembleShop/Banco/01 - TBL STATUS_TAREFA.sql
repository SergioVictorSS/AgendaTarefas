CREATE TABLE STATUS_TAREFA
(
STA_Id INT PRIMARY KEY IDENTITY(1,1),
STA_Descricao VARCHAR(50)
)
INSERT INTO STATUS_TAREFA (STA_Descricao) VALUES ('A fazer')
INSERT INTO STATUS_TAREFA (STA_Descricao) VALUES ('Em andamento')
INSERT INTO STATUS_TAREFA (STA_Descricao) VALUES ('Suspensa')
INSERT INTO STATUS_TAREFA (STA_Descricao) VALUES ('Conclu�da')