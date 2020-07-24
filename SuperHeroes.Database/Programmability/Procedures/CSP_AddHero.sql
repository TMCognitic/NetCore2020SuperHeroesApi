CREATE PROCEDURE [AppUser].[CSP_AddHero]
	@Name NVARCHAR(75), 
    @Strength INT, 
    @Stamina INT, 
    @Intellect INT, 
    @Charisma INT, 
    @UserId INT
AS
BEGIN
	Insert into [dbo].[Heroes] ([Name], [Strength], [Stamina], [Intellect], [Charisma], [UserId])
    values (@Name, @Strength, @Stamina, @Intellect, @Charisma, @UserId);
END
