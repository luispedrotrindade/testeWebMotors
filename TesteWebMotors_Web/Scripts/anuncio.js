var url = "http://localhost:56159/api/anuncio";

var urlWebMotors = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/";


$("#btnAddAnuncio").on("click", function () {

    $("#id").val("");
    $("#marca").val("");
    $("#modelo").val("");
    $("#versao").val("");
    $("#ano").val("");
    $("#quilometragem").val("");
    $("#observacao").val("");

    $(".formFields").show("slow");
    $(this).hide();
});


function salvarAnuncio() {
    var type = "POST";
    if (validarForm()) {
        var data = '{';
        if ($("#id").val()) {
            data += '"id":' + $("#id").val() + ',';
            type = "PUT";
            url += "/" + $("#id").val();
        }
        data += '"marca": "' + $("#marca option:selected").text() + '", "modelo": "' + $("#modelo option:selected").text() + '", "versao": "' + $("#versao option:selected").text() + '", "ano": ' + $("#ano").val() + ', "quilometragem": ' + $("#quilometragem").val() + ', "observacao": "' + $("#observacao").val() + '"}';

        $.ajax({
            headers: {
                "Content-Type": "application/json"
            },
            type: type,
            url: url,
            data: data,
            dataType: "json",
            success: function (data) {
                window.location.href = "http://localhost:44321/";
            },
            error: function (a, b, c) {
                listarAnuncios();
            }
        });


        $(".formFields").hide("slow");
        $("#btnAddAnuncio").show();
    }
    else {
        alert("Por favor preencher todos os campos.");
    }
}

function validarForm() {
    if ($("#marca").val() === ""
        || $("#modelo").val() === ""
        || $("#versao").val() === ""
        || $("#ano").val() === ""
        || $("#quilometragem").val() === ""
        || $("#observacao").val() === ""
    )
        return false;
    return true;
}

function showData(data) {
    $("#id").val(data.id);
    carregarMarcas(data.marca);
    setTimeout(function () {
        carregarModelos($("#marca").val(), data.modelo);
    }, 500);
    setTimeout(function () {
        carregarVersoes($("#modelo").val(), data.versao);
    }, 1000);
    $("#ano").val(data.ano);
    $("#quilometragem").val(data.quilometragem);
    $("#observacao").val(data.observacao);

    $("#formFields").show("slow");

}

function onEditAnuncio(id) {
    $.ajax({
        type: "GET",
        url: url + "/" + id,
        dataType: "json",
        success: function (data) {
            showData(data);

        },
        error: function (a, b, c) {

        }
    });
}

function onDeleteAnuncio(id) {
    var result = confirm("Tem certeza que deseja excluir esse registro?");
    if (result) {
        $.ajax({
            type: "DELETE",
            url: url + "/" + id,
            dataType: "json",
            success: function (data) {
                listarAnuncios();
            },
            error: function (a, b, c) {
                listarAnuncios();
            }
        });
    }
}


function carregarMarcas(marca) {
    $.ajax({
        method: "GET",
        url: urlWebMotors + "Make",
        dataType: "json",
        success: function (data) {
            var options = "<option value=''>Selecione</option>";

            for (i = 0; i < data.length; i++) {
                options += "<option value='" + data[i].ID + "'";
                if (marca && data[i].Name.indexOf(marca) > -1)
                    options += " selected ";
                options += ">" + data[i].Name + "</option>";
            }
            $("#marca").html(options);
        },
        error: function (a, b, c) {
        }
    });
}

function carregarModelos(makeId, modelo) {
    $.ajax({
        method: "GET",
        url: urlWebMotors + "Model?MakeID=" + makeId,
        dataType: "json",
        success: function (data) {
            var options = "<option value=''>Selecione</option>";

            for (i = 0; i < data.length; i++) {
                options += "<option value='" + data[i].ID + "'";
                if (modelo && data[i].Name.indexOf(modelo) > 0)
                    options += " selected ";
                options += ">" + data[i].Name + "</option>";
            }
            $("#modelo").html(options);
            $("#modelo").removeAttr("disabled");
        },
        error: function (a, b, c) {
        }
    });
}

function carregarVersoes(modelId, versao) {
    $.ajax({
        method: "GET",
        url: urlWebMotors + "Version?ModelID=" + modelId,
        dataType: "json",
        success: function (data) {
            var options = "<option value=''>Selecione</option>";

            for (i = 0; i < data.length; i++) {
                options += "<option value='" + data[i].ID + "'";
                if (versao && data[i].Name.indexOf(versao) > 0)
                    options += " selected ";
                options += ">" + data[i].Name + "</option>";
            }
            $("#versao").html(options);
            $("#versao").removeAttr("disabled");
        },
        error: function (a, b, c) {
        }
    });
}


function listarAnuncios() {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            var table = "<table>                 " +
                "   <tr>                         " +
                "       <th>ID</th>              " +
                "       <th>Marca</th>           " +
                "       <th>Modelo</th>          " +
                "       <th>Versão</th>          " +
                "       <th>Ano</th>             " +
                "       <th>Quilometragem</th>    " +
                "       <th>Observação</th>      " +
                "   </tr>  ";
            for (i = 0; i < data.length; i++) {
                table += "   <tr>                                                                                                                               " +
                    "       <td>" + data[i].id + "</td>                                                                                                           " +
                    "       <td>" + data[i].marca + " </td>                                                                                                        " +
                    "       <td>" + data[i].modelo + " </td>                                                                                                " +
                    "       <td>" + data[i].versao + " </td>                                                                                                 " +
                    "       <td>" + data[i].ano + " </td>                                                                                                 " +
                    "       <td>" + data[i].quilometragem + " </td>                                                                                                 " +
                    "       <td>" + data[i].observacao + " </td>                                                                                                 " +
                    "        <td><button type='button' id='btnEdit' onclick='javascript: onEditAnuncio(" + data[i].id + ")'><span>Edit</span></button></td>                " +
                    "        <td><button id='btnDelete' type='button' onclick='javascript: onDeleteAnuncio(" + data[i].id + ")'><span>Delete</span></button></td>          " +
                    "    </tr>                                                                                                                                  ";
            }
            table += "</table>                                                                                                                              ";

            $("#divTableAnuncios").html(table);
        },
        error: function (a, b, c) {

        }
    });
}


$(document).ready(function () {
    carregarMarcas();
    listarAnuncios();
});




$("#marca").on("change", function () {
    var value = $(this).val();
    carregarModelos(value);
});


$("#modelo").on("change", function () {
    var value = $(this).val();
    carregarVersoes(value);
});