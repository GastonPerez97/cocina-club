﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on("click", "#btnModal", function () {
    var evento = $(this).data('even');
    var comensal = $(this).data('comen');

    $("#eventoIdjs").val(evento);
    $("#comensalIdJs").val(comensal);
});