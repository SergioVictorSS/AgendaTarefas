using System.Web.UI.WebControls;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AgendaTarefas
{
    public class PrioridadeController : Controller<Prioridade>
    {
        MyDBContext _dbContext;
        public PrioridadeController(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Prioridade BuscarId(int idPrioridade)
        {
            return _dbContext.Database.SqlQuery<Prioridade>("CONSULTA_PRIORIDADE_ID {0}", new object[] { idPrioridade }).ToList().FirstOrDefault();
        }

        public List<Prioridade> Listar(Prioridade prioridadeBuscada)
        {
            return _dbContext.Database.SqlQuery<Prioridade>("PESQUISA_PRIORIDADE {0}, {1}, {2}", new object[] { prioridadeBuscada.PRI_Codigo, prioridadeBuscada.PRI_Descricao,prioridadeBuscada.PRI_Ordem}).ToList();
        }

        public decimal Inserir(Prioridade prioridade)
        {
            return _dbContext.Database.SqlQuery<decimal>("PRIORIDADE_INSERIR {0}, {1}, {2}, {3}", new object[] { prioridade.PRI_Codigo, prioridade.PRI_Descricao,prioridade.PRI_CorTag,prioridade.PRI_Ordem}).ToList().FirstOrDefault();
        }
        public void Alterar(Prioridade prioridade)
        {
            _dbContext.Database.ExecuteSqlCommand("PRIORIDADE_ALTERAR {0}, {1}, {2}, {3}, {4}", new object[] { prioridade.PRI_Id, prioridade.PRI_Codigo, prioridade.PRI_Descricao, prioridade.PRI_CorTag, prioridade.PRI_Ordem });
        }
        public void Excluir(int idPrioridade)
        {
            throw new NotImplementedException();
        }
    }
}
