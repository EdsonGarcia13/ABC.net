$(document).ready(function () {
    $("#btn-search").on("click", function () {
        /*    $("#pageloader").show();*/

        var datos = {
            'Nombre': $("#Nombre").val(),
        };
        $.ajax({
            type: "POST",
            async: false,
            url: '../Home/ObtenerUsuarios',
            data: JSON.stringify(datos),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.length > 0) {
                    $('#datosUsurario').html("");
                    llenarTabla(data)
                }
            },
            error: function (data) {
                $("#pageloader").fadeOut();
            }
        });
    });
    $("body").on("click", "#editar", function () {
        $('#myModal').modal('toggle')
        $('#myModal').modal('show')
        var ValorIndiceArray = $(this).parents('tr').data('indice');
        $('#MPersonId').val($(this).closest('tr').find('td').eq(0).html());
        $('#MNombre').val($(this).closest('tr').find('td').eq(1).html());
        $('#MFirstName').val($(this).closest('tr').find('td').eq(2).html());
        $('#MLastName').val($(this).closest('tr').find('td').eq(3).html());
        $('#MFecha').val($(this).closest('tr').find('td').eq(4).html());
        $('#MEstado').val($(this).closest('tr').find('td').eq(5).html());
        $('#MMunicipio').val($(this).closest('tr').find('td').eq(6).html());
        $('#MCP').val($(this).closest('tr').find('td').eq(7).html());
        $('#MCorreo').val($(this).closest('tr').find('td').eq(8).html());
        $('#MDomicilio').val($(this).closest('tr').find('td').eq(9).html());
        $('#MColonia').val($(this).closest('tr').find('td').eq(10).html());
        $('#MTel').val($(this).closest('tr').find('td').eq(11).html());
        $('#identificador').val(ValorIndiceArray)
    });
    $("body").on("click", "#borrar", function () {
        var datos = {
            'PersonId': $(this).closest('tr').find('td').eq(0).html()
        }
        $(this).closest('tr').remove();
        $.ajax({
            type: "POST",
            async: false,
            url: '../Home/eliminarUsuarios',
            data: JSON.stringify(datos),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data.length > 0) {
                    $("#pageloader").fadeOut();
                    Swal.fire({
                        icon: 'success',
                        title: 'ok...',
                        text: 'se ha eliminado!'
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'No se elimino...',
                        text: 'Verifique que la informacion este correcta!'

                    });
                }
            }
        });
    });
    $("#btn-guardar").on("click", function () {
        var datos = {
            "PersonId": $("#MPersonId").val(),
            "Nombre": $("#MNombre").val(),
            "FirstName": $("#MFirstName").val(),
            "LastName": $("#MLastName").val(),
            "Fecha_de_Nacimiento": $("#MFecha").val(),
            "Estado": $("#MEstado").val(),
            "Municipio": $("#MMunicipio").val(),
            "CodigoPostal": $("#MCP").val(),
            "Correo": $("#MCorreo").val(),
            "Domicilio": $("#MDomicilio").val(),
            "Colonia": $("#MColonia").val(),
            "Telefono": $("#MTel").val(),
        }
        $.ajax({
            type: "POST",
            async: false,
            url: '../Home/editandoUsuarios',
            data: JSON.stringify(datos),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data.length > 0) {

                    $("#pageloader").fadeOut();
                    Swal.fire({
                        icon: 'success',
                        title: 'ok...',
                        text: 'se ha guardado correctamente!'
                    });
                    var identificador = $('#identificador').val();
                    llenarTablaMemoria(identificador);
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'No se a Guardado...',
                        text: 'Verifique que la informacion este correcta!'

                    });
                }
            }
        });
    });
    function llenarTabla(data) {

        if (data.length > 0) {
            $.each(data, function (index, element) {
                var opcion = "";
                opcion += '<tr data-indice="' + index + '">' +
                    '<td style="text-aling: center;">' + element.PersonId + '</td>' +
                    '<td style="text-aling: center; ">' + element.Nombre + '</td>' +
                    '<td style="text-aling: center; ">' + element.FirstName + '</td>' +
                    '<td style="text-aling: center; ">' + element.LastName + '</td>' +
                    '<td style="text-aling: center; ">' + element.Fecha_de_Nacimiento + '</td>' +
                    '<td style="text-aling: center; ">' + element.Estado + '</td>' +
                    '<td style="text-aling: center; ">' + element.Municipio + '</td>' +
                    '<td style="text-aling: center; ">' + element.CodigoPostal + '</td>' +
                    '<td style="text-aling: center; ">' + element.Correo + '</td>' +
                    '<td style="text-aling: center; ">' + element.Domicilio + '</td>' +
                    '<td style="text-aling: center; ">' + element.Colonia + '</td>' +
                    '<td style="text-aling: center; ">' + element.Telefono + '</td>' +
                    '<td style="text-aling: center; "><button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" id="editar">Editar</button ></td>' +
                    '<td style="text-aling: center; "><button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" id="borrar">borrar</button ></td>' +
                    '</tr>';
                $('#datosUsurario').append(opcion);
            });
        } else {
            opcion += '<tr><td></td><td></td><td><label>no se encontro informacion </label><hr></td><tr/>'
            $('#datosUsurario').append(opcion);
        }
    };
});