USE [EnglishTestsWeb]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 07.03.2020 20:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddRole]
	@RoleName NVARCHAR(50)
AS
BEGIN
	INSERT INTO Roles(Role)
	VALUES(@RoleName) 
END
