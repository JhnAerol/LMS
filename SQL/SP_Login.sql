USE [Proel2D]
GO
/****** Object:  StoredProcedure [dbo].[SP_Login]    Script Date: 08/09/2025 7:25:09 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_Login]
	-- Add the parameters for the stored procedure here
	@Username NVARCHAR(50),
	@Password NVARCHAR(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (
		SELECT 1 FROM Users
		WHERE Username = @Username AND Password = @Password
	)
	BEGIN 
		SELECT 'Login Successful' AS Message,
		Username,
		Password,
		LEFT(Profiles.RoleCodeNumber,2) AS RoleCode
		FROM Users
		RIGHT JOIN Profiles 
		ON Users.ProfileID = Profiles.ProfileID
		WHERE Username = @Username AND Password = @Password
	END
	BEGIN
		SELECT 'Incorrect Username or Password' AS Message
	END

    -- Insert statements for procedure here

	SELECT Username, Password FROM Users
	WHERE Username = @Username AND Password = @Password

END
