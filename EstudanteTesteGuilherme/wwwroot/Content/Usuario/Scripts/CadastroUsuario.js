let cadastroUsuario =
{
    campos: {
        identificador: $('#identificador'),
        email: $('#email'),
        senha: $('#senha')
    },

    variaveis: {
        url: window.Location.origin
    },

    funcoes: {
        salvar: () => {
            var usuario = {
                Identificador: cadastroUsuario.campos.identificador.val(),
                Email: cadastroUsuario.campos.email.val(),
                Senha: cadastroUsuario.campos.senha.val()
            }
            console.log(usuario)
            $.ajax({
                url: "/Login/Usuario_InserirAtualizar",
                asyn: false,
                type: 'POST',
                data: {
                    usuario: usuario
                }
            })
                .done(function (res) {
                    alert("Usuario cadastrado com sucesso")
                    window.location.href = '/Login/Login/';
                })

                .fail(function (res) {
                    alert("Erro ao cadastrar usuario")
                    window.location.href = '/Login/Login/';
            })
        }
    }
}