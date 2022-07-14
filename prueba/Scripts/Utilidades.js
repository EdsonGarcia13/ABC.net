function showLoading2() {

    var html = "<div align='center' style='padding:10px 10px 0 10px;'><img src='../Imagenes/loading.gif' /></div>";
    html += "<div style='padding:10px; text-align:center;'>Cargando...</div>";

    var msg = $("<div id='div_loading'/>").html(html).
        css({
            "position": "absolute", "top": "43%", "left": "45%", "width": "10%", "height": "14%",
            "z-index": 99999, "border": "1px solid",
            "border-radius": "4px", "background-color": "white"
        })
        .appendTo("body");

    $("<div id='blockMessage'></div>").css({
        "position": "absolute", "top": 0, "width": "100%", "height": "100%",
        "background-color": "white", "display": "inline", "opacity": ".6",
        "filter": "alpha(opacity = .6)", "text-align": "center"
        , "z-index": "99"
    }).appendTo("body");

}

function RemoveLoading() {
    $('#div_loading').remove();
    $('#blockMessage').remove();
}