CREATE TABLE [dbo].[Heroes]
(
	[Id] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(75) NOT NULL, 
    [Strength] INT NOT NULL, 
    [Stamina] INT NOT NULL, 
    [Intellect] INT NOT NULL, 
    [Charisma] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [PK_Heroes] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Heroes_Name_UserId] UNIQUE ([Name], [UserId]), 
    CONSTRAINT [CK_Heroes_Strength] CHECK ([Strength] BETWEEN 1 AND 20),
    CONSTRAINT [CK_Heroes_Stamina] CHECK ([Stamina] BETWEEN 1 AND 20),
    CONSTRAINT [CK_Heroes_Intellect] CHECK ([Intellect] BETWEEN 1 AND 20),
    CONSTRAINT [CK_Heroes_Charisma] CHECK ([Charisma] BETWEEN 1 AND 20), 
    CONSTRAINT [FK_Heroes_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
)

GO

CREATE INDEX [IX_Heroes_UserId] ON [dbo].[Heroes] ([UserId])
