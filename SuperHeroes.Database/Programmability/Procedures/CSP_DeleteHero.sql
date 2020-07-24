CREATE PROCEDURE [AppUser].[CSP_DeleteHero]
	@Id INT, 
    @UserId INT
AS
BEGIN
	Delete From [dbo].[Heroes]
	Where Id = @Id And UserId = @UserId;
END