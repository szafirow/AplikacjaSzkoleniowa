USE [szkolenia]
GO

ALTER TABLE [dbo].[participants_trainings] DROP CONSTRAINT [FK_participants_trainings_trainings]
GO

ALTER TABLE [dbo].[participants_trainings] DROP CONSTRAINT [FK_participants_trainings_participants]
GO

/****** Object:  Table [dbo].[participants_trainings]    Script Date: 2017-12-04 18:51:22 ******/
DROP TABLE [dbo].[participants_trainings]
GO

/****** Object:  Table [dbo].[participants_trainings]    Script Date: 2017-12-04 18:51:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[participants_trainings](
	[id_participants_trainings] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_participants] [numeric](18, 0) NULL,
	[id_trainings] [numeric](18, 0) NULL,
 CONSTRAINT [PK_participants_trainigs1] PRIMARY KEY CLUSTERED 
(
	[id_participants_trainings] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[participants_trainings]  WITH CHECK ADD  CONSTRAINT [FK_participants_trainings_participants] FOREIGN KEY([id_participants])
REFERENCES [dbo].[participants] ([id_participants])
GO

ALTER TABLE [dbo].[participants_trainings] CHECK CONSTRAINT [FK_participants_trainings_participants]
GO

ALTER TABLE [dbo].[participants_trainings]  WITH CHECK ADD  CONSTRAINT [FK_participants_trainings_trainings] FOREIGN KEY([id_trainings])
REFERENCES [dbo].[trainings] ([id_trainings])
GO

ALTER TABLE [dbo].[participants_trainings] CHECK CONSTRAINT [FK_participants_trainings_trainings]
GO


