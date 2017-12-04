USE [szkolenia]
GO

/****** Object:  Table [dbo].[countries]    Script Date: 2017-12-04 18:49:05 ******/
DROP TABLE [dbo].[countries]
GO

/****** Object:  Table [dbo].[countries]    Script Date: 2017-12-04 18:49:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[countries](
	[id_countries] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[code] [varchar](2) NOT NULL,
	[continent_code] [varchar](2) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[full_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_countries4] PRIMARY KEY CLUSTERED 
(
	[id_countries] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


