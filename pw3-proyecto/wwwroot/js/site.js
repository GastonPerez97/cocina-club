$(document).on("click", "#btnModal", function () {
    var evento = $(this).data('even');
    var comensal = $(this).data('comen');

    $("#eventoIdjs").val(evento);
    $("#comensalIdJs").val(comensal);
});

function CancelEvent(eventoParm, evnt) {

    var url = "https://localhost:44381/api/Event/" + eventoParm;
    $.ajax({
        url: url,
        type: "PUT",
        data: evnt,
        contentType: "application/json",
        success: function (data) {

            $("#error").text("Evento cancelado");

        },
        error: function (msg) {
            $("#error").text("Error al cancelar");
        }
    });

    $("#btnCancelar").on("click", function () {

        var evento = new Evento();
        evento.IdEvento = $("#IdEvento").val();
        evento.Nombre = $("#Nombre").val();
        evento.Fecha = $("#Fecha").val();
        evento.CantidadComensales = $("#CantidadComensales").val();
        evento.Ubicacion = $("#Ubicacion").val();
        evento.Foto = $("#Foto").val();
        evento.Precio = $("#Precio").val();
        evento.Estado = $("#Estado").val();

        CancelEvent(evento.IdEvento, JSON.stringify(evento));

    });

}
