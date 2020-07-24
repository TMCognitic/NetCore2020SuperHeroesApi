CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(320) NOT NULL, 
    [Passwd] BINARY(64) NOT NULL, 
    [IsAdmin] BIT NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Users_Email] UNIQUE ([Email]) 
)
