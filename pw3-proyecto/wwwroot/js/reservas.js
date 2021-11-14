// New review modal button
$(document).on("click", "#btnModal", function () {
    var evento = $(this).data('even');
    var comensal = $(this).data('comen');

    $("#eventoIdjs").val(evento);
    $("#comensalIdJs").val(comensal);
});

// Review comments popover
var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl)
})