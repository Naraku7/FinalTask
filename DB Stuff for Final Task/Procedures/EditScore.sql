USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 07.03.2020 17:15:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditScore]
	@UserId INT,
	@TestId INT,
	@NewScore INT
AS
BEGIN
	UPDATE Users_TestScores 
	SET Score = @NewScore
	WHERE UserId = @UserId AND TestId = @TestId
END



