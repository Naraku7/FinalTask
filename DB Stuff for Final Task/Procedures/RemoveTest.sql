USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 06.03.2020 22:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[RemoveTest]
	@Id INT
AS
BEGIN
	DELETE FROM Tests
	WHERE TestId = @Id
END


