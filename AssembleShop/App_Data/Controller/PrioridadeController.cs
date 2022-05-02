using System.Web.UI.WebControls;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AgendaTarefas
{
    public class PrioridadeController
    {
        MyDBContext _dbContext;
        public PrioridadeController(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Prioridade GetPrioridade(int idPrioridade)
        {
            return _dbContext.Database.SqlQuery<Prioridade>("CONSULTA_PRIORIDADE_ID {0}", new object[] { idPrioridade }).ToList().FirstOrDefault();
        }

        public List<Prioridade> GetPrioridades(string codigoPrioridade, string descricaoPrioridade, int ordem)
        {
            return _dbContext.Database.SqlQuery<Prioridade>("PESQUISA_PRIORIDADE {0}, {1}, {2}", new object[] { codigoPrioridade, descricaoPrioridade,ordem}).ToList();
        }

        public decimal InserirPrioridade(Prioridade prioridade)
        {
            return _dbContext.Database.SqlQuery<decimal>("PRIORIDADE_INSERIR {0}, {1}, {2}, {3}", new object[] { prioridade.PRI_Codigo, prioridade.PRI_Descricao,prioridade.PRI_CorTag,prioridade.PRI_Ordem}).ToList().FirstOrDefault();
        }
        public void AlterarPrioridade(Prioridade prioridade)
        {
            _dbContext.Database.ExecuteSqlCommand("PRIORIDADE_ALTERAR {0}, {1}, {2}, {3}, {4}", new object[] { prioridade.PRI_Id, prioridade.PRI_Codigo, prioridade.PRI_Descricao, prioridade.PRI_CorTag, prioridade.PRI_Ordem });
        }
    }
}
