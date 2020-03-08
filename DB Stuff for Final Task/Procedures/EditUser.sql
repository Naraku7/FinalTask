USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 04.03.2020 16:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditUser]
	@Id INT,
	@Username NVARCHAR(25),
	@Password NVARCHAR(50)
AS
BEGIN
	UPDATE Users 
	SET Username = @Username, Password = @Password
	WHERE UserId = @Id
END



