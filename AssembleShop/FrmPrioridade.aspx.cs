using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AgendaTarefas;
using System.Web.UI.HtmlControls;
namespace AgendaTarefaPaginas
{
    public partial class FrmPrioridade : PaginaBase<Prioridade>
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarController(new PrioridadeController(SDBC.Instance));

            if (!IsPostBack)
                CarregarGrid();      

        }
        protected void CarregarGrid()
        {
            if (string.IsNullOrEmpty(txtOrdemPrioridade.Value))
                txtOrdemPrioridade.Value = "0";
            grvBusca.DataSource = controller.Listar(GerarPrioridade());
            grvBusca.DataBind();
        }

        protected void grvBusca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                controller.Alterar(GerarPrioridade(grvBusca.Rows[int.Parse(e.CommandArgument.ToString())]));
                Notificar("Registro alterado com sucesso!", TipoNotificacao.Sucesso);
            }catch(Exception ex)
            {
                InserirLog(ex);
                Notificar("Ocorreu um erro interno ao alterar a prioridade!", TipoNotificacao.Erro);
            }


        }
        protected Prioridade GerarPrioridade(GridViewRow linha)
        {
            return new Prioridade
            {
                PRI_Id = int.Parse(grvBusca.DataKeys[linha.RowIndex][0].ToString()),
                PRI_Codigo = ((HtmlInputText)linha.FindControl("txtCodigoEditar")).Value,
                PRI_Ordem = int.Parse(((HtmlInputGenericControl)linha.FindControl("txtOrdemEditar")).Value),
                PRI_CorTag = ((HtmlInputGenericControl)linha.FindControl("txtCorEditar")).Value,
                PRI_Descricao = ((HtmlInputText)linha.FindControl("txtDescricaoEditar")).Value,
            };
        }
        protected Prioridade GerarPrioridade()
        {
            return new Prioridade
            {
                PRI_Codigo = txtCodigo.Value,
                PRI_Ordem = int.Parse(txtOrdemPrioridade.Value),
                PRI_CorTag = txtCor.Value,
                PRI_Descricao = txtDescricaoPrioridade.Value
            };
        }

        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarGrid();
            }
            catch(Exception ex)
            {
                InserirLog(ex);
                Notificar("Ocorreu um erro interno ao pesquisar", TipoNotificacao.Erro);
            }
        }

        protected void btInserirNova_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCodigo.Value) || string.IsNullOrEmpty(txtDescricaoPrioridade.Value))
            {
                Notificar("Informe uma descrição e/ou código indentificador válido(s)",TipoNotificacao.Alerta);
                return;
            }
            try
            {
                controller.Inserir(GerarPrioridade());
                LimparCampos();
                CarregarGrid();
                Notificar("Registro inserido com sucesso!", TipoNotificacao.Sucesso);
            }
            catch (Exception ex)
            {
                InserirLog(ex);
                Notificar("Ocorreu um erro interno ao inserir a prioridade", TipoNotificacao.Erro);
            }
        }
        protected void LimparCampos()
        {
            txtCodigo.Value = string.Empty;
            txtCor.Value = "#ffffff";
            txtDescricaoPrioridade.Value = string.Empty;
            txtOrdemPrioridade.Value = string.Empty;
        }
    }
}