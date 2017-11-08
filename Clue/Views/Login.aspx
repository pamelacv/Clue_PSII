<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Clue.Views.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Utils/CSS/UtilsStyle.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <script src="../utils/JS/jquery-3.2.0.min.js"></script>
</head>
<body>
        <form id="formLogin" runat="server">
            <div class="w3-container" runat="server">
                <div id="divLoginUsuario" class="box-login" runat="server">
                    <h3 id="textoLoginUsuario" runat="server">Login</h3>
                    <label>E-mail:</label>
                    <input class="w3-input w3-border" type="email" id="textEmail" runat="server" placeholder="E-mail">
                    <br>
                    <label>Senha:</label>
                    <input class="w3-input w3-border" type="password" id="passwordSenha" runat="server" placeholder="Senha">
                    <br>
                    <asp:Button class="box-container-botao-add" ID="bEntrar" runat="server" Text="Entrar" OnClick="bEntrar_Click"></asp:Button>
                </div>
                <div id="divCadastroUsuario" class="box-login" runat="server">
                    <h3 id="textoCadastroUsuario" runat="server">Cadastrar-se</h3>
                    <label>Nome:</label>
                    <input class="w3-input w3-border" type="text" id="textNomeCadastro" runat="server" placeholder="Nome">
                    <br>
                    <label>E-mail:</label>
                    <input class="w3-input w3-border" type="email" id="textEmailCadastro" runat="server" placeholder="E-mail">
                    <br>
                    <label>Senha:</label>
                    <input class="w3-input w3-border" type="password" id="passwordSenhaCadastro" runat="server" placeholder="Senha">
                    <br>
                    <asp:Button class="box-container-botao-add" ID="bCadastrar" runat="server" Text="Cadastrar" OnClick="bCadastrar_Click"></asp:Button>
                    <br>
                </div>
            </div>
        </form>
</body>
</html>

