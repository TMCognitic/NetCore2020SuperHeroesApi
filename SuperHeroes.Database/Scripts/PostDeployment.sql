/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

Exec AppUser.CSP_Register @LastName = 'Morre', @FirstName = 'Thierry', @Email = 'thierry.morre@cognitic.be', @Passwd = 'Test1234=';

Exec AppUser.CSP_AddHero @Name = 'Cortex', @Strength = 2, @Stamina = 7, @Intellect = 18, @Charisma = 16, @UserId = 1;
Exec AppUser.CSP_AddHero @Name = 'Minus', @Strength = 8, @Stamina = 10, @Intellect = 1, @Charisma = 3, @UserId = 1;
Exec AppUser.CSP_AddHero @Name = 'Test', @Strength = 1, @Stamina = 1, @Intellect = 1, @Charisma = 1, @UserId = 1;

Exec AppUser.CSP_UpdateHero @Id = 2, @Strength = 8, @Stamina = 10, @Intellect = 2, @Charisma = 2, @UserId = 1;

Exec AppUser.CSP_DeleteHero @Id = 3, @UserId = 1;
