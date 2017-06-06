USE [master]
GO
/****** Object:  Database [ManaCena]    Script Date: 6/6/2017 11:50:42 AM ******/
CREATE DATABASE [ManaCena]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ManaCena', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ManaCena.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ManaCena_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ManaCena_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ManaCena] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ManaCena].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ManaCena] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ManaCena] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ManaCena] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ManaCena] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ManaCena] SET ARITHABORT OFF 
GO
ALTER DATABASE [ManaCena] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ManaCena] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ManaCena] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ManaCena] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ManaCena] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ManaCena] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ManaCena] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ManaCena] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ManaCena] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ManaCena] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ManaCena] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ManaCena] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ManaCena] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ManaCena] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ManaCena] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ManaCena] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ManaCena] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ManaCena] SET RECOVERY FULL 
GO
ALTER DATABASE [ManaCena] SET  MULTI_USER 
GO
ALTER DATABASE [ManaCena] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ManaCena] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ManaCena] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ManaCena] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ManaCena] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ManaCena', N'ON'
GO
USE [ManaCena]
GO
/****** Object:  Table [dbo].[Cathegory]    Script Date: 6/6/2017 11:50:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cathegory](
	[Id] [int] NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[CathegoryTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Cathegory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CathegoryType]    Script Date: 6/6/2017 11:50:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CathegoryType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CathegoryType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 6/6/2017 11:50:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SellerId] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/6/2017 11:50:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SellerId] [int] NOT NULL,
	[CathegoryId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[OriginalPrice] [decimal](18, 2) NULL,
	[DiscountPrice] [decimal](18, 2) NULL,
	[DiscountPercentage] [decimal](18, 2) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seller]    Script Date: 6/6/2017 11:50:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seller](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cathegory]  WITH CHECK ADD  CONSTRAINT [FK_Cathegory_CathegoryType] FOREIGN KEY([Id])
REFERENCES [dbo].[CathegoryType] ([Id])
GO
ALTER TABLE [dbo].[Cathegory] CHECK CONSTRAINT [FK_Cathegory_CathegoryType]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Seller] FOREIGN KEY([SellerId])
REFERENCES [dbo].[Seller] ([Id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Seller]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Cathegory] FOREIGN KEY([CathegoryId])
REFERENCES [dbo].[Cathegory] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Cathegory]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Seller] FOREIGN KEY([Id])
REFERENCES [dbo].[Seller] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Seller]
GO
USE [master]
GO
ALTER DATABASE [ManaCena] SET  READ_WRITE 
GO
