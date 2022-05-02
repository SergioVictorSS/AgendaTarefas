using System.Linq;
using System.Web.UI.WebControls;
namespace AgendaTarefaPaginas
{
	public class PaginaBase : System.Web.UI.Page
    {
        public void InserirLog(System.Exception exception)
        {
            AgendaTarefas.LogController.InserirLog(exception);
        }
        public void ExecutaFuncaoJs(string funcao)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "OK", funcao, true);
        }
        public void PreencheDropDownList(DropDownList dropDownList,string procedure, int valorPadrao,bool incluirSelecione,string textoSelecione)
        {
            if (incluirSelecione)
            {
                dropDownList.Items.Add(new ListItem() { Text = textoSelecione, Value = "0", Selected = valorPadrao == 0 });
            }
           var items = SDBC.Instance.Database.SqlQuery<ItemLista>("{0}", new object[] { procedure }).ToList();
           foreach(var item in items)
            {
                dropDownList.Items.Add(new ListItem() { Text = item.Texto, Value = item.Valor.ToString(), Selected = valorPadrao == item.Valor });
            }
        }
        public void Notificar(string texto, TipoNotificacao tipoNotificacao)
        {

            var script = @"  const notification = new Notification({
                            text: '"+texto+@"',
                            style:
                                {
                                background: '"+ RetornaCorNotificacao(tipoNotificacao) + @"',
                                color: '#ffffff',
                                transition: 'all 350ms linear',            
                            },
}                           );";
            ExecutaFuncaoJs(script);
        }
        public int RequestInt(string chave)
        {
            try
            {
               return int.Parse(Request.QueryString.Get(chave));
            }
            catch
            {
                return 0;
            }
        }
        public string RetornaCorNotificacao(TipoNotificacao tipoNotificacao)
        {
            switch (tipoNotificacao)
            {
                case TipoNotificacao.Erro:
                    return "#f55a42";
                case TipoNotificacao.Sucesso:
                    return "#02ad0a";
                case TipoNotificacao.Alerta:
                    return "#f0b105";
            }
            return "";
        }
        public void FecharJanela(bool atualizaAnterior, string mensagem)
        {
            Session["MensagemNotificacao"] = mensagem;
            ExecutaFuncaoJs("window.opener.$('#btPesquisar').click();window.close();");
        }
        struct ItemLista
        {
            public int Valor { get; set; }
            public string Texto { get; set; }
        }
        public enum TipoNotificacao
        {
            Erro,
            Sucesso,
            Alerta
        }
    }

}