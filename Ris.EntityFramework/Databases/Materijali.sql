USE [agencijskeVesti]
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

