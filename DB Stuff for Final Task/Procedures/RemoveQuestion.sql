USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 06.03.2020 21:06:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[RemoveQuestion]
	@Id INT
AS
BEGIN
	DELETE FROM Questions
	WHERE QuestionId = @Id
END


