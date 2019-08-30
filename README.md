# BookingRooms

Progetto Percorso Circolare 2019

Riccardo Grassi

**Repository:** https://github.com/rickytkd90/BookingRooms.git

## Solution

La solution è composta dai seguenti progetti:

- BookingRooms.DAL
- BookingRooms.BL
- BookingRooms.WebAPI
- BookingRooms.WEB
- BookingRooms.Common
- TestProject

Per il debug dell'applicazione è necessario impostare il progetto **BookingRooms.WebAPI** e il progetto **BookingRooms.WEB** come **StartUp Projects** dalle properties della solution.

Per l'accesso ai dati è stato utilizzato **Entity Framework**, installato tramite pacchetto **NuGet** nel progetto **BookingRooms.DAL**.
La stringa di connessione è presente nel file **App.config** del progetto **BookingRooms.DAL**

La parte client è stata realizzata tramite **Typescript**, il cui compilatore è stato installato come pacchetto **NuGet** nel progetto **BookingRooms.WEB**

Nel progetto **BookingRooms.WebAPI** è stato installato il pacchetto **StructureMap** per permettere la **dependency injection** nelle classi dei Controller (i setting sono presenti nel file **DefaultRegistry.cs**) e il pacchetto per la gestione **CORS**.

Il progetto **BookingRooms.Common** contiene l'utility per la gestione dei LOG

Il progetto **TestProject** contiene i test automatici

## Database

Il nome del database è **BookingRooms**.
Lo script per la creazione del database è presente nello ZIP inviato e nella repository Git.

```
DBScript.sql
```

Esegueno lo script di creazione, il database verrà creato e popolato con alcuni dati utilizzati durante i test.

## Librerie da NPM

Sono state utilizzate librerie di terze parti che devono essere scaricate tramite il comando:

```
npm install
```

da eseguire all'interno del progetto **BookingRooms.WEB**.

## Pacchetti Nuget

Eseguire il restore dei pacchetti della solution. Se all'avvio del progetto **BookingRooms.WebAPI** ci fossero dei problemi, dalla console di nuget eseguire il comando: 

```
cd .\BookingRooms.WebAPI
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
```

## Swagger

La documentazione relativa alle API è accessibile avviando il progetto **BookingRooms.WebAPI** e aggiungento all'url

```
/swagger/ui/index
```

## LOG

I log dell'applicazione vengono scritti nella folder **Log** che si trova al primo livello della folder della solution.
Per la loro lettura si consiglia l'utilizzo di [YALV! - Yet Another Log4Net Viewer](https://github.com/LukePet/YALV)
