const apiUri = 'https://localhost:44305/api';
let _self = this;
let optionsDate = { year: 'numeric', month: '2-digit', day: '2-digit' };
let buildingsTable, roomsTable, employeesTable, bookingsTable = null;
//StartUp
$(document).ready(() => {
    //*****Datetime picker init*****//
    $('#inputBookingBookedFrom').datetimepicker({ format: 'DD/MM/YYYY HH:mm', minDate: new Date() });
    $('#inputBookingBookedTo').datetimepicker({ format: 'DD/MM/YYYY HH:mm', minDate: new Date() });
    $("#inputBookingBookedFrom").on("change.datetimepicker", function (e) {
        $('#inputBookingBookedTo').val('');
        if ($("#inputBookingBookedFrom").val() != "")
            $('#inputBookingBookedTo').datetimepicker('minDate', $("#inputBookingBookedFrom").val());
        else
            $('#inputBookingBookedTo').datetimepicker('minDate', new Date());
    });
    //*****Tables Init*****//
    buildingsTable = $('#buildings-table').DataTable({ "pagingType": "simple_numbers", "searching": false });
    roomsTable = $('#rooms-table').DataTable({ "pagingType": "simple_numbers", "searching": false });
    employeesTable = $('#employees-table').DataTable({ "pagingType": "simple_numbers", "searching": false });
    bookingsTable = $('#bookings-table').DataTable({ "pagingType": "simple_numbers", "searching": false });
    $('.dataTables_length').addClass('bs-select');
    //*****Tables Get Data*****//
    _self.getBookings();
    _self.getRooms();
    _self.getBuildings();
    _self.getEmployees();
    //*****Form input utility*****//
    $('input').change(function () {
        $(this).removeClass('is-valid');
        $(this).removeClass('is-invalid');
    });
    //*****Search Bar*****//
    $("#search-bar").on("keyup", search);
});
//**********************************************************************
//      BUILDING
//**********************************************************************
function getBuildings() {
    $.getJSON(apiUri + '/building/get/all')
        .done((buildings) => {
        buildingsTable.clear();
        $("#inputRoomBuildings").empty();
        $('#inputRoomBuildings').append('<option value=0 selected="selected"></option>');
        $.each(buildings, (key, item) => {
            buildingsTable.row.add([
                item.Id,
                item.Name,
                item.Address,
                item.City,
                '<button type="button" class="btn btn-info btn-sm" onclick="getBuildingById(' + item.Id + ')"><i class="fas fa-info-circle"></i> Dettagli</button>'
            ]);
            if (item.IsAvailable)
                $('#inputRoomBuildings').append('<option value=' + item.Id + '>' + item.Name + '</option>');
        });
        buildingsTable.draw();
        sortDropdownValue("inputRoomBuildings");
    })
        .fail(function (jqXHR, textStatus, err) {
        alertMsg("DANGER", "Si � verificato un errore nel caricamento degli edifici", 0);
    });
}
function getBuildingById(id) {
    $.getJSON(apiUri + '/building/get/' + id)
        .done((item) => {
        $("#ModalDetail .modal-body").html('<ul>'
            + '<li><strong>Id:</strong> ' + item.Id + '</li>'
            + '<li><strong>Nome:</strong> ' + item.Name + '</li>'
            + '<li><strong>Indirizzo:</strong> ' + item.Address + '</li>'
            + '<li><strong>Citt�:</strong> ' + item.City + '</li>'
            + '<li><strong>Disponibile:</strong> ' + item.IsAvailable + '</li>'
            + '<li><strong>Data Inserimento:</strong> ' + new Date(item.CreatedOn).toLocaleDateString('it-IT', optionsDate) + '</li>'
            + '<li><strong>Data Aggiornamento:</strong> ' + new Date(item.UpdatedOn).toLocaleDateString('it-IT', optionsDate) + '</li>'
            + '</ul>');
        $('#ModalDetail').modal({ show: true });
    })
        .fail(function (jqXHR, textStatus, err) {
        alertMsg("DANGER", "Si � verificato un errore nel caricamento dei dettagli dell'edificio", 0);
    });
}
function addBuilding() {
    //check values
    let isInvalid;
    $("#ModalInsertBuildingForm input[type=text], #ModalInsertBuildingForm input[type=text] select").each(function () {
        if (!$(this).val()) {
            $(this).removeClass('is-valid');
            $(this).addClass('is-invalid');
            isInvalid = true;
        }
        else {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
        }
    });
    if (isInvalid) {
        alertMsg("DANGER", "Tutti i campi sono obbligatori", 0);
        return;
    }
    //call api
    $.ajax({
        type: "POST",
        url: apiUri + '/building/add',
        contentType: 'application/json',
        data: JSON.stringify({
            Name: $('#inputBuildingName').val(),
            Address: $('#inputBuildingAddress').val(),
            City: $('#inputBuildingCity').val(),
            IsAvailable: $('#inputBuildingAvailable')[0].checked
        })
    }).done(function (data) {
        //update buildings table
        getBuildings();
        //close modal
        $('#ModalInsertBuilding').modal('toggle');
        alertMsg("SUCCESS", "Edificio inserito con successo", 0);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alertMsg("DANGER", JSON.parse(jqXHR.responseText).Message, 0);
    });
}
//**********************************************************************
//      ROOM
//**********************************************************************
function getRooms() {
    $.getJSON(apiUri + '/room/get/all')
        .done((rooms) => {
        roomsTable.clear();
        $('#inputBookingRoom').empty();
        $('#inputBookingRoom').append('<option value=0 selected="selected"></option>');
        $.each(rooms, (key, item) => {
            roomsTable.row.add([
                item.Id,
                item.Name,
                item.SeatsNumber,
                '<button type="button" class="btn btn-info btn-sm" onclick="getRoomById(' + item.Id + ')"><i class="fas fa-info-circle"></i> Dettagli</button>'
            ]);
            if (item.IsAvailable)
                $('#inputBookingRoom').append('<option value=' + item.Id + '>' + item.Name + '</option>');
        });
        roomsTable.draw();
        sortDropdownValue("inputBookingRoom");
    })
        .fail(function (jqXHR, textStatus, err) {
        alertMsg("DANGER", "Si � verificato un errore nel caricamento delle sale", 0);
    });
}
function getRoomById(id) {
    $.getJSON(apiUri + '/room/get/' + id)
        .done((item) => {
        $("#ModalDetail .modal-body").html('<ul>'
            + '<li><strong>Id:</strong> ' + item.Id + '</li>'
            + '<li><strong>Nome:</strong> ' + item.Name + '</li>'
            + '<li><strong>Posti disponibili:</strong> ' + item.SeatsNumber + '</li>'
            + '<li><strong>Edificio:</strong> ' + item.BuildingName + '</li>'
            + '<li><strong>Disponibile:</strong> ' + item.IsAvailable + '</li>'
            + '<li><strong>Data Inserimento:</strong> ' + new Date(item.CreatedOn).toLocaleDateString('it-IT', optionsDate) + '</li>'
            + '<li><strong>Data Aggiornamento:</strong> ' + new Date(item.UpdatedOn).toLocaleDateString('it-IT', optionsDate) + '</li>'
            + '</ul>');
        $('#ModalDetail').modal({ show: true });
    })
        .fail(function (jqXHR, textStatus, err) {
        alertMsg("DANGER", "Si � verificato un errore nel caricamento dei dettagli della sala", 0);
    });
}
function addRoom() {
    //check values
    let isInvalid;
    $("#ModalInsertRoomForm input[type=text], #ModalInsertRoomForm select").each(function () {
        if (!$(this).val()) {
            $(this).removeClass('is-valid');
            $(this).addClass('is-invalid');
            isInvalid = true;
        }
        else {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
        }
    });
    if ($("#inputRoomBuildings option:selected").val() == 0) {
        isInvalid = true;
        $("#inputRoomBuildings").addClass('is-invalid');
        $("#inputRoomBuildings").removeClass('is-valid');
    }
    else {
        $("#inputRoomBuildings").removeClass('is-invalid');
        $("#inputRoomBuildings").addClass('is-valid');
    }
    if (isInvalid) {
        alertMsg("DANGER", "Tutti i campi sono obbligatori", 0);
        return;
    }
    //call api
    $.ajax({
        type: "POST",
        url: apiUri + '/room/add',
        contentType: 'application/json',
        data: JSON.stringify({
            Name: $('#inputRoomName').val(),
            SeatsNumber: $('#inputRoomSeatsNumber').val(),
            BuildingId: $('#inputRoomBuildings').val(),
            IsAvailable: $('#inputRoomAvailable')[0].checked
        })
    }).done(function (data) {
        //update rooms table
        getRooms();
        //close modal
        $('#ModalInsertRoom').modal('toggle');
        alertMsg("SUCCESS", "Sala inserita con successo", 0);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alertMsg("DANGER", JSON.parse(jqXHR.responseText).Message, 0);
    });
}
//**********************************************************************
//      EMPLOYEES
//**********************************************************************
function getEmployees() {
    $.getJSON(apiUri + '/employee/get/all')
        .done((employees) => {
        employeesTable.clear();
        $('#inputBookingEmployee').empty();
        $('#inputBookingEmployee').append('<option value=0 selected="selected"></option>');
        $.each(employees, (key, item) => {
            employeesTable.row.add([
                item.Id,
                item.Name,
                item.Surname,
                item.Username,
                item.EmailAddress,
                '<button type="button" class="btn btn-info btn-sm" onclick="getEmployeeById(' + item.Id + ')"><i class="fas fa-info-circle"></i> Dettagli</button>'
            ]);
            if (item.IsAvailable)
                $('#inputBookingEmployee').append('<option value=' + item.Id + '>' + item.Surname + ' ' + item.Name + ' (' + item.Username + ') </option>');
        });
        employeesTable.draw();
        sortDropdownValue("inputBookingEmployee");
    })
        .fail(function (jqXHR, textStatus, err) {
        alertMsg("DANGER", "Si � verificato un errore nel caricamento delle risorse", 0);
    });
}
function getEmployeeById(id) {
    $.getJSON(apiUri + '/employee/get/' + id)
        .done((item) => {
        $("#ModalDetail .modal-body").html('<ul>'
            + '<li><strong>Id:</strong> ' + item.Id + '</li>'
            + '<li><strong>Nome:</strong> ' + item.Name + '</li>'
            + '<li><strong>Cognome:</strong> ' + item.Surname + '</li>'
            + '<li><strong>Username:</strong> ' + item.Username + '</li>'
            + '<li><strong>Indirizzo Mail:</strong> ' + item.EmailAddress + '</li>'
            + '<li><strong>Disponibile:</strong> ' + item.IsAvailable + '</li>'
            + '<li><strong>Data Inserimento:</strong> ' + new Date(item.CreatedOn).toLocaleDateString('it-IT', optionsDate) + '</li>'
            + '<li><strong>Data Aggiornamento:</strong> ' + new Date(item.UpdatedOn).toLocaleDateString('it-IT', optionsDate) + '</li>'
            + '</ul>');
        $('#ModalDetail').modal({ show: true });
    })
        .fail(function (jqXHR, textStatus, err) {
        alertMsg("DANGER", "Si � verificato un errore nel caricamento dei dettagli della risorsa", 0);
    });
}
function addEmployee() {
    //check values
    let isInvalid;
    $("#ModalInsertEmployeeForm input[type=text], #ModalInsertEmployeeForm select").each(function () {
        if (!$(this).val()) {
            $(this).removeClass('is-valid');
            $(this).addClass('is-invalid');
            isInvalid = true;
        }
        else {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
        }
    });
    if (isInvalid) {
        alertMsg("DANGER", "Tutti i campi sono obbligatori", 0);
        return;
    }
    //call api
    $.ajax({
        type: "POST",
        url: apiUri + '/employee/add',
        contentType: 'application/json',
        data: JSON.stringify({
            Id: $('#inputEmployeeId').val(),
            Name: $('#inputEmployeeName').val(),
            Surname: $('#inputEmployeeSurname').val(),
            IsAvailable: $('#inputEmployeeAvailable')[0].checked
        })
    }).done(function (data) {
        //update employees table
        getEmployees();
        //close modal
        $('#ModalInsertEmployee').modal('toggle');
        alertMsg("SUCCESS", "Risorsa inserita con successo", 0);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alertMsg("DANGER", JSON.parse(jqXHR.responseText).Message, 0);
    });
}
//**********************************************************************
//      BOOKING
//**********************************************************************
function getBookings() {
    $.getJSON(apiUri + '/booking/get/all')
        .done((bookings) => {
        bookingsTable.clear();
        $.each(bookings, (key, item) => {
            bookingsTable.row.add([
                item.Id,
                item.EmployeeUsername,
                item.RoomName,
                new Date(item.BookedFrom).toLocaleString('it-IT'),
                new Date(item.BookedTo).toLocaleString('it-IT'),
                '<button type="button" class="btn btn-info btn-sm" onclick="getBookingById(' + item.Id + ')"><i class="fas fa-info-circle"></i> Detttagli</button>',
                '<button type="button" class="btn btn-danger btn-sm" onclick="deleteBooking(' + item.Id + ')"><i class="far fa-trash-alt"></i> Elimina</button>'
            ]);
        });
        bookingsTable.draw();
    })
        .fail(function (jqXHR, textStatus, err) {
        alertMsg("DANGER", "Si � verificato un errore nel caricamento delle prenotazioni", 0);
    });
}
function getBookingById(id) {
    $.getJSON(apiUri + '/booking/get/' + id)
        .done((item) => {
        $("#ModalDetail .modal-body").html('<ul>'
            + '<li><strong>Id:</strong> ' + item.Id + '</li>'
            + '<li><strong>Username Risorsa:</strong> ' + item.EmployeeUsername + '</li>'
            + '<li><strong>Nome Sala:</strong> ' + item.RoomName + '</li>'
            + '<li><strong>Sala prenotata da:</strong> ' + new Date(item.BookedFrom).toLocaleString('it-IT') + '</li>'
            + '<li><strong>A:</strong> ' + new Date(item.BookedTo).toLocaleString('it-IT') + '</li>'
            + '<li><strong>Descrizione:</strong> ' + item.Description + '</li>'
            + '<li><strong>Data Inserimento:</strong> ' + new Date(item.CreatedOn).toLocaleDateString('it-IT', optionsDate) + '</li>'
            + '<li><strong>Data Aggiornamento:</strong> ' + new Date(item.UpdatedOn).toLocaleDateString('it-IT', optionsDate) + '</li>'
            + '</ul>');
        $('#ModalDetail').modal({ show: true });
    })
        .fail(function (jqXHR, textStatus, err) {
        alertMsg("DANGER", "Si � verificato un errore nel caricamento dei dettagli della sala", 0);
    });
}
function addBooking() {
    //check values
    let isInvalid;
    $("#ModalInsertBookingForm input").each(function () {
        if (!$(this).val()) {
            $(this).removeClass('is-valid');
            $(this).addClass('is-invalid');
            isInvalid = true;
        }
        else {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
        }
    });
    if ($("#inputBookingEmployee option:selected").val() == 0) {
        isInvalid = true;
        $("#inputBookingEmployee").addClass('is-invalid');
        $("#inputBookingEmployee").removeClass('is-valid');
    }
    else {
        $("#inputBookingEmployee").removeClass('is-invalid');
        $("#inputBookingEmployee").addClass('is-valid');
    }
    if ($("#inputBookingRoom option:selected").val() == 0) {
        isInvalid = true;
        $("#inputBookingRoom").addClass('is-invalid');
        $("#inputBookingRoom").removeClass('is-valid');
    }
    else {
        $("#inputBookingRoom").removeClass('is-invalid');
        $("#inputBookingRoom").addClass('is-valid');
    }
    if (isInvalid) {
        alertMsg("DANGER", "Tutti i campi sono obbligatori", 0);
        return;
    }
    $.ajax({
        type: "POST",
        url: apiUri + '/booking/add',
        contentType: 'application/json',
        data: JSON.stringify({
            EmployeeId: $('#inputBookingEmployee').val(),
            RoomId: $('#inputBookingRoom').val(),
            Description: $('#inputBookingDescription').val(),
            BookedFrom: convertDate($('#inputBookingBookedFrom').val().toString()),
            BookedTo: convertDate($('#inputBookingBookedTo').val().toString()),
        })
    }).done(function (data) {
        //update bookings table
        getBookings();
        //close modal
        $('#ModalInsertBooking').modal('toggle');
        alertMsg("SUCCESS", "Prenotazione inserita con successo", 0);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alertMsg("DANGER", jqXHR.responseJSON.ExceptionMessage, 0);
    });
}
function deleteBooking(id) {
    $.ajax({
        type: "DELETE",
        url: apiUri + '/booking/delete/' + id
    }).done(function (data) {
        //update bookings table
        getBookings();
        alertMsg("SUCCESS", "Prenotazione cancellata con successo", 0);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alertMsg("DANGER", JSON.parse(jqXHR.responseText).Message, 0);
    });
}
//**********************************************************************
//      UTILITIES
//**********************************************************************
function alertMsg(errType, errMsg, isPermanent) {
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
}
;
function showModal(id) {
    $('#' + id + ' input').each(function () {
        $(this).val("");
        $(this).removeClass('is-valid');
        $(this).removeClass('is-invalid');
    });
    $("#inputRoomBuildings").val($("#inputRoomBuildings option:first").val());
    $("#inputRoomBuildings").removeClass('is-valid');
    $("#inputRoomBuildings").removeClass('is-invalid');
    $("#inputBookingEmployee").val($("#inputBookingEmployee option:first").val());
    $("#inputBookingEmployee").removeClass('is-valid');
    $("#inputBookingEmployee").removeClass('is-invalid');
    $("#inputBookingRoom").val($("#inputBookingRoom option:first").val());
    $("#inputBookingRoom").removeClass('is-valid');
    $("#inputBookingRoom").removeClass('is-invalid');
    $('#' + id).find('form')[0].reset();
    $('#' + id).modal({ show: true });
}
function convertDate(date) {
    var dateParts = date.split("/");
    var timeParts = dateParts[2].split(" ")[1].split(":");
    var data = new Date(Date.UTC(+dateParts[2].split(" ")[0], +dateParts[1] - 1, +dateParts[0], +timeParts[0], +timeParts[1]));
    console.log(data);
    return data;
}
function sortDropdownValue(id) {
    var selectList = $('#' + id + ' option');
    selectList.sort(function (x, y) {
        // to change to descending order switch "<" for ">"
        return $(x).text() > $(y).text() ? 1 : -1;
    });
    $('#' + id).html(selectList);
}
function search() {
    let value = $('#search-bar').val().toString().toLowerCase();
    $("#bookings-table tbody tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        return true;
    });
}
//# sourceMappingURL=index.js.map