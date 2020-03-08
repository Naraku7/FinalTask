USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[AddQuestionToTest]    Script Date: 07.03.2020 17:03:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddScoreOfTest]
	@UserId INT,
	@TestId INT,
	@Score INT
AS
BEGIN
	INSERT INTO Users_TestScores(UserId, TestId, Score)
	VALUES(@UserId, @TestId, @Score) 
END



