USE [TestDB]
GO
/****** Object:  Table [dbo].[Crawlings]    Script Date: 4.1.2017 14:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crawlings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CrawingDate] [datetime] NULL,
	[WebSite] [nvarchar](250) NULL,
	[WebSiteURL] [nvarchar](250) NULL,
 CONSTRAINT [PK_Crawlings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Elements]    Script Date: 4.1.2017 14:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UrlId] [int] NULL,
	[ElementType] [nvarchar](50) NULL,
	[TagName] [nvarchar](50) NULL,
	[TagAsJson] [ntext] NULL,
	[Navigatable] [bit] NULL,
	[NavigateURL] [nvarchar](250) NULL,
	[TagHash] [nvarchar](50) NULL,
 CONSTRAINT [PK_Elements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Urls]    Script Date: 4.1.2017 14:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CrawlingId] [int] NULL,
	[Url] [nvarchar](250) NULL,
 CONSTRAINT [PK_Urls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
