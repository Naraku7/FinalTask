USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 04.03.2020 22:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddQuestionToTest]
	@QuestionId INT,
	@TestId INT
AS
BEGIN
	INSERT INTO Tests_Questions(TestId, QuestionId)
	VALUES(@TestId, @QuestionId) 
END
