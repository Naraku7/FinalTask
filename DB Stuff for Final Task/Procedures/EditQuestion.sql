USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 05.03.2020 17:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[EditQuestion]
	@Id INT,
	@Text NVARCHAR(4000),
	@CorrectAnswer INT
AS
BEGIN
	UPDATE Questions 
	SET Text = @Text, CorrectAnswer = @CorrectAnswer
	WHERE QuestionId = @Id
END

