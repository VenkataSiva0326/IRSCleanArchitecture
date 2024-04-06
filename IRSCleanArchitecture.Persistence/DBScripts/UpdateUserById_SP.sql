CREATE PROCEDURE [dbo].[UpdateUserById]
    @userId int,
	@email NVARCHAR(50),
	@name  NVARCHAR(50)

AS
BEGIN
   Update Users set Email=@email, [Name]=@name where Id=@userId

   
SELECT TOP 1 *
FROM Users
WHERE Id = @userId
ORDER by Id DESC;
END
GO