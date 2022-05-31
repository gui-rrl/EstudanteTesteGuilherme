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
                Status: estudanteEditar.campos.status.val()
            }
            $.ajax({
                url: estudanteEditar.variaveis.url + "/Estudante/EstudanteEditar_Alterar",
                async: false,
                type: 'POST',
                data: {
                    estudante: estudante
                },
            })
        },
    }
}