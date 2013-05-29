USE [ris]
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

GO

/****** Object:  Table [dbo].[GrupeMaterijala]    Script Date: 21.3.2013. 11:26:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GrupeMaterijala](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GrupeMaterijala] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[MaterijalInfo]    Script Date: 21.3.2013. 11:26:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MaterijalInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](max) NULL,
	[Kreiran] [datetime] NULL,
	[PublikacijaID] [int] NULL,
	[Tagovi] [nvarchar](256) NULL,
	[GrupaMaterijalaID] [int] NULL,
	[RadnikID] [int] NULL,
 CONSTRAINT [PK_MaterijalInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[MaterijalInfo]  WITH CHECK ADD  CONSTRAINT [FK_MaterijalInfo_GrupeMaterijala_GrupaMaterijalaID] FOREIGN KEY([GrupaMaterijalaID])
REFERENCES [dbo].[GrupeMaterijala] ([ID])
GO

ALTER TABLE [dbo].[MaterijalInfo] CHECK CONSTRAINT [FK_MaterijalInfo_GrupeMaterijala_GrupaMaterijalaID]
GO

ALTER TABLE [dbo].[MaterijalInfo]  WITH CHECK ADD  CONSTRAINT [FK_MaterijalInfo_Publikacije_PublikacijaID] FOREIGN KEY([PublikacijaID])
REFERENCES [dbo].[Publikacije] ([ID])
GO

ALTER TABLE [dbo].[MaterijalInfo] CHECK CONSTRAINT [FK_MaterijalInfo_Publikacije_PublikacijaID]
GO

ALTER TABLE [dbo].[MaterijalInfo]  WITH CHECK ADD  CONSTRAINT [FK_MaterijalInfo_Radnici_RadnikID] FOREIGN KEY([RadnikID])
REFERENCES [dbo].[Radnici] ([ID])
GO

ALTER TABLE [dbo].[MaterijalInfo] CHECK CONSTRAINT [FK_MaterijalInfo_Radnici_RadnikID]
GO

/****** Object:  Table [dbo].[Materijali]    Script Date: 18.3.2013. 14:08:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Materijali](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Putanja] [nvarchar](max) NOT NULL,
	[InfoID] [int] NOT NULL,
 CONSTRAINT [PK_Materijali] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Materijali]  WITH CHECK ADD  CONSTRAINT [FK_Materijali_MaterijalInfo_InfoID] FOREIGN KEY([InfoID])
REFERENCES [dbo].[MaterijalInfo] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Materijali] CHECK CONSTRAINT [FK_Materijali_MaterijalInfo_InfoID]
GO

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

/****** Object:  Table [dbo].[MaterijaliTekstova]    Script Date: 21.3.2013. 9:16:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MaterijaliTekstova](
	[Tekst_ID] [int] NOT NULL,
	[Materijal_ID] [int] NOT NULL,
 CONSTRAINT [PK_MaterijaliTekstova] PRIMARY KEY CLUSTERED 
(
	[Tekst_ID] ASC,
	[Materijal_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MaterijaliTekstova]  WITH CHECK ADD  CONSTRAINT [FK_MaterijaliTekstova_Materijali_Materijal_ID] FOREIGN KEY([Materijal_ID])
REFERENCES [dbo].[Materijali] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MaterijaliTekstova] CHECK CONSTRAINT [FK_MaterijaliTekstova_Materijali_Materijal_ID]
GO

ALTER TABLE [dbo].[MaterijaliTekstova]  WITH CHECK ADD  CONSTRAINT [FK_MaterijaliTekstova_Tekstovi_Tekst_ID] FOREIGN KEY([Tekst_ID])
REFERENCES [dbo].[Tekstovi] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MaterijaliTekstova] CHECK CONSTRAINT [FK_MaterijaliTekstova_Tekstovi_Tekst_ID]
GO