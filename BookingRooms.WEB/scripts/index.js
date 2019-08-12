//StartUp
$(document).ready(() => {
    //datetime picker
    $('#inputBookingBookedFrom').datetimepicker({
        format: 'DD/MM/YYYY HH:mm'
    });
    $('#inputBookingBookedTo').datetimepicker({
        useCurrent: false,
        format: 'DD/MM/YYYY HH:mm'
    });
    $("#inputBookingBookedFrom").on("change.datetimepicker", function (e) {
        $('#inputBookingBookedTo').datetimepicker('minDate', e.date);
    });
    $("#inputBookingBookedTo").on("change.datetimepicker", function (e) {
        $('#inputBookingBookedFrom').datetimepicker('maxDate', e.date);
    });
    $('.dataTables_length').addClass('bs-select');
});
//# sourceMappingURL=index.js.map