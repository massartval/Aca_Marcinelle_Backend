CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL,
	[RegistrationOK] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [PK_Student_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Student_Person] FOREIGN KEY ([Id]) REFERENCES [Users]([Id])
)
