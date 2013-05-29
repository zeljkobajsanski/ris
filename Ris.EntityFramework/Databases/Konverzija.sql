USE [agencijskeVesti]
GO

/****** Object:  Table [dbo].[Konverzija]    Script Date: 7.3.2013. 15:57:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Konverzija](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sablon] [nvarchar](20) NOT NULL,
	[KonverovaniString] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Konverzija] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

