USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[AddQuestion]    Script Date: 06.03.2020 23:59:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddTest]
	@TestId INT OUTPUT,
	@Subject NVARCHAR(50)
AS
BEGIN
	INSERT INTO Tests(Subject)
	VALUES(@Subject) 
	SET @TestId = SCOPE_IDENTITY()
END
