<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teste.aspx.cs" Inherits="Clue.Views.Teste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../Utils/CSS/TesteStyleSheet1.css" />
    <script src="//code.jquery.com/jquery-2.1.4.min.js"></script>
    <script>
        $(document).ready(
            function () {
                $('.nav_bar').click(function () {

                    $('.navigation').toggleClass('visible');

                    $('body').toggleClass('opacity');

                });
            });

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <nav>

            <div class="navigation">

                <ul>

                    <li><a href="">Home</a></li>

                    <li><a href="">About</a></li>

                    <li><a href="">Contact</a></li>

                    <li><a href="#" tabindex="1">Services<span class="arrow-down"></span></a>

                        <ul class="dropdown">

                            <li><a href="">Services - 1</a></li>

                            <li><a href="">Services - 2</a></li>

                            <li><a href="">Services - 3</a></li>

                            <li><a href="">Services - 4</a></li>

                            <li><a href="">Services - 5</a></li>

                        </ul>

                    </li>

                    <li><a href="#" tabindex="1">Works<span class="arrow-down"></span></a>

                        <ul class="dropdown">

                            <li><a href="">Works - 1</a></li>

                            <li><a href="">Works - 2</a></li>

                            <li><a href="">Works - 3</a></li>

                            <li><a href="">Works - 4</a></li>

                            <li><a href="">Works - 5</a></li>

                        </ul>

                    </li>

                </ul>

            </div>

            <div class="nav_bg">

                <div class="nav_bar"><span></span><span></span><span></span></div>

            </div>

        </nav>

    </form>
</body>
</html>
