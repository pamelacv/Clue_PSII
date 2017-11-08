<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaFavoritos.aspx.cs" Inherits="Clue.Views.ListaFavoritos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>
    <title></title>
    <script src="../utils/JS/jquery-3.2.0.min.js"></script>
    <script src="../utils/JS/Utils.js"></script>
    <link rel="stylesheet" href="../Utils/CSS/UtilsStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="menuBar">
            <asp:Button ID="btnAdicionar" Text="Adicionar" runat="server" OnClick="btnAdicionar_Click" />
        </div>

        <div id="listaFavoritos">
            <%--OnRowCommand="grdDados_RowCommand"--%>
            <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="nome" HeaderText="Filme/Série" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnExcluir" runat="server" CommandName="Excluir" Text="Excluir"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
