﻿using System.Web.UI.WebControls;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AgendaTarefas
{
    public class TarefaController
    {
        MyDBContext _dbContext;
        public TarefaController(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Tarefa GetTarefa(int idTarefa)
        {
            return _dbContext.Database.SqlQuery<Tarefa>("CONSULTA_TAREFA_ID {0}", new object[] { idTarefa }).ToList().FirstOrDefault();
        }

        public List<Tarefa> GetTarefas(string codigoTarefa, string DescricaoTarefa, DateTime DataInicioBusca, DateTime DataFimBusca,int idPrioridade, int idStatus)
        {
            return _dbContext.Database.SqlQuery<Tarefa>("PESQUISA_TAREFAS {0}, {1}, {2}, {3}, {4},{5}", new object[] { codigoTarefa,DescricaoTarefa,DataInicioBusca,DataFimBusca,idPrioridade, idStatus }).ToList();
        }

        public decimal InserirTarefa(Tarefa tarefa)
        {
           return _dbContext.Database.SqlQuery<decimal>("TAREFA_INSERIR {0}, {1}, {2}, {3}, {4},{5}", new object[] { tarefa.TAR_Codigo,tarefa.TAR_Descricao, tarefa.TAR_PRI_IdPrioridade,tarefa.TAR_STA_IdStatus,tarefa.TAR_DataHoraCadastro,tarefa.TAR_DataHoraEntrega  }).ToList().FirstOrDefault();
        }
        public void AlterarTarefa(Tarefa tarefa)
        {
            _dbContext.Database.ExecuteSqlCommand("TAREFA_ALTERAR {0}, {1}, {2}, {3}, {4},{5}", new object[] { tarefa.TAR_Id,tarefa.TAR_Codigo, tarefa.TAR_Descricao, tarefa.TAR_PRI_IdPrioridade, tarefa.TAR_STA_IdStatus, tarefa.TAR_DataHoraEntrega });
        }
        public void ExcluirTarefa(int idTarefa)
        {
            _dbContext.Database.ExecuteSqlCommand("TAREFA_EXCUIR {0}", new object[] { idTarefa });
        }
        public void ConcluirTarefa(int idTarefa)
        {
            _dbContext.Database.ExecuteSqlCommand("TAREFA_CONCLUIR {0}", new object[] { idTarefa });

        }
        public void PreencherGridViewOrdenada(GridView gridView, string sortExpression, bool reverse, string codigoTarefa, string DescricaoTarefa, DateTime DataInicioBusca, DateTime DataFimBusca, int idPrioridade,int idStatus)
        {
            var tarefas = GetTarefas( codigoTarefa,  DescricaoTarefa,  DataInicioBusca,  DataFimBusca,  idPrioridade,idStatus);
            switch (sortExpression)
            {
                case "prioridade":
                    tarefas = tarefas.OrderBy(t => t.OrdemPrioridade).ToList();
                    break;
                case "descricao":
                    tarefas = tarefas.OrderBy(t => t.TAR_Descricao).ToList();
                    break;
                case "prazo":
                    tarefas = tarefas.OrderBy(t => t.TAR_DataHoraEntrega).ToList();
                    break;
                case "codigo":
                    tarefas = tarefas.OrderBy(t => t.TAR_Codigo).ToList();
                    break;
                case "status":
                    tarefas = tarefas.OrderBy(t => t.StatusExtenso).ToList();
                    break;
            }
            if (reverse)
                tarefas.Reverse();
            gridView.DataSource = tarefas;
            gridView.DataBind();
        }
    }
}
