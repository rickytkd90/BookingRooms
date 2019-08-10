//StartUp
$(document).ready(() => {

    (<any>$('#inputBookingBookedFrom')).datetimepicker({
        useCurrent: true,
        format: 'DD-MM-YYYY HH:mm'
    });
    (<any>$('#inputBookingBookedTo')).datetimepicker({
        useCurrent: false,
        format: 'DD-MM-YYYY HH:mm'
    });
    $("#inputBookingBookedFrom").on("change.datetimepicker", function (e) {
        (<any>$('#inputBookingBookedTo')).datetimepicker('minDate', (<any>e).date);
    });
    $("#inputBookingBookedTo").on("change.datetimepicker", function (e) {
        (<any>$('#inputBookingBookedFrom')).datetimepicker('maxDate', (<any>e).date);
    });
});