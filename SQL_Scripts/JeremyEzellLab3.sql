USE AUTH;  
GO  
CREATE PROCEDURE dbo.JeremyEzellLab3
    @UserName nvarchar(255)
AS   

    SET NOCOUNT ON;  
    SELECT *
    FROM dbo.Account
    WHERE UserName = @UserName;
RETURN
GO  