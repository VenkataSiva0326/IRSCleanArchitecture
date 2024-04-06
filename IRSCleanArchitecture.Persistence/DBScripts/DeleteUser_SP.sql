CREATE PROCEDURE [dbo].[DeleteUser]
    @userId Int

AS
BEGIN
   Delete from Users where Id=@userId

SELECT TOP 1 *
FROM Users
WHERE Id = @userId
ORDER by Id DESC;

END
GO