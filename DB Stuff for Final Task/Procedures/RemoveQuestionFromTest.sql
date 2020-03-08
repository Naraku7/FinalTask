USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[RemoveAnswerFromQuestion]    Script Date: 06.03.2020 22:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[RemoveQuestionFromTest]
	@TestId INT,
	@QuestId INT
AS
BEGIN
	DELETE FROM Tests_Questions
	WHERE QuestionId = @QuestId AND TestId = @TestId
END


