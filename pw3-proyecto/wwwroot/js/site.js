$(document).on("click", "#btnModal", function () {
    var evento = $(this).data('even');
    var comensal = $(this).data('comen');

    $("#eventoIdjs").val(evento);
    $("#comensalIdJs").val(comensal);
});

function CancelEvent(evento, evn) {

    var url = "api/Event/" + evento;
    $.ajax({
        url: url,
        type: "PUT",
        data: evn,
        contentType: "application/json",
        success: function (data) {

        }


    })

    //btnCancelar
}