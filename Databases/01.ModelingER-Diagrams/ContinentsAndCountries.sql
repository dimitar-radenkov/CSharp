USE [master]
GO
/****** Object:  Database [Homework]    Script Date: 14.7.2013 г. 20:28:13 ******/
CREATE DATABASE [Homework]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Homework', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Homework.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Homework_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Homework_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Homework] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Homework].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Homework] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Homework] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Homework] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Homework] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Homework] SET ARITHABORT OFF 
GO
ALTER DATABASE [Homework] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Homework] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Homework] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Homework] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Homework] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Homework] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Homework] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Homework] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Homework] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Homework] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Homework] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Homework] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Homework] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Homework] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Homework] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Homework] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Homework] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Homework] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Homework] SET RECOVERY FULL 
GO
ALTER DATABASE [Homework] SET  MULTI_USER 
GO
ALTER DATABASE [Homework] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Homework] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Homework] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Homework] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Homework', N'ON'
GO
USE [Homework]
GO
/****** Object:  User [testUser]    Script Date: 14.7.2013 г. 20:28:13 ******/
CREATE USER [testUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 14.7.2013 г. 20:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] NOT NULL,
	[addressText] [nchar](50) NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 14.7.2013 г. 20:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] NOT NULL,
	[name] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 14.7.2013 г. 20:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] NOT NULL,
	[name] [nchar](30) NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 14.7.2013 г. 20:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] NOT NULL,
	[firstName] [nchar](25) NULL,
	[lastName] [nchar](25) NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 14.7.2013 г. 20:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] NOT NULL,
	[name] [nchar](30) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Address] ([id], [addressText], [town_id]) VALUES (1, N'bul. Bulgaria 49A                                 ', 1)
INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Europe                        ')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'Asia                          ')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'North America                 ')
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (1, N'Bulgaria                      ', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (2, N'Romania                       ', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (3, N'China                         ', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (4, N'Canada                        ', 3)
INSERT [dbo].[Person] ([id], [firstName], [lastName], [address_id]) VALUES (1, N'Dimitar                  ', N'Radenkov                 ', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (1, N'Sofia                         ', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Plovdiv                       ', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (3, N'Beijing                       ', 2)
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [Homework] SET  READ_WRITE 
GO
