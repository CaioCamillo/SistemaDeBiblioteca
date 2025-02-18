$(document).ready(function () {
    var mensagemSucesso = "Livro Adicionado com sucesso!";
    var mensagemErro = "Erro ao Adicionar o Livro";

    if (mensagemSucesso) {
        $("#mensagem").text(mensagemSucesso).show();
        setTimeout(function () {
            $("#mensagem").fadeOut();
        }, 3000);
    }
    if (mensagemErro) {
        $("#mensagemErro").text(mensagemErro).show();
        setTimeout(function () {
            $("#mensagemErro").fadeOut();
        }, 3000);
    }
});

