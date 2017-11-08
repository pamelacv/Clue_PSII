tempPart = tamanhosPartes(8);

var resizeId;
$(window).resize(function () {
    clearTimeout(resizeId);
    resizeId = setTimeout(doneResizing, 20);
});

function doneResizing() {
    tempPart = tamanhosPartes(8);

    document.getElementsByTagName('body')[0].style.width = tempPart.width * 8 + 'px';
    document.getElementsByTagName('body')[0].style.height = tempPart.height * 8 + 'px';

    document.getElementById('banner').style.width = tempPart.width * 8 + 'px';
    document.getElementById('banner').style.height = tempPart.height + 'px';

    document.getElementById('containerMenuBar').style.width = tempPart.width * 8 + 'px';
    document.getElementById('containerMenuBar').style.height = tempPart.height  + 'px';

    document.getElementById('pagina_geral').style.width = tempPart.width * 8 + 'px';
    document.getElementById('pagina_geral').style.height = ((tempPart.height * 8) - 60) + 'px';
}

window.onload = function () {
    tempPart = tamanhosPartes(8);

    document.getElementsByTagName('body')[0].style.width = tempPart.width * 8 + 'px';
    document.getElementsByTagName('body')[0].style.height = tempPart.height * 8 + 'px';

    document.getElementById('banner').style.width = tempPart.width * 8 + 'px';
    document.getElementById('banner').style.height = tempPart.height + 'px';

    document.getElementById('containerMenuBar').style.width = tempPart.width * 8 + 'px';
    document.getElementById('containerMenuBar').style.height = tempPart.height + 'px';

    document.getElementById('pagina_geral').style.width = tempPart.width * 8 + 'px';
    document.getElementById('pagina_geral').style.height = ((tempPart.height * 8) - 60) + 'px';
}

function acessarPagina(pagina) {
    var obj = document.getElementById('obj_pagina');
    obj.data = pagina;
}

function tamanhosPartes(partes) {
    return {
        width: window.innerWidth / partes,
        height: window.innerHeight / partes
    }
}

//Funcçoes do menu "Meu Pedido"
$(document).ready(function () {
    var _itens;
    //Leitura dos dados do JSOn    
    $(function () {

        $.getJSON("https://api.myjson.com/bins/nvnh7", function (data) {
            _itens = data.itens;
            setPedido(data.pedidos[0]);
            setItens(data.itens);
            totais_pedido();
        });

        //Leitura dos dados do pedido Fixo do JSOn
        function setPedido(pedido) {
            $('#situacao')[0].innerHTML = pedido.Situacao;
            $('#pedido')[0].innerHTML = pedido.Pedido;
            $('#nome')[0].innerHTML = pedido.Nome;
        };

        //Calculo do totais de itens do pedido no Json
        function totais_pedido() {
            var total = 0;
            for (var k in _itens) {
                var preco = _itens[k].Preco;
                var qtd = _itens[k].Quantidade;
                var _s = preco.replace(",", ".");
                var _d = parseFloat(_s);
                total += _d * qtd;
            }
            $('#total')[0].innerHTML = "R$ " + total;
        };

        //Leitura dos dados do itens do dinamico do JSOn
        function setItens(itens) {
            var $bodyTable = $('#table-itens')[0];
            itens.forEach(function (item) {
                var $tr = document.createElement('TR');
                for (var key in item) {
                    var $td = document.createElement('TD');
                    $td.innerHTML = item[key];
                    $tr.appendChild($td);
                }
                $bodyTable.appendChild($tr);
            }, this);
        };

    });
});