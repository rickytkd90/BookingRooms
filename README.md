# BookingRooms

Progetto percorso circolare 2019

Riccardo Grassi

**Repository:** https://github.com/rickytkd90/BookingRooms.git

### Database

Lo script per la creazione del database è presente nello ZIP inviato e nella repository Git.

```
DBScript.sql
```

La stringa di connessione presente all'interno dell'applicazione. Il nome del database è **BookingRooms**.
Il database è già popolato con alcuni dati utilizzati nei test

### Solution

Per il debug dell'applicazione è necessario impostare il progetto **BookingRooms.WebAPI** e il progetto **BookingRooms.WEB** come **StartUp Projects** dalle properties della solution.

### Librerie da NPM

Sono state utilizzate librerie di terze parti che devono essere scaricate tramite il comando:

```
npm install
```

all'interno del progetto **BookingRooms.WEB**.

### Swagger

la documentazione relativa alle API è accessibile avviando il progetto **BookingRooms.WebAPI** e aggiungento all'url **/swagger/ui/index**
