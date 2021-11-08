$(document).on("click", "#btnModal", function () {
    var evento = $(this).data('even');
    var comensal = $(this).data('comen');

    $("#eventoIdjs").val(evento);
    $("#comensalIdJs").val(comensal);
});