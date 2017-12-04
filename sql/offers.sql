USE [szkolenia]
GO

/****** Object:  Table [dbo].[offers]    Script Date: 2017-12-04 18:50:48 ******/
DROP TABLE [dbo].[offers]
GO

/****** Object:  Table [dbo].[offers]    Script Date: 2017-12-04 18:50:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[offers](
	[id_offers] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [text] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_offer] PRIMARY KEY CLUSTERED 
(
	[id_offers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


