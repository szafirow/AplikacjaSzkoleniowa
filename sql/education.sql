USE [szkolenia]
GO

/****** Object:  Table [dbo].[education]    Script Date: 2017-12-04 18:50:31 ******/
DROP TABLE [dbo].[education]
GO

/****** Object:  Table [dbo].[education]    Script Date: 2017-12-04 18:50:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[education](
	[id_education] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
 CONSTRAINT [PK_education] PRIMARY KEY CLUSTERED 
(
	[id_education] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


