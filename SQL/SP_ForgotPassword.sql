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
ALTER PROCEDURE SP_ForgotPassword
	-- Add the parameters for the stored procedure here
	@Email NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF EXISTS(
        SELECT Email FROM Profiles
        WHERE Email = @Email
    )
    BEGIN
        SELECT 'Change Password Successfully' AS Message
	END
    BEGIN
        SELECT 'Email is not Registered' AS Message
	END

    -- Insert statements for procedure here
	UPDATE Users
    SET Users.Password = @Password
    FROM Users 
    INNER JOIN Profiles ON Users.ProfileID = Profiles.ProfileID
    WHERE Profiles.Email = @Email
END
GO

EXEC SP_Register
    @RolePrefix = 'AD',  
    @Username = 'admin1',  
    @Password = 'password123',  
    @FirstName = 'Juan',  
    @LastName = 'Dela Cruz',  
    @Age = 30,  
    @Gender = 'Male',  
    @Phone = 912345678,  
    @Address = 'Cebu City',  
    @Email = 'juan@example.com',  
    @Status = 'Active';
