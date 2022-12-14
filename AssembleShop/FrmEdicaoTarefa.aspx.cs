using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AgendaTarefas;

namespace AgendaTarefaPaginas
{
    public partial class FrmEdicaoTarefa : PaginaBase<Tarefa>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            InicializarController(new TarefaController(SDBC.Instance));

            if (!IsPostBack)
            {   
                txtIdTarefa.Text = RequestInt("IdTarefa").ToString();
                if ("0".Equals(txtIdTarefa.Text))
                {
                    PreencheDropDownList(lstPrioridade, "PRIORIDADE_CONSULTAR_LIST_PREENCHIMENTO", 0, true, "Selecione");
                    PreencheDropDownList(lstStatus, "STATUS_CONSULTAR_LIST_PREENCHIMENTO", 1, false, "");
                }
                else
                    BuscarDados();
            }

        }
        protected void BuscarDados()
        {
            var tarefa = controller.BuscarId(int.Parse(txtIdTarefa.Text));
            txtCodigo.Value = tarefa.TAR_Codigo;
            txtDescricaoTatrefa.Value = tarefa.TAR_Descricao;
            txtDataEntregaIni.Value = tarefa.TAR_DataHoraEntrega.ToString("yyyy-MM-dd");
            PreencheDropDownList(lstPrioridade, "PRIORIDADE_CONSULTAR_LIST_PREENCHIMENTO", tarefa.TAR_PRI_IdPrioridade, true, "Selecione");
            PreencheDropDownList(lstStatus, "STATUS_CONSULTAR_LIST_PREENCHIMENTO", tarefa.TAR_STA_IdStatus, false, "");

        }

        protected void btGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if ("0".Equals(lstPrioridade.SelectedValue))
                {
                    Notificar("Selecione uma prioridade!", TipoNotificacao.Alerta);
                    return;
                }
                var tarefa = GerarTarefa();
                if (tarefa.TAR_Id > 0)
                {
                    controller.Alterar(tarefa);
                    FecharJanela(true, "Tarefa alterada com sucesso!");
                }
                else
                {
                    controller.Inserir(tarefa);
                    FecharJanela(true, "Tarefa incluída com sucesso!");
                }
            }
            catch (FormatException)
            {
                Notificar("Preencha a data corretamente!",TipoNotificacao.Alerta);
            }
            catch(Exception ex)
            {
                InserirLog(ex);
                Notificar("Erro interno ao tentar gravar!", TipoNotificacao.Erro);

            }
        }

        protected Tarefa GerarTarefa()
        {
            return new Tarefa
            {
                TAR_Id = int.Parse(txtIdTarefa.Text),
                TAR_Codigo = txtCodigo.Value,
                TAR_DataHoraCadastro = DateTime.Now,
                TAR_Descricao = txtDescricaoTatrefa.Value,
                TAR_DataHoraEntrega = DateTime.Parse(txtDataEntregaIni.Value),
                TAR_PRI_IdPrioridade = int.Parse(lstPrioridade.SelectedValue),
                TAR_STA_IdStatus = int.Parse(lstStatus.SelectedValue)
            };
        }
        
    }
}