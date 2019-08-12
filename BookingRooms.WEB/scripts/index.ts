//StartUp
$(document).ready(() => {


    //datetime picker
    (<any>$('#inputBookingBookedFrom')).datetimepicker({
        format: 'DD/MM/YYYY HH:mm'
    });
    (<any>$('#inputBookingBookedTo')).datetimepicker({
        useCurrent: false,
        format: 'DD/MM/YYYY HH:mm'
    });
    $("#inputBookingBookedFrom").on("change.datetimepicker", function (e) {
        (<any>$('#inputBookingBookedTo')).datetimepicker('minDate', (<any>e).date);
    });
    $("#inputBookingBookedTo").on("change.datetimepicker", function (e) {
        (<any>$('#inputBookingBookedFrom')).datetimepicker('maxDate', (<any>e).date);
    });

    $('.dataTables_length').addClass('bs-select');
});