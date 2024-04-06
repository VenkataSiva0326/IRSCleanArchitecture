
CREATE PROCEDURE [dbo].[GetUserById]
    @userId int

AS
BEGIN
   Select * from Users where Id=@userId
END
GO