USE [EnglishTestsWeb]
GO

/****** Object:  Table [dbo].[Users_TestScores]    Script Date: 09.03.2020 3:01:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users_TestScores](
	[UserId] [int] NOT NULL,
	[TestId] [int] NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [PK_Users_TestScores] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users_TestScores]  WITH CHECK ADD  CONSTRAINT [FK_Users_TestScores_Tests] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([TestId])
GO

ALTER TABLE [dbo].[Users_TestScores] CHECK CONSTRAINT [FK_Users_TestScores_Tests]
GO

ALTER TABLE [dbo].[Users_TestScores]  WITH CHECK ADD  CONSTRAINT [FK_Users_TestScores_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[Users_TestScores] CHECK CONSTRAINT [FK_Users_TestScores_Users]
GO

