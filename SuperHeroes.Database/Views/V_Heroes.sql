CREATE VIEW [AppUser].[V_Heroes]
	AS SELECT [Id], [Name], [Strength], [Stamina], [Intellect], [Charisma], [UserId] FROM [dbo].[Heroes]
