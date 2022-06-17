let usuario =
{
    campos: {
        email: $('#email'),
        senha: $('#senha')
    },
    variaveis: {
        url: window.Location.origin,
        urlRedirecionamento: "/Estudante/Estudante/"
    },
    funcoes: {
        logar: () => {
            let usuarioInformado = {
                Email: usuario.campos.email.val(),
                Senha: usuario.campos.senha.val(),
            }
            console.log(usuarioInformado)
            $.ajax({
                url: "/Login/Usuario_ChecarLogin",
                type: 'post',
                data: {
                    usuarioInformado: usuarioInformado
                },
                success: function ({ value }) {
                    if (value.codigo == 1) {
                        window.location = usuario.variaveis.urlRedirecionamento
                    }

                    else {
                        alert("Usuario invalido");
                        window.location.href = window.location.href;
                    }
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