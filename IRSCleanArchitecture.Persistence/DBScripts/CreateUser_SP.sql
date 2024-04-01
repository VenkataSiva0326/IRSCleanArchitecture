CREATE PROCEDURE [dbo].[CreateUser]
    @email NVARCHAR(50),
    @name NVARCHAR(50)

AS
BEGIN
    DECLARE @userId INT;


    INSERT INTO [dbo].[Users]
(
 [Email], [Name]
)
VALUES
(
 @email, @name
)

SET @userId = SCOPE_IDENTITY();


SELECT TOP 1 *
FROM Users
WHERE Id = @userId
ORDER by Id DESC;

END
GO