CREATE TABLE [dbo].[Admins]
(
	[Id] INT NOT NULL,
	CONSTRAINT [PK_Admin_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Admin_Person] FOREIGN KEY ([Id]) REFERENCES [Admins]([Id]),
)
