CREATE PROCEDURE [AppUser].[CSP_UpdateHero]
	@Id INT, 
    @Strength INT, 
    @Stamina INT, 
    @Intellect INT, 
    @Charisma INT, 
    @UserId INT
AS
BEGIN
	UPDATE [dbo].[Heroes] 
    Set [Strength] = @Strength, 
        [Stamina] = @Stamina, 
        [Intellect] = @Intellect, 
        [Charisma] = @Charisma
    Where [UserId] = @UserId And Id = @Id;
END