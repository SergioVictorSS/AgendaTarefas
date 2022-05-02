<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmAgendaTarefasInicio.aspx.cs" Inherits="AgendaTarefaPaginas.AgendaTarefasInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="Content/bootstrap.min.css" rel="stylesheet"/>
        <link href="Content/notification.css" rel="stylesheet"/>
        <link href="Content/AgendaTarefas.css" rel="stylesheet"/>
        <script src="Scripts/jquery-3.3.1.min.js"></script>
        <script src="Scripts/bootstrap.min.js" ></script>
        <script src="Scripts/notification.js" ></script>
        <script>
            function abreJanela(caminho,w,h)
            {
                window.open( caminho, 'pagina', "width="+ w + ", height=" +h+ ", top=100, left=110, scrollbars=no ");
            }
            function NotificaAnterior(mensagem) {
                const notification = new Notification({
                    text: mensagem,
                    style:
                    {
                        background: '#21ff21',
                        color: '#ffffff',
                        transition: 'all 350ms linear',
                    },
                });
                $('#btPesquisar.Click()');
            }
        </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de Tarefas</title>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset class="fildsetPadrao">
            <legend class="legendPadrao">
                Tarefas
            </legend>
            <div class="filtro">
                <div class="filtroitem">
                    <label class="input-group-text" id="lblCodigo" for="txtCodigo">Código</label>
                    <input runat="server" id="txtCodigo" type="text" class="form-control" />
                </div>
                <div class="filtroitem">
                    <label class="input-group-text" id="lblDescricao" for="txtDescricaoTatrefa" style="width: 400px">Descrição</label>
                    <input runat="server" id="txtDescricaoTatrefa" type="text" class="form-control" />
                </div>
                <div class="filtroitem ">
                    <label class="input-group-text" id="lblDataEntrega" for="txtDataEntregaIni">Data de Entrega</label>
                    <div class="dataDupla">
                        <input runat="server" id="txtDataEntregaIni" type="date" class="form-control" />
                        <h5 class="textoSimples">à</h5>
                        <input runat="server" id="txtDataEntregaFim" type="date" class="form-control" />
                    </div>
                </div>
                <div class="filtroitem">
                    <label class="input-group-text" for="lstPrioridade">Prioridade</label>
                    <asp:DropDownList runat="server" class="custom-select" ID="lstPrioridade" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="filtroitem">
                    <label class="input-group-text" for="lstStatus">Status</label>
                    <asp:DropDownList runat="server" class="custom-select" ID="lstStatus" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
        </fieldset>
            <div class="botoes">
                <asp:Button runat="server" Text="Pesquisar" ID="btPesquisar" OnClick="btPesquisar_Click" CssClass="btn"/>
                <input type="button" value="Nova Tarefa" onclick="abreJanela('FrmEdicaoTarefa?IdTarefa=0','1100','184');" class="btn btn-primary"/> 
                <input type="button" value="Cadastro de prioridades" onclick="abreJanela('FrmPrioridade','870','500');" class="btn btn-primary"/>                  
            </div>

        <div class="grid">
            <asp:GridView AllowSorting="true" AutoGenerateColumns="false" runat="server" ID="grvBusca" CssClass="table table-bordered table-striped center" GridLines="None" ShowHeaderWhenEmpty="True" EmptyDataText="Não foram encontrados resultados" OnRowCommand="grvBusca_RowCommand" OnSorting="grvBusca_Sorting" DataKeyNames="TAR_Id">
                <Columns>
                    <asp:TemplateField SortExpression="prioridade" HeaderText="Prioridade" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="center" HeaderStyle-CssClass="centro">
                        <ItemTemplate>
                            <div style="width: 20px; height: 20px; border-radius: 50%; background-color: <%# Eval("CorExibicao")%>; margin: 10px;" title="<%# Eval("TarefaPrioridadeExtenso")%>"></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Código" DataField="TAR_Codigo" SortExpression="codigo" HeaderStyle-Width="10%" ItemStyle-CssClass="centro" HeaderStyle-CssClass="centro"/>
                    <asp:BoundField HeaderText="Nome" DataField="TAR_Descricao" SortExpression="descricao" HeaderStyle-Width="45%" ItemStyle-CssClass="centro" HeaderStyle-CssClass="centro"/> 
                    <asp:BoundField HeaderText="Prazo" DataField="TAR_DataHoraEntrega" DataFormatString="{0:d}"  SortExpression="prazo" HeaderStyle-Width="10%" ItemStyle-CssClass="centro" HeaderStyle-CssClass="centro"/>
                    <asp:BoundField HeaderText="Status" DataField="StatusExtenso"   SortExpression="status" HeaderStyle-Width="10%" ItemStyle-CssClass="centro" HeaderStyle-CssClass="centro"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="Concluir" Text="Concluir" CssClass="btn btn-success" Enabled='<%# !Eval("TAR_STA_IdStatus").Equals(4) %>' ToolTip='<%# Eval("TAR_STA_IdStatus").Equals(4) ? "Tarefa já concluída" : ""%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <input type="button" value="Editar" onclick="abreJanela('FrmEdicaoTarefa?IdTarefa=<%# Eval("TAR_Id")%>','1100','184');" class="btn btn-primary"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Button runat="server" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="Excluir" Text="Excluir" CssClass="btn btn-danger"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
