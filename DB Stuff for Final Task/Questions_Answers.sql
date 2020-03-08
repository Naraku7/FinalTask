USE [EnglishTestsWeb]
GO

/****** Object:  Table [dbo].[Questions_Answers]    Script Date: 09.03.2020 3:00:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Questions_Answers](
	[QuestionId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Questions_Answers]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Answers_Answers] FOREIGN KEY([AnswerId])
REFERENCES [dbo].[Answers] ([AnswerId])
GO

ALTER TABLE [dbo].[Questions_Answers] CHECK CONSTRAINT [FK_Questions_Answers_Answers]
GO

ALTER TABLE [dbo].[Questions_Answers]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Answers_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO

ALTER TABLE [dbo].[Questions_Answers] CHECK CONSTRAINT [FK_Questions_Answers_Questions]
GO

