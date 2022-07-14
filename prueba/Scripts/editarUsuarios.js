$(document).ready(function () {
    $("#btn-delete").on("click", function () {
        $(".form-control").val("");
        $("#datosUsuario").val("");
        $("#tablaContenido").hide();
    });
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
});


function llenarTabla(data) {

    if (data.length > 0) {
        $.each(data, function (index, element) {
            var opcion = "";
            opcion += '<tr>' +
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
                '<td style="text-aling: center; "><button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">Editar</button ></td>' +
                '</tr>';

            $('#datosUsurario').append(opcion);

        });
    } else {
        opcion += '<tr><td></td><td></td><td><label>no se encontro informacion </label><hr></td><tr/>'
        $('#datosUsurario').append(opcion);
    }
}
