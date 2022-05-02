using AgendaTarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgendaTarefaPaginas
{
    public partial class AgendaTarefasInicio : PaginaBase
    {
        TarefaController tarefasController = new TarefaController(SDBC.Instance);
        static bool reverse = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheDropDownList(lstPrioridade, "PRIORIDADE_CONSULTAR_LIST_PREENCHIMENTO", 0, true, "Todas");
                PreencheDropDownList(lstStatus, "STATUS_CONSULTAR_LIST_PREENCHIMENTO", 0, true, "Todas");
                txtDataEntregaIni.Value = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                txtDataEntregaFim.Value = DateTime.Now.ToString("yyyy-MM-dd");
                CarregarGrid();
            }
        }
        protected void CarregarGrid(string sortExpression = "",bool reverso = false)
        {
            tarefasController.PreencherGridViewOrdenada(grvBusca,sortExpression,reverso, txtCodigo.Value, txtDescricaoTatrefa.Value, Convert.ToDateTime(txtDataEntregaIni.Value), Convert.ToDateTime(txtDataEntregaFim.Value), Convert.ToInt32(lstPrioridade.SelectedValue), Convert.ToInt32(lstStatus.SelectedValue));
        }
        protected void grvBusca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ("Sort".Equals(e.CommandName))
                return;
            int idTarefa = Convert.ToInt32(grvBusca.DataKeys[int.Parse(e.CommandArgument.ToString())][0].ToString());
            switch (e.CommandName)
            {
                case "Excluir":
                    tarefasController.ExcluirTarefa(idTarefa);
                    break;
                case "Concluir":
                    tarefasController.ConcluirTarefa(idTarefa);
                    break;
            }
            CarregarGrid();
        }
        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarGrid();
                if (!string.IsNullOrEmpty(Convert.ToString(Session["MensagemNotificacao"])))
                {
                    Notificar(Session["MensagemNotificacao"].ToString(), TipoNotificacao.Sucesso);
                    Session["MensagemNotificacao"] = string.Empty;
                }
            }
            catch (FormatException)
            {
                Notificar("Necessário preencher as datas corretamente!",TipoNotificacao.Alerta);
            }
            catch(Exception ex)
            {
                InserirLog(ex);
                Notificar("Ocorreu um erro interno ao tentar pesquisar", TipoNotificacao.Erro);

            }
        }

        protected void grvBusca_Sorting(object sender, GridViewSortEventArgs e)
        {
            CarregarGrid(e.SortExpression, reverse);
            reverse = !reverse;
        }
    }
}