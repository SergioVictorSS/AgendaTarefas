<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEdicaoTarefa.aspx.cs" Inherits="AgendaTarefaPaginas.FrmEdicaoTarefa" %>

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
    <title>Edição de Tarefa</title>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset class="fildsetPadrao">
            <legend class="legendPadrao">Dados</legend>
            <div class="filtro">
                <div class="filtroitem">
                    <label class="input-group-text">Código</label>
                    <input runat="server" id="txtCodigo" max-length="50" type="text" class="form-control" required="required" />
                </div>
                <div class="filtroitem">
                    <label class="input-group-text" id="lblDescricaoTarefa" for="txtDescricaoTarefa">Descrição</label>
                    <input runat="server" id="txtDescricaoTatrefa" type="text" class="form-control" max-length="100" required="required" style="width:350px"/>
                </div>
                <div class="filtroitem">
                    <label class="input-group-text" id="lblDataEntrega">Data de Entrega</label>
                    <input runat="server" id="txtDataEntregaIni" type="date" class="form-control" required="required" />
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
                <asp:Button runat="server" Text="Gravar" ID="btGravar" OnClick="btGravar_Click" CssClass="btn btn-primary"/>
                <asp:TextBox Visible="false" runat="server" ID="txtIdTarefa"></asp:TextBox>
        </div>

    </form>
</body>
</html>
