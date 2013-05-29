USE [agencijskeVesti]
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

