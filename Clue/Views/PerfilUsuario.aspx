<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="Clue.Views.PerfilUsuario" %>

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
        <div id="divInformacoesGerais" style="width: 100%; overflow:hidden">
            <div id="divImagemPerfil" class="box-container">
                <img id="imgPerfil" runat="server" class="box-container-img" />
            </div>

            <div id="divInfusuario" class="box-container">
                <span id="nomeUsuario" runat="server" style="font-size: 34px"></span>

                <div class="box-container-botao">
                    <asp:Button class="box-container-botao-add" ID="btnEditar" runat="server" Text="Editar perfil" OnClick="btnEditar_Click"></asp:Button>
                </div>

                <div id="divSeguidores" class="box-container-descricao">
                    <span id="legendaSeguidores" runat="server">Seguidores</span>
                    <a id="linkSeguidores" runat="server" href="">230</a>
                </div>

                <div id="divSeguindo" class="box-container-descricao">
                    <span id="legendaSeguindo" runat="server">Seguidores</span>
                    <a id="linkSeguindo" runat="server" href="">230</a>
                </div>

                <div id="divInteressesUsuario" class="box-container-descricao">
                    <span id="legendaInteressesUsuario" runat="server" class="box-container-descricao-titulo">Meus interesses:</span>
                    <p id="txtInteressesUsuario" runat="server" class="box-container-descricao-texto">Teste Teste Teste Teste Teste TesteTesteTesteTeste TesteTesteTeste Teste Teste TesteTesteTesteTeste</p>
                </div>
            </div>
        </div>

        <div id="listas" class="container-listas" runat="server">
            <ul runat="server">
                <li>
                    <asp:LinkButton ID="btnListaFavoritos" runat="server" OnClick="btnListaFavoritos_Click">Lista de favoritos</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="btnListaIndicacoes" runat="server" OnClick="btnListaIndicacoes_Click">Lista de filmes/séries que indico</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="btnListaSugestoes" runat="server" OnClick="btnListaSugestoes_Click">Lista de filmes/séries que quero sugestões</asp:LinkButton>
                </li>
            </ul>
        </div>

        <div id="pagina_geral" runat="server">
            <iframe runat="server" id="frame_paginas"></iframe>
        </div>
    </form>
</body>
</html>
