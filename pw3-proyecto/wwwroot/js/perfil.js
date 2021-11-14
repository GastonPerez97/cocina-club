function cancelEvent(eventId, userId) {
    $.ajax({
        type: "PUT",
        url: 'https://localhost:44387/api/event/' + eventId + '/cancel',
        data: JSON.stringify(userId),
        contentType: "application/json; charset=utf-8",
        success: () => {
            $("#cancelEventModalBodyMessage-" + eventId).text("El evento fue cancelado correctamente.");

            $("#statePendiente-" + eventId).text("Cancelado");

            $("#statePendienteIcon-" + eventId).removeClass("fa-clock");
            $("#statePendienteIcon-" + eventId).addClass("fa-times-circle");

            $(".cancelEventModalBtn-" + eventId).hide();

            $("#cancelEventModalBtnCancel-" + eventId).hide();

            $("#cancelEventModalBtnClose-" + eventId).removeClass("d-none");
            $("#cancelEventModalBtnClose-" + eventId).show();
        },
        error: (errormessage) => {
            $("#cancelEventModalBodyMessage-" + eventId).text("Ocurrió un error al intentar cancelar el evento, intente mas tarde.");

            $(".cancelEventModalBtn-" + eventId).hide();

            $("#cancelEventModalBtnClose-" + eventId).removeClass("d-none");
            $("#cancelEventModalBtnClose-" + eventId).show();
        }
    });
}