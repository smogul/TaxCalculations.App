USE [Db_TaxCalculation]
GO
-------------------------Database script-------------------------------------

USE [master]
GO

/****** Object:  Database [Db_TaxCalculation]    Script Date: 2023/09/05 06:55:40 ******/
CREATE DATABASE [Db_TaxCalculation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Db_TaxCalculation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Db_TaxCalculation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Db_TaxCalculation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Db_TaxCalculation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Db_TaxCalculation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Db_TaxCalculation] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET ARITHABORT OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Db_TaxCalculation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Db_TaxCalculation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Db_TaxCalculation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Db_TaxCalculation] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET RECOVERY FULL 
GO

ALTER DATABASE [Db_TaxCalculation] SET  MULTI_USER 
GO

ALTER DATABASE [Db_TaxCalculation] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Db_TaxCalculation] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Db_TaxCalculation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Db_TaxCalculation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Db_TaxCalculation] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Db_TaxCalculation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Db_TaxCalculation] SET QUERY_STORE = ON
GO

ALTER DATABASE [Db_TaxCalculation] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [Db_TaxCalculation] SET  READ_WRITE 
GO


-------------------------Tables Script---------------------------------------

USE [Db_TaxCalculation]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 2023/09/05 06:57:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Department] [varchar](30) NULL,
	[Position] [varchar](30) NULL,
	[StartDate] [varchar](30) NULL,
	[SalaryAmount] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Db_TaxCalculation]
GO

/****** Object:  Table [dbo].[PostalCodes]    Script Date: 2023/09/05 06:57:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PostalCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostalCode] [varchar](30) NULL,
	[TaxCalculationType] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Db_TaxCalculation]
GO

/****** Object:  Table [dbo].[ProgressiveTax]    Script Date: 2023/09/05 06:58:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProgressiveTax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [int] NULL,
	[FromAmount] [float] NULL,
	[ToAmount] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Db_TaxCalculation]
GO

/****** Object:  Table [dbo].[TaxCalculatorResults]    Script Date: 2023/09/05 06:58:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaxCalculatorResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostalCode] [varchar](30) NULL,
	[EnteredAmount] [float] NULL,
	[CalculatedAmount] [float] NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




-------------------------S E E D  D A T A------------------------------------

INSERT INTO [dbo].[PostalCodes]
           ([PostalCode]
           ,[TaxCalculationType])
     VALUES('7441','Progressive')

	 INSERT INTO [dbo].[PostalCodes]
           ([PostalCode]
           ,[TaxCalculationType])
     VALUES('A100','Flat Value')

INSERT INTO [dbo].[PostalCodes]
           ([PostalCode]
           ,[TaxCalculationType])
     VALUES('7000','Flat rate')

INSERT INTO [dbo].[PostalCodes]
           ([PostalCode]
           ,[TaxCalculationType])
     VALUES('1000','Progressive')

GO

INSERT INTO [dbo].[Employee](
	 
      [FirstName]
      ,[LastName]
      ,[Department]
      ,[Position]
      ,[StartDate]
      ,[SalaryAmount])
	  VALUES('tebogo','xogale','Marketing','Engineer','2023/04/01','8350');

	  /****** Script for SelectTopNRows command from SSMS  ******/
INSERT INTO [dbo].[Employee](
	 
      [FirstName]
      ,[LastName]
      ,[Department]
      ,[Position]
      ,[StartDate]
      ,[SalaryAmount])
	  VALUES('ganele','kogale','United','SE','2023/08/01','33950');

/****** Script for SelectTopNRows command from SSMS  ******/
INSERT INTO [dbo].[Employee](
	 
      [FirstName]
      ,[LastName]
      ,[Department]
      ,[Position]
      ,[StartDate]
      ,[SalaryAmount])
	  VALUES('canele','ale','Cora','HR','2023/06/01','82250');

/****** Script for SelectTopNRows command from SSMS  ******/
INSERT INTO [dbo].[Employee](
	 
      [FirstName]
      ,[LastName]
      ,[Department]
      ,[Position]
      ,[StartDate]
      ,[SalaryAmount])
	  VALUES('vanele','ogale','Samaza','BA','2023/02/01','171550');

/****** Script for SelectTopNRows command from SSMS  ******/
INSERT INTO [dbo].[Employee](
	 
      [FirstName]
      ,[LastName]
      ,[Department]
      ,[Position]
      ,[StartDate]
      ,[SalaryAmount])
	  VALUES('danele','mogal','PMO','Analyst','2023/12/01','372950');

--------------------------------

INSERT INTO [dbo].[ProgressiveTax]
           ([Rate]
           ,[FromAmount]
           ,[ToAmount])
     VALUES(10, 0, 8350.00)
GO
INSERT INTO [dbo].[ProgressiveTax]
           ([Rate]
           ,[FromAmount]
           ,[ToAmount])
     VALUES(15, 8351, 33950.00)
GO

INSERT INTO [dbo].[ProgressiveTax]
           ([Rate]
           ,[FromAmount]
           ,[ToAmount])
     VALUES(25, 33951, 82250.00)
GO

INSERT INTO [dbo].[ProgressiveTax]
           ([Rate]
           ,[FromAmount]
           ,[ToAmount])
     VALUES(28, 82251, 171550.00)
GO

INSERT INTO [dbo].[ProgressiveTax]
           ([Rate]
           ,[FromAmount]
           ,[ToAmount])
     VALUES(33, 171551, 372950.00)
GO

INSERT INTO [dbo].[ProgressiveTax]
           ([Rate]
           ,[FromAmount]
           ,[ToAmount])
     VALUES(35, 372950, 1000000.00)
	 
-------------------------------
INSERT INTO [dbo].[TaxCalculatorResults]
           ([PostalCode]
           ,[EnteredAmount]
           ,[CalculatedAmount]
           ,[Date])
     VALUES(7441, 85000, 77000, '2023-09-05 06:32:24.033')