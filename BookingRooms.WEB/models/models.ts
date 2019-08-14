

export class RoomDto {
    Id: number;
    Name: string;
    SeatsNumber: number;
    BuildingId: number;
    BuildingName: string;
    IsAvailable: boolean;
    CreatedOn: Date;
    UpdatedOn: Date;
}

export class BuildingDto {
    Id: number;
    Name: string;
    Address: string;
    City: string;
    IsAvailable: boolean;
    CreatedOn: Date;
    UpdatedOn: Date;
}

export class EmployeeDto {
    Id: number;
    Name: string;
    Surname: string;
    Username: string;
    EmailAddress: string;
    IsAvailable: boolean;
    CreatedOn: Date;
    UpdatedOn: Date;
}

export class BookingDto {
    Id: number;
    EmployeeId: number;
    EmployeeUsername: string;
    RoomId: number;
    RoomName: string;
    Description: string;
    BookedFrom: Date;
    BookedTo: Date;
    CreatedOn: Date;
    UpdatedOn: Date;
}