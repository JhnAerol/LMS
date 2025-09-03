-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE SP_Login
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
		LEFT(RoleCodeNumber,2) AS RoleCode
		FROM Users
		WHERE Username = @Username AND Password = @Password
	END
	BEGIN
		SELECT 'Incorrect Username or Password' AS Message
	END

    -- Insert statements for procedure here

	SELECT Username, Password FROM Users
	WHERE Username = @Username AND Password = @Password

END
GO
