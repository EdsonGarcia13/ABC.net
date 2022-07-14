var Datitos = []

$(document).ready(function () {
    $("#btn-capturar").on("click", function () {      
        $("#pageloader").show();
        setTimeout(function () {
            var counter = 0;
            var datos = {
                'Nombre': $("#Nombre").val(),
                'FirstName': $("#FirstName").val(),
                'LastName': $("#LastName").val(),
                'Fecha_de_Nacimiento': $("#Fecha_de_Nacimiento").val(),
                'Estado': $("#Estado").val(),
                'Municipio': $("#Municipio").val(),
                'CodigoPostal': $("#CodigoPostal").val(),
                'Correo': $("#Correo").val(),
                'Domicilio': $("#Domicilio").val(),
                'Colonia': $("#Colonia").val(),
                'Telefono': $("#Telefono").val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: '../Home/GuardarUsuarios',
                data: JSON.stringify(datos),
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.length > 0) {
                     $("#pageloader").fadeOut();
                    Swal.fire({
                        icon: 'success',
                        title: 'ok...',
                        text: 'se ha capturado!'
                    });
                        $('#form').html('');
                   }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'No se elimino...',
                            text: 'Verifique que la informacion este correcta!'

                        });
                    }                  
                },
                error: function (data) {
                    $("#pageloader").fadeOut();
                }
            });
         

        }, 200)


        
    });
    
  
});


function limpiar(data) {
    $(".form-control").val("");
    $(".form-control").html("");
    $('#datosUsurario').html("");
    $("#datosUsurario").val("");

};
function llenarTabla(data) {
    $("#pageloader").fadeIn();
    $('#datosVentas').empty();
    if (data.length > 0) {
        $.each(data, function (index, element) {
            var opcion = "";
            if (index <= paginacion2) {
                   
                opcion += '<tr>' +
                    '<td style="text-aling: center; ">' + element.PersonId + '</td>' +
                    '<td style="text-aling: center; ">' + element.Nombre + '</td>' +
                    '<td style="text-aling: center; ">' + element.FirstName + '</td>' +
                    '<td style="text-aling: center; ">' + element.LastName + '</td>' +
                    '<td style="text-aling: center; ">' + element.Fecha_de_Nacimiento + '</td>' +
                    '<td style="text-aling: center; ">' + element.Estado + '</td>' +
                    '<td style="text-aling: center; ">' + element.Municipio + '</td>' +
                    '<td style="text-aling: center; ">' + element.CP + '</td>' +
                    '<td style="text-aling: center; ">' + element.Correo + '</td>' +
                    '<td style="text-aling: center; ">' + element.Domicilio + '</td>' +
                    '<td style="text-aling: center; ">' + element.Colonia + '</td>' +
                    '<td style="text-aling: center; ">' + element.Telefono + '</td>' +                 
                    '</tr>';
            }
            $('#datosVentas').append(opcion);

        });
    } else {
        opcion += '<tr><td></td><td></td><td><label>no se encontro informacion </label><hr></td><tr/>'
        $('#datosVentas').append(opcion);
    }
    $("#pageloader").fadeOut();
}

function llenarTablaDescarga(data) {
    var opcion = "";
    $('#DescargaCartera').empty();
    if (data.length > 0) {
        $.each(data, function (index, element) {

            var Fecha = convertirFecha(element.Fecha)
            var FechaCartera = convertirFecha(element.FechaCartera)
            opcion += '<tr>' +
                '<td style="text-aling: center; ">' + element.PersonId + '</td>' +
                '<td style="text-aling: center; ">' + element.Nombre + '</td>' +
                '<td style="text-aling: center; ">' + element.FirstName + '</td>' +
                '<td style="text-aling: center; ">' + element.LastName + '</td>' +
                '<td style="text-aling: center; ">' + element.Fecha_de_Nacimiento + '</td>' +
                '<td style="text-aling: center; ">' + element.Estado + '</td>' +
                '<td style="text-aling: center; ">' + element.Municipio + '</td>' +
                '<td style="text-aling: center; ">' + element.CP + '</td>' +
                '<td style="text-aling: center; ">' + element.Correo + '</td>' +
                '<td style="text-aling: center; ">' + element.Domicilio + '</td>' +
                '<td style="text-aling: center; ">' + element.Colonia + '</td>' +
                '<td style="text-aling: center; ">' + element.Telefono + '</td>' +
                '</tr>';
        });
        $('#DescargaCartera').append(opcion);

    }
}
