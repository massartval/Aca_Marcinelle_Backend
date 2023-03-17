CREATE TABLE [dbo].[Teachers]
(
	[Id] INT NOT NULL,
	CONSTRAINT [PK_Teacher_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Teacher_Person] FOREIGN KEY ([Id]) REFERENCES [Users]([Id])
)
