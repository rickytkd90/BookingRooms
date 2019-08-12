import { RoomDto, BuildingDto, EmployeeDto, BookingDto } from "../models/models";

const apiUri: string = 'https://localhost:44305/api';
let _self = this;
let buildingsTable = null;
let roomsTable = null;
let employeesTable = null;
//let bookingsTable = null;

//StartUp
$(document).ready(() => {

    buildingsTable = (<any>$('#buildings-table')).DataTable({
        "pagingType": "simple_numbers",
        "searching": false
    });

    roomsTable = (<any>$('#rooms-table')).DataTable({
        "pagingType": "simple_numbers",
        "searching": false
    });

    employeesTable = (<any>$('#employees-table')).DataTable({
        "pagingType": "simple_numbers",
        "searching": false
    });

    //bookingsTable = (<any>$('#bookings-table')).DataTable({
    //    "pagingType": "simple_numbers",
    //    "searching": false
    //});

    _self.getRooms();
    _self.getBuildings();
    _self.getEmployees();
    //_self.getBookings();

});


function getRooms() {

    $.getJSON(apiUri + '/room/get/all')
        .done((rooms: RoomDto[]) => {

            $('#inputBookingRoom').empty();
            roomsTable.clear();
            $('#inputBookingRoom').append('<option value=0 selected="selected">Seleziona..</option>');

            $.each(rooms, (key, item: RoomDto) => {

                roomsTable.row.add(
                    [
                        item.Id,
                        item.Name,
                        item.SeatsNumber,
                        item.BuildingId
                    ]
                );

                $('#inputBookingRoom').append('<option value=' + item.Id + '>' + item.Name + '</option>');

            });

            roomsTable.draw();

        })
        .fail(function (jqXHR, textStatus, err) {
            alertMsg("DANGER", "Si è verificato un errore nel caricamento delle sale", 0);
        });
}

function addRoom(): void {
    $.ajax({
        type: "POST",
        url: apiUri + '/room/add',
        contentType: 'application/json',
        data: JSON.stringify({
            Name: $('#inputRoomName').val(),
            SeatsNumber: $('#inputRoomSeatsNumber').val(),
            BuildingId: $('#inputRoomBuildings').val(),
            IsAvailable: true
        })
    }).done(function (data) {
        getRooms();
        $('#ModalInsertBooking').modal('toggle');
        (<any>$('#ModalInsertBooking').find('form')[0]).reset();
        alertMsg("SUCCESS", "Sala inserita con successo", 0);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        
    });
}

function getBuildings() {

    $.getJSON(apiUri + '/building/get/all')
        .done((buildings: BuildingDto[]) => {

            $("#inputRoomBuildings").empty();
            buildingsTable.clear();
            $('#inputRoomBuildings').append('<option value=0 selected="selected">Seleziona..</option>');

            $.each(buildings, (key, item: BuildingDto) => {

                buildingsTable.row.add(
                    [
                        item.Id,
                        item.Name,
                        item.Address,
                        item.City
                    ]
                );

                $('#inputRoomBuildings').append('<option value=' + item.Id + '>' + item.Name + '</option>');
            });

            buildingsTable.draw();

        })
        .fail(function (jqXHR, textStatus, err) {
            alertMsg("DANGER", "Si è verificato un errore nel caricamento degli edifici", 0);
        });
}

function addBuilding(): void {
    $.ajax({
        type: "POST",
        url: apiUri + '/building/add',
        contentType: 'application/json',
        data: JSON.stringify({
            Name: $('#inputBuildingName').val(),
            Address: $('#inputBuildingAddress').val(),
            City: $('#inputBuildingCity').val(),
            IsAvailable: true
        })
    }).done(function (data) {
        getBuildings();
        $('#ModalInsertBuilding').modal('toggle');
        (<any>$('#ModalInsertBuilding').find('form')[0]).reset();
        alertMsg("SUCCESS", "Edificio inserito con successo", 0);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alertMsg("DANGER", jqXHR.responseJSON.ExceptionMessage, 0);
    });
}

function getEmployees() {

    $.getJSON(apiUri + '/employee/get/all')
        .done((employees: EmployeeDto[]) => {

            $('#inputBookingEmployee').empty();
            employeesTable.clear();
            $('#inputBookingEmployee').append('<option value=0 selected="selected">Seleziona..</option>');
           
            $.each(employees, (key, item: EmployeeDto) => {

                employeesTable.row.add(
                    [
                        item.Id,
                        item.Name,
                        item.Surname,
                        item.Username,
                        item.EmailAddress
                    ]
                );

                $('#inputBookingEmployee').append('<option value=' + item.Id + '>' + item.Surname + ' ' + item.Name + ' (' + item.Username + ') </option>');
            });

            employeesTable.draw();

        })
        .fail(function (jqXHR, textStatus, err) {
            alertMsg("DANGER", "Si è verificato un errore nel caricamento delle risorse", 0);
        });
}

function getBookings() {

    $.getJSON(apiUri + '/booking/get/all')
        .done((bookings: BookingDto[]) => {

            $.each(bookings, (key, item: BookingDto) => {
                $('#employees-table').append('<tr><th>' +
                    '<div><span class="glyphicon glyphicon-record add-new-icon" data-toggle="modal" data-target="#detail-modal" onclick="openDetailRoom(' + item.Id + ')"></span></div>' +
                    '</th><td class="filter">' + item.Id + '</td><td class="hidden-sm hidden-xs">' + item.BookedTo + '</td><td>');
            });

            (<any>$('#bookings-table')).DataTable({
                "pagingType": "simple_numbers",
                "searching": false
            });

        })
        .fail(function (jqXHR, textStatus, err) {
            alertMsg("DANGER", "Si è verificato un errore nel caricamento delle prenotazioni", 0);
        });
}

function addBooking(): void {
    $.ajax({
        type: "POST",
        url: apiUri + '/booking/add',
        contentType: 'application/json',
        data: JSON.stringify({
            EmployeeId: $('#inputBookingEmployee').val(),
            RoomId: $('#inputBookingRoom').val(),
            Description: $('#inputBookingDescription').val(),
            BookedFrom: $('#inputBookingBookedFrom').val(),
            BookedTo: $('#inputBookingBookedTo').val(),
        })
    }).done(function (data) {
        getBookings();
        $('#ModalInsertBooking').modal('toggle');
        (<any>$('#ModalInsertBooking').find('form')[0]).reset();
        alertMsg("SUCCESS", "Prenotazione inserita con successo", 0);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("Si è verificato un errore nell'inserimento della prenotazione");
    });
}

function alertMsg(errType, errMsg, isPermanent) {
    console.log('Funzione chiamata')
    var alertClass;
    var alertDiv;

    switch (errType) {
        case "SUCCESS":
            alertClass = "alert-success";
            break;
        case "INFO":
            alertClass = "alert-info";
            break;
        case "WARNING":
            alertClass = "alert-warning";
            break;
        case "DANGER":
            alertClass = "alert-danger";
            break;
        default:
            alertClass = "alert-danger";
            alertDiv = $(".alert-container").append('<div class="tempAlert alert ' + alertClass + ' alert-dismissible" role="alert">Error Type not recognized <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
            $(".alert-container").append(alertDiv);
            break;
    }

    if (isPermanent == 1) {
        alertDiv = '<div class="alert ' + alertClass + ' alert-dismissible" role="alert">' + errMsg + ' <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>';
    }
    else {
        alertDiv = '<div class="tempAlert alert ' + alertClass + ' alert-dismissible" role="alert">' + errMsg + ' <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>';
    }

    $(".alert-container").append(alertDiv);
    $(".tempAlert").fadeOut(8000);
};

function showModal(id: string) {
    $('#' + id).modal({ show: true });
}