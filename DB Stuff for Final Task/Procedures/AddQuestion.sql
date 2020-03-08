USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 05.03.2020 22:14:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[AddQuestion]
	@Text NVARCHAR(4000),
	@CorrectAnswer INT,
	@Id INT OUTPUT
AS
BEGIN
	INSERT INTO Questions(Text, CorrectAnswer)
	VALUES(@Text, @CorrectAnswer) 
	SET @Id = SCOPE_IDENTITY()
END
