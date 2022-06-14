let usuario =
{
    campos: {
        email: $('#email'),
        senha: $('#senha')
    },
    variaveis: {
        url: window.Location.origin
    },
    funcoes: {
        logar: () => {
            let usuarioInformado = {
                Email: usuario.campos.email.val(),
                Senha: usuario.campos.senha.val(),
                //Email: $('#email').val(),
                //Senha: $('#senha').val(),
            }
            console.log(usuarioInformado)
            $.ajax({
                url: "/Login/ChecarLogin",
                async: false,
                type: 'post',
                data: {
                    usuarioInformado: usuarioInformado
                }
            })
        }
    }
}

/*$("#btn-login").click(usuario.funcoes.logar);*/

    //.done(function (res) {
    //    alert("Salvo com sucesso")
    //    if (res != 0)
    //        window.location.href = (window.location.href + "/" + res);
    //    else window.location.href = window.location.href;

    //})
    //.fail(function (err) {
    //    alert("Erro ao salvar Cliente");
    //});


//if (usuarioInformado.Email.indexOf("@") == -1) {
//    alert("Erro");
//} else {
//    alert("Email certo");
//}

//if (usuarioInformado.Senha) {
//}