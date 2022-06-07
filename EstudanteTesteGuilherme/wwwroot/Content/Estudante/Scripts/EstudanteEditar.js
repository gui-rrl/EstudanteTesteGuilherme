let estudanteEditar =
{
    campos: {
        identificador: $('#identificador'),
        nome: $('#nome'),
        curso: $('#curso'),
        dataNascimento: $('#dataNascimento'),
        status: $('#status')
    },
    variaveis: {
        url: window.location.origin
    },
    funcoes: {
        salvar: () => {
            var estudante = {
                Identificador: estudanteEditar.campos.identificador.val(),
                Nome: estudanteEditar.campos.nome.val(),
                Curso: estudanteEditar.campos.curso.val(),
                DataNascimento: estudanteEditar.campos.dataNascimento.val(),
                /*Status: Boolean(estudanteEditar.campos.status.val())*/
                Status: estudanteEditar.campos.status.val() == 1 ? true : false
            }
            console.log(estudante)
            $.ajax({
                url: estudanteEditar.variaveis.url + "/Estudante/EstudanteEditar_Alterar",
                async: false,
                type: 'POST',
                data: {
                    estudante: estudante
                },
            })
                .done(function (res) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Cadastro salvo com sucesso',
                        showConfirmButton: false,
                        timer: 80000
                    })
                    window.location.href = `${estudanteEditar.variaveis.url}/Estudante/Estudante/`;
                })

                .fail(function (err) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Erro',
                        text: 'Erro ao salvar o cadastro',
                    })
                });
        },
    }
}