USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[EditQuestion]    Script Date: 07.03.2020 12:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ChangeSubject]
	@Id INT,
	@Subject NVARCHAR(50)
AS
BEGIN
	UPDATE Tests 
	SET Subject = @Subject
	WHERE TestId = @Id
END

