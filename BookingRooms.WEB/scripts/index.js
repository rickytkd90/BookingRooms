//StartUp
$(document).ready(function () {
    $('#inputBookingBookedFrom').datetimepicker({
        useCurrent: true,
        format: 'DD-MM-YYYY HH:mm'
    });
    $('#inputBookingBookedTo').datetimepicker({
        useCurrent: false,
        format: 'DD-MM-YYYY HH:mm'
    });
    $("#inputBookingBookedFrom").on("change.datetimepicker", function (e) {
        $('#inputBookingBookedTo').datetimepicker('minDate', e.date);
    });
    $("#inputBookingBookedTo").on("change.datetimepicker", function (e) {
        $('#inputBookingBookedFrom').datetimepicker('maxDate', e.date);
    });
});
//# sourceMappingURL=index.js.map