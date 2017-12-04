USE [szkolenia]
GO

ALTER TABLE [dbo].[trainings] DROP CONSTRAINT [FK_trainings_currency]
GO

/****** Object:  Table [dbo].[trainings]    Script Date: 2017-12-04 18:51:40 ******/
DROP TABLE [dbo].[trainings]
GO

/****** Object:  Table [dbo].[trainings]    Script Date: 2017-12-04 18:51:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[trainings](
	[id_trainings] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[business] [varchar](255) NOT NULL,
	[leader] [varchar](255) NULL,
	[start] [datetime] NOT NULL,
	[finish] [datetime] NOT NULL,
	[price] [money] NOT NULL,
	[id_currency] [numeric](18, 0) NOT NULL,
	[description] [text] NULL,
	[slot] [numeric](3, 0) NOT NULL,
	[active] [bit] NOT NULL,
	[date_add] [datetime] NOT NULL,
 CONSTRAINT [PK_trainings1] PRIMARY KEY CLUSTERED 
(
	[id_trainings] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[trainings]  WITH CHECK ADD  CONSTRAINT [FK_trainings_currency] FOREIGN KEY([id_currency])
REFERENCES [dbo].[currency] ([id_currency])
GO

ALTER TABLE [dbo].[trainings] CHECK CONSTRAINT [FK_trainings_currency]
GO


