USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 04.03.2020 21:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveUser]
	@Id INT
AS
BEGIN
	DELETE FROM Users
	WHERE UserId = @Id
END


