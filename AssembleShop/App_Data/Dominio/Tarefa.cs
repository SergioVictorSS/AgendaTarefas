using System;

public class Tarefa
{

    public int TAR_Id { get; set; }
    public string TAR_Codigo { get; set; }
    public string TAR_Descricao { get; set; }
    public DateTime TAR_DataHoraCadastro { get; set; }
    public DateTime TAR_DataHoraEntrega { get; set; }

    public int TAR_PRI_IdPrioridade { get; set; }
    public string CorExibicao { get; set; }
    public string TarefaPrioridadeExtenso { get; set; }
    public int OrdemPrioridade { get; set; }

    public int TAR_STA_IdStatus { get; set; }
    public string StatusExtenso {get;set;}

}