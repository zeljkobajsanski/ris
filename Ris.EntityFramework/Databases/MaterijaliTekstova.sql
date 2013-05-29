USE [agencijskeVesti]
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

