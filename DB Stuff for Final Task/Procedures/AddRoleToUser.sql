USE [EnglishTestsWeb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddRoleToUser]
	@UserId INT,
	@RoleName NVARCHAR(50)
AS
BEGIN
	INSERT INTO Users_Roles(UserId, Role)
	VALUES(@UserId, @RoleName) 
END
