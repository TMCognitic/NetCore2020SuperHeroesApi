CREATE PROCEDURE [AppUser].[CSP_Register]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
BEGIN
	Declare @IsAdmin BIT = 0;

	IF (NOT EXISTS(SELECT * FROM [dbo].[Users]))
	BEGIN
		SET @IsAdmin = 1;
	END

	Insert into [dbo].[Users] ([LastName], [FirstName], [Email], [Passwd], IsAdmin)
	values (@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', dbo.CSF_GetPreSalt() + @Passwd + dbo.CSF_GetPostSalt()), @IsAdmin);
END