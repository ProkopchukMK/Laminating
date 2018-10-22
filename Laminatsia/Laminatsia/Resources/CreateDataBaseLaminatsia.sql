USE [Laminatsia];
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

CREATE TABLE [Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];
INSERT [dbo].[Users] (UserName, UserPassword, Role) VALUES ('Адміністратор', '1', 'Адміністратори');
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

CREATE TABLE [Profile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameProfile] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

CREATE TABLE [Archive](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_ColourGoods] [int] NOT NULL,
	[DateComing] [datetime] NOT NULL,
	[Profile] [nvarchar](50) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[Dealer] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[Counts] [tinyint] NOT NULL,
	[Colour] [nvarchar](50) NOT NULL,
	[DateToWork] [datetime] NOT NULL,
	[StatusProfile] [nvarchar](50) NOT NULL,
	[DateReady] [datetime] NOT NULL,
	[StatusGoods] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[DataTimeChange] [datetime] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Archive] PRIMARY KEY CLUSTERED 
(	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

CREATE TABLE [Dealer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DealerName] [nvarchar](100) NULL,
	[City] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Dealer] PRIMARY KEY CLUSTERED 
(	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

CREATE TABLE [ColourProfile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Colour] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ColourProfile] PRIMARY KEY CLUSTERED 
(	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

CREATE TABLE [ColourGoods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateComing] [datetime] NOT NULL,
	[Profile_ID] [int] NOT NULL,
	[Dealer_ID] [int] NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[Counts] [tinyint] NOT NULL,
	[Colour_ID] [int] NOT NULL,
	[DateToWork] [datetime] NOT NULL,
	[StatusProfile] [bit] NOT NULL,
	[DateReady] [datetime] NOT NULL,
	[StatusGoods] [bit] NOT NULL,
	[DateRemove] [datetime] NULL,
 CONSTRAINT [PK_ColourGoods] PRIMARY KEY CLUSTERED 
(	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];
ALTER TABLE [ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_ColourProfile] FOREIGN KEY([Colour_ID])
REFERENCES [ColourProfile] ([ID]);
ALTER TABLE [ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_ColourProfile];
ALTER TABLE [ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_Dealer] FOREIGN KEY([Dealer_ID])
REFERENCES [Dealer] ([ID]);
ALTER TABLE [ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_Dealer];
ALTER TABLE [ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_Profile] FOREIGN KEY([Profile_ID])
REFERENCES [Profile] ([ID]);
ALTER TABLE [ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_Profile];