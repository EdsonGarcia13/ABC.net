$(function () {
    obtenerpaginas()
});
function mostrar() {

}

function ocultar() {

}
var bandera = 0;
$("#menu").click(function ()
{
    switch (bandera)
    {
        case 0:
            $("#menu").empty();
            document.getElementById("sidebar").style.display = "block";                
            bandera = 1;
            break;
        case 1:
            $("#menu").empty();
            document.getElementById("sidebar").style.display = "none";
            bandera = 0;
            break;
    }
});
function obtenerpaginas() {
    var datos = {
        'Usuario_id': $("#usuario").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url:'../Configuracion/ObtenerPermisos',
        data: JSON.stringify(datos),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            if (data.length > 0) {
                data.forEach(function (element) {
                    var paginas = $('<div class="styledComponents__InnerContainer-dOhfsT bSQwLj"><a href="' + element.Url + '" ><img class="styledComponents__Icon-kEPbiv QgqSa" src="../' + element.Icono + '"  style="width: 40px; height: 40px;"/><span class="menu_title styledComponents__Label-jqsmfy djgFQu">' + element.Descripcion + '</span></a></div>')
                        
                    $('#menu2').append(paginas);
                    $("#pageloader").fadeOut();

                });
            } else {
                console.log('No se encontraron datos');
                $("#pageloader").fadeOut();
            }
        }
    });
}