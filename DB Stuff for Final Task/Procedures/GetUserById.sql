USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 04.03.2020 17:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetUserById]
	@Id INT,
	@Username NVARCHAR(25) OUTPUT,
	@Password NVARCHAR(50) OUTPUT
AS
BEGIN
	SET @Username = (SELECT Users.Username FROM Users WHERE UserId = @Id)
	SET @Password = (SELECT Users.Password FROM Users WHERE UserId = @Id)
END



