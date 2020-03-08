USE [EnglishTestsWeb]
GO

/****** Object:  Table [dbo].[Tests_Questions]    Script Date: 09.03.2020 3:00:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tests_Questions](
	[TestId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tests_Questions]  WITH CHECK ADD  CONSTRAINT [FK_Tests_Questions_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO

ALTER TABLE [dbo].[Tests_Questions] CHECK CONSTRAINT [FK_Tests_Questions_Questions]
GO

ALTER TABLE [dbo].[Tests_Questions]  WITH CHECK ADD  CONSTRAINT [FK_Tests_Questions_Tests] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([TestId])
GO

ALTER TABLE [dbo].[Tests_Questions] CHECK CONSTRAINT [FK_Tests_Questions_Tests]
GO

