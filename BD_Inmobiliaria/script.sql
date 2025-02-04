USE [master]
GO
/****** Object:  Database [InmueblesDB]    Script Date: 2/10/2024 12:17:54 ******/
CREATE DATABASE [InmueblesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InmueblesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InmueblesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InmueblesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InmueblesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [InmueblesDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InmueblesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InmueblesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InmueblesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InmueblesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InmueblesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InmueblesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InmueblesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InmueblesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InmueblesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InmueblesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InmueblesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InmueblesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InmueblesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InmueblesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InmueblesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InmueblesDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InmueblesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InmueblesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InmueblesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InmueblesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InmueblesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InmueblesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InmueblesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InmueblesDB] SET RECOVERY FULL 
GO
ALTER DATABASE [InmueblesDB] SET  MULTI_USER 
GO
ALTER DATABASE [InmueblesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InmueblesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InmueblesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InmueblesDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InmueblesDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InmueblesDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'InmueblesDB', N'ON'
GO
ALTER DATABASE [InmueblesDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [InmueblesDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [InmueblesDB]
GO
/****** Object:  Table [dbo].[Inmuebles]    Script Date: 2/10/2024 12:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inmuebles](
	[InmuebleId] [int] IDENTITY(1,1) NOT NULL,
	[TipoInmueble] [varchar](50) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[CantidadHabitaciones] [int] NOT NULL,
	[CantidadBaños] [int] NOT NULL,
	[MetrosCuadrados] [decimal](10, 2) NOT NULL,
	[Precio] [decimal](15, 2) NOT NULL,
	[TieneGaraje] [bit] NOT NULL,
	[Descripcion] [text] NULL,
	[FechaConstruccion] [date] NULL,
	[Disponible] [bit] NOT NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[InmuebleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/10/2024 12:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inmuebles] ON 

INSERT [dbo].[Inmuebles] ([InmuebleId], [TipoInmueble], [Direccion], [Ciudad], [CantidadHabitaciones], [CantidadBaños], [MetrosCuadrados], [Precio], [TieneGaraje], [Descripcion], [FechaConstruccion], [Disponible], [FechaRegistro]) VALUES (1, N'Departamento', N'Av. José Larco 123', N'Lima', 2, 2, CAST(75.00 AS Decimal(10, 2)), CAST(250000.00 AS Decimal(15, 2)), 1, N'Departamento en el centro de Lima, cerca de restaurantes y tiendas.', CAST(N'2010-05-15' AS Date), 1, CAST(N'2024-10-01T17:42:07.237' AS DateTime))
INSERT [dbo].[Inmuebles] ([InmuebleId], [TipoInmueble], [Direccion], [Ciudad], [CantidadHabitaciones], [CantidadBaños], [MetrosCuadrados], [Precio], [TieneGaraje], [Descripcion], [FechaConstruccion], [Disponible], [FechaRegistro]) VALUES (2, N'Casa', N'Calle Los Olivos 456', N'Arequipa', 3, 2, CAST(120.00 AS Decimal(10, 2)), CAST(350000.00 AS Decimal(15, 2)), 1, N'Casa familiar en una zona tranquila, ideal para niños.', CAST(N'2015-08-20' AS Date), 1, CAST(N'2024-10-01T17:42:07.237' AS DateTime))
INSERT [dbo].[Inmuebles] ([InmuebleId], [TipoInmueble], [Direccion], [Ciudad], [CantidadHabitaciones], [CantidadBaños], [MetrosCuadrados], [Precio], [TieneGaraje], [Descripcion], [FechaConstruccion], [Disponible], [FechaRegistro]) VALUES (3, N'Departamento', N'Jr. Santa Rosa 789', N'Trujillo', 1, 1, CAST(50.00 AS Decimal(10, 2)), CAST(120000.00 AS Decimal(15, 2)), 0, N'Departamento pequeño, ideal para estudiantes.', CAST(N'2018-03-10' AS Date), 1, CAST(N'2024-10-01T17:42:07.237' AS DateTime))
INSERT [dbo].[Inmuebles] ([InmuebleId], [TipoInmueble], [Direccion], [Ciudad], [CantidadHabitaciones], [CantidadBaños], [MetrosCuadrados], [Precio], [TieneGaraje], [Descripcion], [FechaConstruccion], [Disponible], [FechaRegistro]) VALUES (4, N'Casa', N'Av. La Marina 101', N'Lima', 4, 3, CAST(200.00 AS Decimal(10, 2)), CAST(800000.00 AS Decimal(15, 2)), 1, N'Casa espaciosa con jardín y piscina.', CAST(N'2012-06-30' AS Date), 1, CAST(N'2024-10-01T17:42:07.237' AS DateTime))
INSERT [dbo].[Inmuebles] ([InmuebleId], [TipoInmueble], [Direccion], [Ciudad], [CantidadHabitaciones], [CantidadBaños], [MetrosCuadrados], [Precio], [TieneGaraje], [Descripcion], [FechaConstruccion], [Disponible], [FechaRegistro]) VALUES (5, N'Departamento', N'Calle Los Héroes 202', N'Lima', 3, 2, CAST(90.00 AS Decimal(10, 2)), CAST(300000.00 AS Decimal(15, 2)), 1, N'Departamento moderno en una buena ubicación.', CAST(N'2019-12-01' AS Date), 1, CAST(N'2024-10-01T17:42:07.237' AS DateTime))
SET IDENTITY_INSERT [dbo].[Inmuebles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (1, N'Robin', N'Anticona', N'RANTICONA', N'123456')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (2, N'Juan', N'Pérez', N'JUANP', N'123456')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (3, N'María', N'Gómez', N'MARIAG', N'123456')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (4, N'Pedro', N'Lopez', N'PEDROL', N'123456')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (5, N'Ana', N'Martínez', N'ANAM', N'123456')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (6, N'Carlos', N'Sánchez', N'CARLOS', N'123456')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (7, N'Cayetano', N'Heredia', N'Admin', N'123456')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Inmuebles] ADD  DEFAULT ((0)) FOR [TieneGaraje]
GO
ALTER TABLE [dbo].[Inmuebles] ADD  DEFAULT ((1)) FOR [Disponible]
GO
ALTER TABLE [dbo].[Inmuebles] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
/****** Object:  StoredProcedure [dbo].[sp_Inmueble_Delete]    Script Date: 2/10/2024 12:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para eliminar un inmueble
CREATE PROCEDURE [dbo].[sp_Inmueble_Delete]
    @InmuebleId INT
AS
BEGIN
    DELETE FROM Inmuebles
    WHERE InmuebleId = @InmuebleId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Inmueble_GetAll]    Script Date: 2/10/2024 12:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para listar todos los inmuebles
CREATE PROCEDURE [dbo].[sp_Inmueble_GetAll]
AS
BEGIN
    SELECT * FROM Inmuebles;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Inmueble_GetById]    Script Date: 2/10/2024 12:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para obtener un inmueble por su ID
CREATE PROCEDURE [dbo].[sp_Inmueble_GetById]
    @InmuebleId INT
AS
BEGIN
    SELECT * FROM Inmuebles
    WHERE InmuebleId = @InmuebleId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Inmueble_Insert]    Script Date: 2/10/2024 12:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inmueble_Insert]
    @TipoInmueble NVARCHAR(50),
    @Direccion NVARCHAR(200),
    @Ciudad NVARCHAR(100),
    @CantidadHabitaciones INT,
    @CantidadBaños INT,
    @MetrosCuadrados DECIMAL(10, 2),
    @Precio DECIMAL(18, 2),
    @TieneGaraje BIT,
    @Descripcion NVARCHAR(MAX),
    @FechaConstruccion DATE,
    @Disponible BIT
AS
BEGIN
    INSERT INTO Inmuebles (TipoInmueble, Direccion, Ciudad, CantidadHabitaciones, CantidadBaños, MetrosCuadrados, Precio, TieneGaraje, Descripcion, FechaConstruccion, Disponible)
    VALUES (@TipoInmueble, @Direccion, @Ciudad, @CantidadHabitaciones, @CantidadBaños, @MetrosCuadrados, @Precio, @TieneGaraje, @Descripcion, @FechaConstruccion, @Disponible);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Inmueble_Update]    Script Date: 2/10/2024 12:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para actualizar un inmueble
CREATE PROCEDURE [dbo].[sp_Inmueble_Update]
    @InmuebleId INT,
    @TipoInmueble NVARCHAR(50),
    @Direccion NVARCHAR(200),
    @Ciudad NVARCHAR(100),
    @CantidadHabitaciones INT,
    @CantidadBaños INT,
    @MetrosCuadrados DECIMAL(10, 2),
    @Precio DECIMAL(18, 2),
    @TieneGaraje BIT,
    @Descripcion NVARCHAR(MAX),
    @FechaConstruccion DATE,
    @Disponible BIT
AS
BEGIN
    UPDATE Inmuebles
    SET TipoInmueble = @TipoInmueble,
        Direccion = @Direccion,
        Ciudad = @Ciudad,
        CantidadHabitaciones = @CantidadHabitaciones,
        CantidadBaños = @CantidadBaños,
        MetrosCuadrados = @MetrosCuadrados,
        Precio = @Precio,
        TieneGaraje = @TieneGaraje,
        Descripcion = @Descripcion,
        FechaConstruccion = @FechaConstruccion,
        Disponible = @Disponible
    WHERE InmuebleId = @InmuebleId;
END;
GO
/****** Object:  StoredProcedure [dbo].[UsersGetByUserAndPassword]    Script Date: 2/10/2024 12:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersGetByUserAndPassword]
(
    @UserName varchar(50),
    @Password varchar(50)
)
AS
BEGIN
    SELECT UserId, FirstName, LastName, UserName, NULL as Password
    FROM Users
    WHERE UserName = @UserName and Password = @Password
END
GO
USE [master]
GO
ALTER DATABASE [InmueblesDB] SET  READ_WRITE 
GO
