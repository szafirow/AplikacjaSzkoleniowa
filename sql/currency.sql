USE [szkolenia]
GO

/****** Object:  Table [dbo].[currency]    Script Date: 2017-12-04 18:50:15 ******/
DROP TABLE [dbo].[currency]
GO

/****** Object:  Table [dbo].[currency]    Script Date: 2017-12-04 18:50:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[currency](
	[id_currency] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[code] [varchar](3) NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_currencyy] PRIMARY KEY CLUSTERED 
(
	[id_currency] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


