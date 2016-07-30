$(document).ready(function () {
    EsconderObras();

    /*$("#btnPesquisarObrasCadastradas").on('click', MostrarObras);*/
});

function EsconderObras() {
    $("#resultadoExibicaoObras").hide();
}


function MostrarObras() {
    $("#resultadoExibicaoObras").show();
}

/*____________________________________________________________________*/

$(document).ready( //quando a página carregar..
    function () {  //faça..
        //criar o evento do campo de busca..
        $("#btnPesquisarObrasCadastradas").click(
            function () {
                //ajax...
                $.ajax(
                    {
                        type: "POST",
                        url: "/Obra/ExibirObras",
                        success: function () {
                            MostrarObras();
                        },
                        error: function (e) {
                            alert(e.status);
                        }
                    }
                );
            }
        );

        //criar um evento no botão de cadastro..
        $("#btncadastro").click( //quando clicar no botão..
            function () { //faça..

                //resgatar os dados do formulário..
                //JSON -> JavaScript Object Notation
                var model = {
                    Nome: $("#nome").val(),
                    Email: $("#email").val(),
                    Logradouro: $("#logradouro").val(),
                    Cidade: $("#cidade").val(),
                    Estado: $("#estado").val(),
                    Cep: $("#cep").val()
                };

                //enviar para o controller...
                $.ajax(
                    {
                        type: "POST", //chamada ao servidor
                        url: "/Cliente/CadastrarCliente", //método
                        data: model, //envio dos dados -> json
                        success: function () { //resposta com sucesso..

                        },
                        error: function (e) { //resposta com erro..
                            $("#mensagem").html(e.status);
                        }
                    }
                );
            }
        );
    }
);