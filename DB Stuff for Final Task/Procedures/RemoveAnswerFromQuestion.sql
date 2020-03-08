USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[RemoveQuestion]    Script Date: 06.03.2020 22:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[RemoveAnswerFromQuestion]
	@AnswerId INT,
	@QuestId INT
AS
BEGIN
	DELETE FROM Questions_Answers
	WHERE QuestionId = @QuestId AND AnswerId = @AnswerId
END


