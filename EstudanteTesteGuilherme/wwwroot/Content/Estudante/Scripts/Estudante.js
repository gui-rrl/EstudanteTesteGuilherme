let estudante =
{
    campos: {
        identificador: $('#identificador'),
        nome: $('#nome'),
        curso: $('#curso'),
        status: $('#status'),
        tabela: $('#tabelaEstudante')
    },
    variaveis: {
        url: window.Location.origin
    },
    funcoes: {
        consultar: () => {
            var filtro = {
                Identificador: estudante.campos.identificador.val(),
                Nome: estudante.campos.nome.val(),
                Curso: estudante.campos.curso.val(),
                Status: estudante.campos.status.val()
            }

            $("#tabelaEstudante").DataTable({
                /*'sDom': 't',*/
                "dom": '<"top">rt<"bottom"ip><"clear">',
                "destroy": true,
                "responsive": true,
                "ajax": {
                    "url": "/Estudante/Estudante_SelecionarFiltro",
                    "type": "POST",
                    "dataSrc": "value",
                    "data": { filtro: filtro }
                },
                "columns": [
                    { "data": "identificador" },
                    { "data": "nome" },
                    { "data": "curso" },
                    {
                        "data": "status",
                        "render": (data) => {
                            if (data == true) {
                                return "<p class='text-success'><strong>Ativo</strong></p>"
                            }
                            else {
                                return "<p class='text-danger'><strong>Inativo</strong></p>"
                            }
                        }
                    },
                    {
                        "data": "identificador",
                        "render": (identificador) => {
                            return "<a href='/Estudante/EstudanteEditar/" + identificador + "' class='btn btn-warning'>Editar</a>"
                        }
                    }
                ]
            })
        },
        init: function () {
            estudante.funcoes.consultar();
        }
    }
}

$(document).ready(function () {
    estudante.funcoes.init();
})
