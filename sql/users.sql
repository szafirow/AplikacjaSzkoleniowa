USE [szkolenia]
GO

/****** Object:  Table [dbo].[users]    Script Date: 2017-12-04 18:51:52 ******/
DROP TABLE [dbo].[users]
GO

/****** Object:  Table [dbo].[users]    Script Date: 2017-12-04 18:51:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[users](
	[id_users] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NULL,
	[password] [varchar](250) NULL,
	[active] [bit] NULL,
	[date_add] [datetime] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id_users] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


