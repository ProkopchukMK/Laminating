using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.Resources
{
    public static class ScriptDBClass
    {
        // CONTAINMENT = NONE
// ON  PRIMARY 
//( NAME = N'Laminatsia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\Laminatsia.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
// LOG ON 
//( NAME = N'Laminatsia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\Laminatsia_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)

        static string script = @"
CREATE DATABASE [Laminatsia]

ALTER DATABASE [Laminatsia] SET COMPATIBILITY_LEVEL = 110;

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Laminatsia].[dbo].[sp_fulltext_database] @action = 'enable'
end

ALTER DATABASE [Laminatsia] SET ANSI_NULL_DEFAULT OFF 

ALTER DATABASE [Laminatsia] SET ANSI_NULLS OFF 

ALTER DATABASE [Laminatsia] SET ANSI_PADDING OFF 

ALTER DATABASE [Laminatsia] SET ANSI_WARNINGS OFF 

ALTER DATABASE [Laminatsia] SET ARITHABORT OFF 

ALTER DATABASE [Laminatsia] SET AUTO_CLOSE OFF 

ALTER DATABASE [Laminatsia] SET AUTO_SHRINK OFF 

ALTER DATABASE [Laminatsia] SET AUTO_UPDATE_STATISTICS ON 

ALTER DATABASE [Laminatsia] SET CURSOR_CLOSE_ON_COMMIT OFF 

ALTER DATABASE [Laminatsia] SET CURSOR_DEFAULT  GLOBAL 

ALTER DATABASE [Laminatsia] SET CONCAT_NULL_YIELDS_NULL OFF 

ALTER DATABASE [Laminatsia] SET NUMERIC_ROUNDABORT OFF 

ALTER DATABASE [Laminatsia] SET QUOTED_IDENTIFIER OFF 

ALTER DATABASE [Laminatsia] SET RECURSIVE_TRIGGERS OFF 

ALTER DATABASE [Laminatsia] SET  DISABLE_BROKER 

ALTER DATABASE [Laminatsia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 

ALTER DATABASE [Laminatsia] SET DATE_CORRELATION_OPTIMIZATION OFF 

ALTER DATABASE [Laminatsia] SET TRUSTWORTHY OFF 

ALTER DATABASE [Laminatsia] SET ALLOW_SNAPSHOT_ISOLATION OFF 

ALTER DATABASE [Laminatsia] SET PARAMETERIZATION SIMPLE 

ALTER DATABASE [Laminatsia] SET READ_COMMITTED_SNAPSHOT OFF 

ALTER DATABASE [Laminatsia] SET HONOR_BROKER_PRIORITY OFF 

ALTER DATABASE [Laminatsia] SET RECOVERY SIMPLE 

ALTER DATABASE [Laminatsia] SET  MULTI_USER 

ALTER DATABASE [Laminatsia] SET PAGE_VERIFY CHECKSUM  

ALTER DATABASE [Laminatsia] SET DB_CHAINING OFF 

ALTER DATABASE [Laminatsia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 

ALTER DATABASE [Laminatsia] SET TARGET_RECOVERY_TIME = 0 SECONDS 

USE [Laminatsia]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Archive](
	[ID] [int] NOT NULL,
	[DateComming] [datetime] NOT NULL,
	[Profile] [nvarchar](50) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[Dealer] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[Counts] [tinyint] NOT NULL,
	[Colour] [nvarchar](50) NOT NULL,
	[DateToWork] [datetime] NOT NULL,
	[StatusProfile] [bit] NOT NULL,
	[DateReady] [datetime] NOT NULL,
	[StatusGoods] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[DataTimeChange] [datetime] NOT NULL
) ON [PRIMARY]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ColourGoods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateComming] [datetime] NOT NULL,
	[Profile_ID] [int] NOT NULL,
	[Dealer_ID] [int] NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[Counts] [tinyint] NOT NULL,
	[Colour_ID] [int] NOT NULL,
	[DateToWork] [datetime] NOT NULL,
	[StatusProfile] [bit] NOT NULL,
	[DateReady] [datetime] NOT NULL,
	[StatusGoods] [bit] NOT NULL,
 CONSTRAINT [PK_ColourGoods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[ColourProfile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Colour] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ColourProfile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Dealer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DealerName] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dealer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Profile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameProfile] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](10) NOT NULL,
	[UserPassword] [nchar](100) NOT NULL,
	[UserPC] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_ColourProfile] FOREIGN KEY([Colour_ID])
REFERENCES [dbo].[ColourProfile] ([ID])

ALTER TABLE [dbo].[ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_ColourProfile]

ALTER TABLE [dbo].[ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_Dealer] FOREIGN KEY([Dealer_ID])
REFERENCES [dbo].[Dealer] ([ID])

ALTER TABLE [dbo].[ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_Dealer]

ALTER TABLE [dbo].[ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_Profile] FOREIGN KEY([Profile_ID])
REFERENCES [dbo].[Profile] ([ID])

ALTER TABLE [dbo].[ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_Profile]

USE [master]

ALTER DATABASE [Laminatsia] SET  READ_WRITE 
";
        public static string GetScriptToCreateDB
        {
            get
            {
                return script;
            }
        }

    }
}
