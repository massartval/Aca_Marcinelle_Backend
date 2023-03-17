CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT NULL IDENTITY,
	[AuthorId] INT NOT NULL,
	[UpdatedById] INT,
	[GroupId] INT,
	[Title] NVARCHAR(50) NOT NULL,
	[Content] NVARCHAR(4000) NOT NULL,
	[Description] NVARCHAR(200),
	[PublicationDate] DATE NOT NULL,
	[LastUpdate] DATE,
	CONSTRAINT [PK_Article_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Article_Author] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Article_LastUpdatedBy] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Article_Group] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([Id])
)
