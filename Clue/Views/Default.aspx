<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clue.Views.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>
    <title>Clue</title>
    <%--    <link rel="shortcut icon" href="../utils/image/favicon.ico" />--%>

    <script src="../utils/JS/jquery-3.2.0.min.js"></script>
    <script src="../utils/JS/Utils.js"></script>

    <link rel="stylesheet" href="../Utils/CSS/UtilsStyle.css" />
</head>
<body>
    <div class="fillLayout">
        <form id="form1" runat="server">
            <div id="banner">
                <div class="banner-name">Clue</div>
                <div class="banner-content"></div>
            </div>

            <div id="containerMenuBar" class="container-menu-bar" runat="server">
                <ul runat="server">
                    <li>
                        <asp:LinkButton CssClass="link" runat="server" OnClick="Principal_Click">Início</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton CssClass="link" runat="server" OnClick="Perfil_Click">Perfil</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton CssClass="link" runat="server" OnClick="Login_Click">Login</asp:LinkButton>
                    </li>
                </ul>
            </div>

            <div id="pagina_geral" runat="server">
                <iframe runat="server" id="frame_paginas"></iframe>
            </div>
        </form>
    </div>
</body>
</html>
