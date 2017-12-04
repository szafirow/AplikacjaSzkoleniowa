USE [szkolenia]
GO

ALTER TABLE [dbo].[participants] DROP CONSTRAINT [FK_participants_offers]
GO

ALTER TABLE [dbo].[participants] DROP CONSTRAINT [FK_participants_education]
GO

ALTER TABLE [dbo].[participants] DROP CONSTRAINT [FK_participants_countries]
GO

/****** Object:  Table [dbo].[participants]    Script Date: 2017-12-04 18:51:03 ******/
DROP TABLE [dbo].[participants]
GO

/****** Object:  Table [dbo].[participants]    Script Date: 2017-12-04 18:51:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[participants](
	[id_participants] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[email] [varchar](150) NULL,
	[phone] [nchar](10) NULL,
	[id_countries] [numeric](18, 0) NULL,
	[city] [varchar](20) NULL,
	[street] [varchar](20) NULL,
	[postal_code] [varchar](5) NULL,
	[id_offers] [numeric](18, 0) NULL,
	[id_education] [numeric](18, 0) NULL,
 CONSTRAINT [PK_participantss] PRIMARY KEY CLUSTERED 
(
	[id_participants] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[participants]  WITH NOCHECK ADD  CONSTRAINT [FK_participants_countries] FOREIGN KEY([id_countries])
REFERENCES [dbo].[countries] ([id_countries])
GO

ALTER TABLE [dbo].[participants] NOCHECK CONSTRAINT [FK_participants_countries]
GO

ALTER TABLE [dbo].[participants]  WITH NOCHECK ADD  CONSTRAINT [FK_participants_education] FOREIGN KEY([id_education])
REFERENCES [dbo].[education] ([id_education])
GO

ALTER TABLE [dbo].[participants] NOCHECK CONSTRAINT [FK_participants_education]
GO

ALTER TABLE [dbo].[participants]  WITH NOCHECK ADD  CONSTRAINT [FK_participants_offers] FOREIGN KEY([id_offers])
REFERENCES [dbo].[offers] ([id_offers])
GO

ALTER TABLE [dbo].[participants] NOCHECK CONSTRAINT [FK_participants_offers]
GO


