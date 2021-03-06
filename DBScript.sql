USE [master]
GO
/****** Object:  Database [BookingRooms]    Script Date: 29/08/2019 19:24:41 ******/
CREATE DATABASE [BookingRooms]
 CONTAINMENT = NONE
GO
ALTER DATABASE [BookingRooms] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookingRooms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookingRooms] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookingRooms] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookingRooms] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookingRooms] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookingRooms] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookingRooms] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookingRooms] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookingRooms] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookingRooms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookingRooms] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookingRooms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookingRooms] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookingRooms] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookingRooms] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookingRooms] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookingRooms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookingRooms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookingRooms] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookingRooms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookingRooms] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookingRooms] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookingRooms] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookingRooms] SET RECOVERY FULL 
GO
ALTER DATABASE [BookingRooms] SET  MULTI_USER 
GO
ALTER DATABASE [BookingRooms] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookingRooms] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookingRooms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookingRooms] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookingRooms] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookingRooms', N'ON'
GO
ALTER DATABASE [BookingRooms] SET QUERY_STORE = OFF
GO
USE [BookingRooms]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 29/08/2019 19:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[BookedFrom] [datetime] NOT NULL,
	[BookedTo] [datetime] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 29/08/2019 19:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 29/08/2019 19:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](8) NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 29/08/2019 19:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SeatsNumber] [int] NOT NULL,
	[BuildingId] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (18, 5, 16, N'Riunione per SAL', CAST(N'2019-09-09T09:00:00.000' AS DateTime), CAST(N'2019-09-09T11:00:00.000' AS DateTime), CAST(N'2019-08-29T15:22:07.383' AS DateTime), CAST(N'2019-08-29T15:22:07.383' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (19, 12, 13, N'Riunione definizione requisiti', CAST(N'2019-09-09T15:00:00.000' AS DateTime), CAST(N'2019-09-09T17:00:00.000' AS DateTime), CAST(N'2019-08-29T15:23:34.570' AS DateTime), CAST(N'2019-08-29T15:23:34.570' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (20, 1, 7, N'Corso di Sicurezza', CAST(N'2019-09-11T09:00:00.000' AS DateTime), CAST(N'2019-09-11T18:00:00.000' AS DateTime), CAST(N'2019-08-29T15:24:32.657' AS DateTime), CAST(N'2019-08-29T15:24:32.657' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (21, 4, 15, N'Percorso Circolare', CAST(N'2019-09-10T09:00:00.000' AS DateTime), CAST(N'2019-09-10T18:00:00.000' AS DateTime), CAST(N'2019-08-29T15:25:13.323' AS DateTime), CAST(N'2019-08-29T15:25:13.323' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (22, 3, 12, N'Preparazione Open Day', CAST(N'2019-09-12T14:00:00.000' AS DateTime), CAST(N'2019-09-12T17:30:00.000' AS DateTime), CAST(N'2019-08-29T15:26:07.537' AS DateTime), CAST(N'2019-08-29T15:26:07.537' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (23, 10, 11, N'Call con Cliente', CAST(N'2019-09-09T14:00:00.000' AS DateTime), CAST(N'2019-09-09T17:00:00.000' AS DateTime), CAST(N'2019-08-29T15:27:20.367' AS DateTime), CAST(N'2019-08-29T15:27:20.367' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (24, 90, 8, N'SAL', CAST(N'2019-09-11T14:00:00.000' AS DateTime), CAST(N'2019-09-11T17:00:00.000' AS DateTime), CAST(N'2019-08-29T15:28:13.790' AS DateTime), CAST(N'2019-08-29T15:28:13.790' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (25, 90, 9, N'Data LAB', CAST(N'2019-09-11T09:00:00.000' AS DateTime), CAST(N'2019-09-11T18:00:00.000' AS DateTime), CAST(N'2019-08-29T15:28:51.233' AS DateTime), CAST(N'2019-08-29T15:28:51.233' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (26, 6, 6, N'Definizione Task di sviluppo', CAST(N'2019-09-12T10:00:00.000' AS DateTime), CAST(N'2019-09-12T12:00:00.000' AS DateTime), CAST(N'2019-08-29T15:29:46.583' AS DateTime), CAST(N'2019-08-29T15:29:46.583' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (27, 2, 10, N'Incontro per allocazione', CAST(N'2019-09-09T10:00:00.000' AS DateTime), CAST(N'2019-09-09T11:00:00.000' AS DateTime), CAST(N'2019-08-29T15:30:31.163' AS DateTime), CAST(N'2019-08-29T15:30:31.163' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (28, 7, 10, N'Colloquio di Valutazione', CAST(N'2019-09-10T10:00:00.000' AS DateTime), CAST(N'2019-09-10T11:30:00.000' AS DateTime), CAST(N'2019-08-29T15:31:08.587' AS DateTime), CAST(N'2019-08-29T15:31:08.587' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (30, 8, 16, N'Colloquio di valutazione', CAST(N'2019-09-09T11:00:00.000' AS DateTime), CAST(N'2019-09-09T12:00:00.000' AS DateTime), CAST(N'2019-08-29T15:58:02.650' AS DateTime), CAST(N'2019-08-29T15:58:02.653' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (31, 9, 16, N'Call con cliente', CAST(N'2019-09-09T16:00:00.000' AS DateTime), CAST(N'2019-09-09T18:00:00.000' AS DateTime), CAST(N'2019-08-29T16:38:44.747' AS DateTime), CAST(N'2019-08-29T16:38:44.747' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (32, 9, 16, N'SAL', CAST(N'2019-09-09T12:00:00.000' AS DateTime), CAST(N'2019-09-09T14:00:00.000' AS DateTime), CAST(N'2019-08-29T17:38:03.957' AS DateTime), CAST(N'2019-08-29T17:38:03.957' AS DateTime))
INSERT [dbo].[Booking] ([Id], [EmployeeId], [RoomId], [Description], [BookedFrom], [BookedTo], [CreatedOn], [UpdatedOn]) VALUES (33, 9, 16, N'Call', CAST(N'2019-09-09T14:00:00.000' AS DateTime), CAST(N'2019-09-09T16:00:00.000' AS DateTime), CAST(N'2019-08-29T17:46:02.010' AS DateTime), CAST(N'2019-08-29T17:46:02.010' AS DateTime))
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[Building] ON 

INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (2, N'Edificio 1', N'Via Dante 5', N'Busto Arsizio', 1, CAST(N'2019-08-12T14:41:40.697' AS DateTime), CAST(N'2019-08-12T14:41:40.703' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (3, N'Edificio 2', N'Via Dante 5', N'Busto Arsizio', 1, CAST(N'2019-08-12T14:42:03.390' AS DateTime), CAST(N'2019-08-12T14:42:03.390' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (4, N'Edificio 3', N'Via Dante 5', N'Busto Arsizio', 1, CAST(N'2019-08-12T14:42:09.023' AS DateTime), CAST(N'2019-08-12T14:42:09.023' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (5, N'Edificio 4', N'Via Dante 5', N'Busto Arsizio', 1, CAST(N'2019-08-12T14:42:14.797' AS DateTime), CAST(N'2019-08-12T14:42:14.797' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (6, N'Edificio 5', N'Via Dante 5', N'Busto Arsizio', 1, CAST(N'2019-08-12T14:42:18.700' AS DateTime), CAST(N'2019-08-12T14:42:18.700' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (7, N'Edificio 6', N'Via Dante 5', N'Busto Arsizio', 1, CAST(N'2019-08-12T14:59:22.967' AS DateTime), CAST(N'2019-08-12T14:59:22.967' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (8, N'Edificio 7', N'Via Dante 5', N'Busto Arsizio', 1, CAST(N'2019-08-12T15:01:00.433' AS DateTime), CAST(N'2019-08-12T15:01:00.433' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (9, N'Edificio 8', N'Via della Concordia 8', N'Busto Arsizio', 1, CAST(N'2019-08-12T15:04:28.777' AS DateTime), CAST(N'2019-08-12T15:04:28.777' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (10, N'Edificio 9', N'Via della Concordia 8', N'Busto Arsizio', 1, CAST(N'2019-08-12T15:04:39.717' AS DateTime), CAST(N'2019-08-12T15:04:39.717' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (11, N'Edificio 10', N'Via della Concordia 8', N'Busto Arsizio', 1, CAST(N'2019-08-12T15:04:46.930' AS DateTime), CAST(N'2019-08-12T15:04:46.930' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (18, N'Edificio 11', N'Via Dante 5', N'Busto Arsizio', 1, CAST(N'2019-08-13T19:00:13.563' AS DateTime), CAST(N'2019-08-13T19:00:13.563' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (19, N'Edificio 12', N'Matteotti', N'Cuggiono', 1, CAST(N'2019-08-16T20:01:36.170' AS DateTime), CAST(N'2019-08-16T20:01:36.170' AS DateTime))
INSERT [dbo].[Building] ([Id], [Name], [Address], [City], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (20, N'Edificio non disponibile', N'Test', N'Test', 0, CAST(N'2019-08-16T23:13:17.370' AS DateTime), CAST(N'2019-08-16T23:13:17.370' AS DateTime))
SET IDENTITY_INSERT [dbo].[Building] OFF
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (1, N'Riccardo', N'Grassi', N'grassri1', N'riccardo.grassi@reti.it', 1, CAST(N'2019-08-14T09:25:39.287' AS DateTime), CAST(N'2019-08-14T09:25:39.290' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (2, N'Mario', N'Rossi', N'rossima1', N'mario.rossi@reti.it', 1, CAST(N'2019-08-14T09:50:59.767' AS DateTime), CAST(N'2019-08-14T09:50:59.767' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (3, N'Eugenio', N'Montale', N'montaeu1', N'eugenio.montale@reti.it', 1, CAST(N'2019-08-14T09:51:55.607' AS DateTime), CAST(N'2019-08-14T09:51:55.607' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (4, N'Giacomo', N'Leopardi', N'leopagi1', N'giacomo.leopardi@reti.it', 1, CAST(N'2019-08-14T09:52:14.363' AS DateTime), CAST(N'2019-08-14T09:52:14.363' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (5, N'Gabriele', N'D''Annunzio', N'dannuga1', N'gabriele.dannunzio@reti.it', 1, CAST(N'2019-08-14T10:13:09.813' AS DateTime), CAST(N'2019-08-14T10:13:09.823' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (6, N'Salvatore', N'Quasimodo', N'quasisa1', N'salvatore.quasimodo@reti.it', 1, CAST(N'2019-08-14T10:14:33.513' AS DateTime), CAST(N'2019-08-14T10:14:33.513' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (7, N'Mario', N'Rossi', N'rossima2', N'mario.rossi1@reti.it', 1, CAST(N'2019-08-14T10:15:02.717' AS DateTime), CAST(N'2019-08-14T10:15:02.717' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (8, N'Mario', N'Rossi', N'rossima3', N'mario.rossi2@reti.it', 1, CAST(N'2019-08-14T10:15:20.757' AS DateTime), CAST(N'2019-08-14T10:15:20.757' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (9, N'Giuseppe', N'Ungaretti', N'ungargi1', N'giuseppe.ungaretti@reti.it', 1, CAST(N'2019-08-14T10:15:50.257' AS DateTime), CAST(N'2019-08-14T10:15:50.257' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (10, N'Pablo', N'Neruda', N'nerudpa1', N'pablo.neruda@reti.it', 1, CAST(N'2019-08-14T10:17:00.190' AS DateTime), CAST(N'2019-08-14T10:17:00.190' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (12, N'Adriano', N'Garavaglia', N'garavad1', N'adriano.garavaglia@reti.it', 1, CAST(N'2019-08-16T19:55:44.680' AS DateTime), CAST(N'2019-08-16T19:55:44.680' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (90, N'Francesco', N'Petrarca', N'petrafr1', N'francesco.petrarca@reti.it', 1, CAST(N'2019-08-16T23:24:41.923' AS DateTime), CAST(N'2019-08-16T23:24:41.923' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [Surname], [Username], [EmailAddress], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (100, N'Risorsa', N'Non Disponibile', N'nondiri1', N'risorsa.nondisponibile@reti.it', 0, CAST(N'2019-08-16T23:21:45.150' AS DateTime), CAST(N'2019-08-16T23:21:45.150' AS DateTime))
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (6, N'Monte Bianco', 25, 2, 1, CAST(N'2019-08-12T21:00:05.520' AS DateTime), CAST(N'2019-08-12T21:00:05.523' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (7, N'Dolomiti', 10, 3, 1, CAST(N'2019-08-12T21:09:25.620' AS DateTime), CAST(N'2019-08-12T21:09:25.620' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (8, N'Gran Sasso', 30, 4, 1, CAST(N'2019-08-12T21:10:37.640' AS DateTime), CAST(N'2019-08-12T21:10:37.640' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (9, N'Marmolada', 20, 5, 1, CAST(N'2019-08-12T21:13:56.070' AS DateTime), CAST(N'2019-08-12T21:13:56.070' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (10, N'Monviso', 40, 6, 1, CAST(N'2019-08-12T21:23:11.200' AS DateTime), CAST(N'2019-08-12T21:23:11.200' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (11, N'Gran Paradiso', 35, 7, 1, CAST(N'2019-08-12T21:24:15.127' AS DateTime), CAST(N'2019-08-12T21:24:15.127' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (12, N'Everest', 50, 8, 1, CAST(N'2019-08-12T21:25:10.417' AS DateTime), CAST(N'2019-08-12T21:25:10.417' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (13, N'Cervino', 5, 9, 1, CAST(N'2019-08-12T21:25:45.823' AS DateTime), CAST(N'2019-08-12T21:25:45.823' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (14, N'K2', 24, 11, 1, CAST(N'2019-08-12T21:26:43.610' AS DateTime), CAST(N'2019-08-12T21:26:43.610' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (15, N'Etna', 30, 10, 1, CAST(N'2019-08-12T21:27:30.843' AS DateTime), CAST(N'2019-08-12T21:27:30.843' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (16, N'Appennini', 5, 6, 1, CAST(N'2019-08-16T20:00:44.000' AS DateTime), CAST(N'2019-08-16T20:00:44.000' AS DateTime))
INSERT [dbo].[Room] ([Id], [Name], [SeatsNumber], [BuildingId], [IsAvailable], [CreatedOn], [UpdatedOn]) VALUES (18, N'Sala non disponibile', 5, 2, 0, CAST(N'2019-08-16T23:20:49.770' AS DateTime), CAST(N'2019-08-16T23:20:49.770' AS DateTime))
SET IDENTITY_INSERT [dbo].[Room] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_UniqueBuildingName]    Script Date: 29/08/2019 19:24:42 ******/
ALTER TABLE [dbo].[Building] ADD  CONSTRAINT [AK_UniqueBuildingName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_UniqueEmailAddress]    Script Date: 29/08/2019 19:24:42 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [AK_UniqueEmailAddress] UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_UniqueEmployeeUsername]    Script Date: 29/08/2019 19:24:42 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [AK_UniqueEmployeeUsername] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_UniqueRoomName]    Script Date: 29/08/2019 19:24:42 ******/
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [AK_UniqueRoomName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Booking] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Building] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Building] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Employee]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Room]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Building] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Building] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Building]
GO
/****** Object:  Trigger [dbo].[tgr_bookingUpdatedOn]    Script Date: 29/08/2019 19:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tgr_bookingUpdatedOn]
ON [dbo].[Booking]
AFTER UPDATE AS
  UPDATE dbo.Booking
  SET UpdatedOn = GETDATE()
  WHERE Id IN (SELECT DISTINCT Id FROM Inserted)
GO
ALTER TABLE [dbo].[Booking] ENABLE TRIGGER [tgr_bookingUpdatedOn]
GO
/****** Object:  Trigger [dbo].[tgr_buildingUpdatedOn]    Script Date: 29/08/2019 19:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tgr_buildingUpdatedOn]
ON [dbo].[Building]
AFTER UPDATE AS
  UPDATE dbo.Building
  SET UpdatedOn = GETDATE()
  WHERE Id IN (SELECT DISTINCT Id FROM Inserted)
GO
ALTER TABLE [dbo].[Building] ENABLE TRIGGER [tgr_buildingUpdatedOn]
GO
/****** Object:  Trigger [dbo].[tgr_employeeUpdatedOn]    Script Date: 29/08/2019 19:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tgr_employeeUpdatedOn]
ON [dbo].[Employee]
AFTER UPDATE AS
  UPDATE dbo.Employee
  SET UpdatedOn = GETDATE()
  WHERE Id IN (SELECT DISTINCT Id FROM Inserted)
GO
ALTER TABLE [dbo].[Employee] ENABLE TRIGGER [tgr_employeeUpdatedOn]
GO
/****** Object:  Trigger [dbo].[tgr_roomUpdatedOn]    Script Date: 29/08/2019 19:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tgr_roomUpdatedOn]
ON [dbo].[Room]
AFTER UPDATE AS
  UPDATE dbo.Room
  SET UpdatedOn = GETDATE()
  WHERE Id IN (SELECT DISTINCT Id FROM Inserted)
GO
ALTER TABLE [dbo].[Room] ENABLE TRIGGER [tgr_roomUpdatedOn]
GO
USE [master]
GO
ALTER DATABASE [BookingRooms] SET  READ_WRITE 
GO
