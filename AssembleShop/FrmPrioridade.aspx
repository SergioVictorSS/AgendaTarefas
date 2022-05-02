<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPrioridade.aspx.cs" Inherits="AgendaTarefaPaginas.FrmPrioridade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="Content/bootstrap.min.css" rel="stylesheet"/>
        <link href="Content/notification.css" rel="stylesheet"/>
        <link href="Content/AgendaTarefas.css" rel="stylesheet"/>
        <script src="Scripts/jquery-3.3.1.min.js"></script>
        <script src="Scripts/bootstrap.min.js" ></script>
        <script src="Scripts/notification.js" ></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


        <fieldset class="fildsetPadrao">
            <legend class="legendPadrao">Busca/Inclusão</legend>
            <div class="filtro">

                <div class="filtroitem">
                    <label class="input-group-text" id="lblCodigo" for="txtCodigo">Código</label>
                    <input runat="server" id="txtCodigo" type="text" class="form-control" style="width:150px" maxlength="50"/>
                </div>
                <div class="filtroitem">
                    <label class="input-group-text" id="lblDescricaoPrioridade" for="txtDescricaoPrioridade">Descrição</label>
                    <input runat="server" id="txtDescricaoPrioridade" type="text" class="form-control" style="width:400px" maxlength="100"/>

                </div>
                <div class="filtroitem">
                    <label class="input-group-text" id="lblOrdemPrioridade" for="txtOrdemPrioridade">Ordem </label>
                    <input runat="server" id="txtOrdemPrioridade" type="Number" class="form-control" style="width:100px" value="0"/>            
                </div>
                <div class="filtroitem filtroCor">
                    <label class="input-group-text" id="lblCor" for="txtCor">Cor</label>
                    <input type="color" runat="server" id="txtCor"  style="width:100px"/>
                </div>

            </div>

        </fieldset>
            <div class="botoes">
                <asp:Button runat="server" Text="Pesquisar" ID="btPesquisar" OnClick="btPesquisar_Click" CssClass="btn"/>
                <asp:Button runat="server" Text="Inserir" ID="btInserirNova" OnClick="btInserirNova_Click" CssClass="btn btn-primary"/>      
            </div>
     
        <div class="grid">
            <asp:GridView  AutoGenerateColumns="false" runat="server" ID="grvBusca" CssClass="table table-bordered table-striped center" GridLines="None" ShowHeaderWhenEmpty="True" EmptyDataText="Não foram encontrados resultados" OnRowCommand="grvBusca_RowCommand" DataKeyNames="PRI_Id">
                <Columns>
                    <asp:TemplateField HeaderText="Cor" HeaderStyle-Width="15%">
                        <ItemTemplate>
                            <input runat="server" type="color" id="txtCorEditar" value='<%# Eval("PRI_CorTag")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Código" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <input runat="server" type="text"  id="txtCodigoEditar" value='<%# Eval("PRI_Codigo")%>' style="width:150px"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descrição"  HeaderStyle-Width="45%">
                        <ItemTemplate>
                            <input runat="server" type="text" id="txtDescricaoEditar" value='<%# Eval("PRI_Descricao")%>' style="width:300px"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ordem" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <input runat="server" type="number" id="txtOrdemEditar" value='<%# Eval("PRI_Ordem")%>' style="width:75px"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button  runat="server" Text="Alterar"  CommandArgument='<%#((GridViewRow)Container).RowIndex  %>' CommandName="Editar" CssClass="btn btn-primary"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
