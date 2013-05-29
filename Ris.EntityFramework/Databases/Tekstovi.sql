USE [agencijskeVesti]
GO

/****** Object:  Table [dbo].[Tekstovi]    Script Date: 22.3.2013. 8:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tekstovi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PublikacijaID] [int] NOT NULL,
	[RubrikaID] [int] NOT NULL,
	[TipTekstaID] [int] NULL,
	[Nadnaslov] [nvarchar](255) NULL,
	[Naslov] [nvarchar](255) NOT NULL,
	[Podnaslov] [nvarchar](255) NULL,
	[Rtf] [nvarchar](max) NULL,
	[PlainText] [nvarchar](max) NULL,
	[Html] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tekstovi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Tekstovi]  WITH CHECK ADD  CONSTRAINT [FK_Tekstovi_Publikacije_PublikacijaID] FOREIGN KEY([PublikacijaID])
REFERENCES [dbo].[Publikacije] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tekstovi] CHECK CONSTRAINT [FK_Tekstovi_Publikacije_PublikacijaID]
GO

ALTER TABLE [dbo].[Tekstovi]  WITH CHECK ADD  CONSTRAINT [FK_Tekstovi_Rubrike_RubrikaID] FOREIGN KEY([RubrikaID])
REFERENCES [dbo].[Rubrike] ([ID])
GO

ALTER TABLE [dbo].[Tekstovi] CHECK CONSTRAINT [FK_Tekstovi_Rubrike_RubrikaID]
GO

ALTER TABLE [dbo].[Tekstovi]  WITH CHECK ADD  CONSTRAINT [FK_Tekstovi_TipoviTekstova_TipTekstaID] FOREIGN KEY([TipTekstaID])
REFERENCES [dbo].[TipoviTekstova] ([ID])
GO

ALTER TABLE [dbo].[Tekstovi] CHECK CONSTRAINT [FK_Tekstovi_TipoviTekstova_TipTekstaID]
GO

