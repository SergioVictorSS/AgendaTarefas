USE AgendaTarefasLPII
CREATE TABLE TAREFA 
(
TAR_Id INT PRIMARY KEY IDENTITY(1,1),
TAR_Codigo VARCHAR(50),
TAR_Descricao VARCHAR(100),
TAR_PRI_IdPrioridade INT,
TAR_STA_IdStatus INT,
TAR_DataHoraCadastro DATETIME,
TAR_DataHoraEntrega DATETIME
CONSTRAINT FK_TAREFA_PRIORIDADE FOREIGN KEY (TAR_PRI_IdPrioridade) REFERENCES PRIORIDADE(PRI_Id),
CONSTRAINT FK_TAREFA_STATUS FOREIGN KEY (TAR_STA_IdStatus) REFERENCES STATUS_TAREFA(STA_Id)

)