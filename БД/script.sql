USE [master]
GO
/****** Object:  Database [Michelin]    Script Date: 15.05.2022 19:17:19 ******/
CREATE DATABASE [Michelin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Michelin', FILENAME = N'F:\Программирование\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\Michelin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Michelin_log', FILENAME = N'F:\Программирование\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\Michelin_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Michelin] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Michelin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Michelin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Michelin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Michelin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Michelin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Michelin] SET ARITHABORT OFF 
GO
ALTER DATABASE [Michelin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Michelin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Michelin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Michelin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Michelin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Michelin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Michelin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Michelin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Michelin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Michelin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Michelin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Michelin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Michelin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Michelin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Michelin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Michelin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Michelin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Michelin] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Michelin] SET  MULTI_USER 
GO
ALTER DATABASE [Michelin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Michelin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Michelin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Michelin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Michelin] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Michelin] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Michelin] SET QUERY_STORE = OFF
GO
USE [Michelin]
GO
/****** Object:  Table [dbo].[ClientFromOrganization]    Script Date: 15.05.2022 19:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientFromOrganization](
	[ID_Client] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Middlename] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[id_Organization] [int] NOT NULL,
	[Image] [nvarchar](50) NULL,
	[FIO]  AS (((([Surname]+' ')+[Firstname])+' ')+[Middlename]),
 CONSTRAINT [PK_ClientFromOrganization] PRIMARY KEY CLUSTERED 
(
	[ID_Client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 15.05.2022 19:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID_Order] [int] IDENTITY(1,1) NOT NULL,
	[id_Product] [int] NOT NULL,
	[id_Client] [int] NOT NULL,
	[CountOrder] [int] NOT NULL,
	[SumOrder] [int] NOT NULL,
	[DateOrder] [date] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 15.05.2022 19:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[ID_Organization] [int] IDENTITY(1,1) NOT NULL,
	[id_Registration] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[ID_Organization] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 15.05.2022 19:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID_Product] [int] IDENTITY(1,1) NOT NULL,
	[id_ProductType] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Image] [nvarchar](50) NULL,
	[CountInStrock] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 15.05.2022 19:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ID_ProductType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Wear] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[ID_ProductType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 15.05.2022 19:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[ID_Registration] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[ID_Registration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClientFromOrganization] ON 

INSERT [dbo].[ClientFromOrganization] ([ID_Client], [Surname], [Firstname], [Middlename], [Phone], [Email], [id_Organization], [Image]) VALUES (1, N'Смирнов ', N'Данила', N'Васильевич', N'+7854846948', N'SmirnovTransit@Ozon.ru', 3, NULL)
INSERT [dbo].[ClientFromOrganization] ([ID_Client], [Surname], [Firstname], [Middlename], [Phone], [Email], [id_Organization], [Image]) VALUES (2, N'Кисилёв', N'Иван', N'Иванович', N'+7854518615', N'KisilevTransit@Sdeck.ru', 4, NULL)
INSERT [dbo].[ClientFromOrganization] ([ID_Client], [Surname], [Firstname], [Middlename], [Phone], [Email], [id_Organization], [Image]) VALUES (4, N'Матвеева', N'Светлана', N'Евгеньевна', N'+7186811258', N'Matveeva@PochtaRus.ru', 5, NULL)
INSERT [dbo].[ClientFromOrganization] ([ID_Client], [Surname], [Firstname], [Middlename], [Phone], [Email], [id_Organization], [Image]) VALUES (5, N'Листова', N'Татьяна', N'Генадьевна', N'+7484684864', N'Listova@DealLine.ru', 6, NULL)
INSERT [dbo].[ClientFromOrganization] ([ID_Client], [Surname], [Firstname], [Middlename], [Phone], [Email], [id_Organization], [Image]) VALUES (7, N'Романов', N'Пётр', N'Александрович', N'+7858511284', N'Velikiy@PEC.ru', 8, NULL)
SET IDENTITY_INSERT [dbo].[ClientFromOrganization] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (3, 2, 7, 10, 105000, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (4, 2, 2, 15, 157500, CAST(N'2022-01-02' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (9, 4, 5, 20, 234000, CAST(N'2022-01-03' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (11, 4, 7, 4, 46800, CAST(N'2022-01-04' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (12, 4, 1, 18, 210600, CAST(N'2022-01-05' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (14, 5, 5, 15, 217500, CAST(N'2022-01-06' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (15, 5, 4, 75, 1087500, CAST(N'2022-01-07' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (16, 7, 2, 12, 152400, CAST(N'2022-01-08' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (17, 7, 7, 5, 63500, CAST(N'2022-01-09' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (20, 10, 4, 10, 176000, CAST(N'2022-01-10' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (23, 12, 1, 15, 283500, CAST(N'2022-01-11' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (25, 13, 5, 25, 500000, CAST(N'2022-01-12' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (27, 14, 7, 12, 201600, CAST(N'2022-01-13' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (28, 2, 4, 111, 1165500, CAST(N'2022-05-15' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (29, 4, 2, 33, 386100, CAST(N'2022-05-15' AS Date))
INSERT [dbo].[Order] ([ID_Order], [id_Product], [id_Client], [CountOrder], [SumOrder], [DateOrder]) VALUES (31, 14, 5, 10, 168000, CAST(N'2022-05-15' AS Date))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([ID_Organization], [id_Registration], [Name], [Email]) VALUES (3, 1, N'Ozon', N'ozon@transit.ru')
INSERT [dbo].[Organization] ([ID_Organization], [id_Registration], [Name], [Email]) VALUES (4, 1, N'СДЭК', N'Sdek@pochta.ru')
INSERT [dbo].[Organization] ([ID_Organization], [id_Registration], [Name], [Email]) VALUES (5, 4, N'Почта росии', N'PochtaRus@pochta.ru')
INSERT [dbo].[Organization] ([ID_Organization], [id_Registration], [Name], [Email]) VALUES (6, 1, N'Деловые Линии', N'Deal@Line.ru')
INSERT [dbo].[Organization] ([ID_Organization], [id_Registration], [Name], [Email]) VALUES (8, 1, N'ПЭК', N'Peck@transit.ru')
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID_Product], [id_ProductType], [Name], [Category], [Price], [Image], [CountInStrock]) VALUES (2, 3, N'Pilot sport 5', N'0x1', 10500, NULL, 50)
INSERT [dbo].[Product] ([ID_Product], [id_ProductType], [Name], [Category], [Price], [Image], [CountInStrock]) VALUES (4, 3, N'Pilot sport 4 SUV', N'0x2', 11700, NULL, 25)
INSERT [dbo].[Product] ([ID_Product], [id_ProductType], [Name], [Category], [Price], [Image], [CountInStrock]) VALUES (5, 3, N'PRIMACY 4+', N'0x3', 14500, NULL, 17)
INSERT [dbo].[Product] ([ID_Product], [id_ProductType], [Name], [Category], [Price], [Image], [CountInStrock]) VALUES (7, 3, N'ENERGY XM2+', N'1x1', 12700, NULL, 20)
INSERT [dbo].[Product] ([ID_Product], [id_ProductType], [Name], [Category], [Price], [Image], [CountInStrock]) VALUES (10, 2, N'X-Ice North 4', N'2x1', 17600, NULL, 100)
INSERT [dbo].[Product] ([ID_Product], [id_ProductType], [Name], [Category], [Price], [Image], [CountInStrock]) VALUES (12, 2, N'X-ICE SNOW', N'2x2', 18900, NULL, 80)
INSERT [dbo].[Product] ([ID_Product], [id_ProductType], [Name], [Category], [Price], [Image], [CountInStrock]) VALUES (13, 2, N'X-Ice 3', N'2x3', 20000, NULL, 50)
INSERT [dbo].[Product] ([ID_Product], [id_ProductType], [Name], [Category], [Price], [Image], [CountInStrock]) VALUES (14, 2, N'Pilot Alpin 5 SUV', N'3x1', 16800, NULL, 20)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([ID_ProductType], [Name], [Wear]) VALUES (2, N'Зима', CAST(0.05 AS Decimal(18, 2)))
INSERT [dbo].[ProductType] ([ID_ProductType], [Name], [Wear]) VALUES (3, N'Лето', CAST(0.02 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[Registration] ON 

INSERT [dbo].[Registration] ([ID_Registration], [Name]) VALUES (1, N'ООО')
INSERT [dbo].[Registration] ([ID_Registration], [Name]) VALUES (2, N'ИП')
INSERT [dbo].[Registration] ([ID_Registration], [Name]) VALUES (3, N'ОАО')
INSERT [dbo].[Registration] ([ID_Registration], [Name]) VALUES (4, N'ОА')
INSERT [dbo].[Registration] ([ID_Registration], [Name]) VALUES (5, N'ЗАП')
INSERT [dbo].[Registration] ([ID_Registration], [Name]) VALUES (6, N'ЧП')
SET IDENTITY_INSERT [dbo].[Registration] OFF
GO
ALTER TABLE [dbo].[ClientFromOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ClientFromOrganization_Organization] FOREIGN KEY([id_Organization])
REFERENCES [dbo].[Organization] ([ID_Organization])
GO
ALTER TABLE [dbo].[ClientFromOrganization] CHECK CONSTRAINT [FK_ClientFromOrganization_Organization]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_ClientFromOrganization] FOREIGN KEY([id_Client])
REFERENCES [dbo].[ClientFromOrganization] ([ID_Client])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_ClientFromOrganization]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([id_Product])
REFERENCES [dbo].[Product] ([ID_Product])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Registration] FOREIGN KEY([id_Registration])
REFERENCES [dbo].[Registration] ([ID_Registration])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_Registration]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([id_ProductType])
REFERENCES [dbo].[ProductType] ([ID_ProductType])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
USE [master]
GO
ALTER DATABASE [Michelin] SET  READ_WRITE 
GO
