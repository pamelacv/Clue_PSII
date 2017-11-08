<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarPerfilUsuario.aspx.cs" Inherits="Clue.Views.EditarPerfilUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Utils/CSS/UtilsStyle.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="w3-container" runat="server">
            <div id="divEditarCadastroUsuario" class="box-login" runat="server">
                <h3 id="textoEditarCadastroUsuario" runat="server">Editar perfil</h3>
                <label>Nome:</label>
                <input type="text" id="textNome" runat="server" class="w3-input w3-border" placeholder="Nome" />
                <br />
                <label>Meus interesses:</label>
                <asp:TextBox type="text" id="textDescricao" runat="server" class="w3-input w3-border" Rows="3" Wrap="false" TextMode="MultiLine" placeholder="Meus interesses"></asp:TextBox>
                <br />
                <asp:Button ID="btnEscolherFoto" runat="server" class="box-container-botao-add"  Text="Escolher foto" OnClick="btnEscolherFoto_Click"></asp:Button>
                <br />
                <br />
                <asp:Button ID="btnEditar" runat="server" class="box-container-botao-add" Text="Salvar" OnClick="btnEditar_Click"></asp:Button>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
