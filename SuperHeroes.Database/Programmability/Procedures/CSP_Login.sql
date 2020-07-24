CREATE PROCEDURE [AppUser].[CSP_Login]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT [Id], [LastName], [FirstName], [Email], IsAdmin
	FROM [dbo].[Users]
	WHERE [Email] = @Email And [Passwd] = HASHBYTES('SHA2_512', dbo.CSF_GetPreSalt() + @Passwd + dbo.CSF_GetPostSalt());
END
