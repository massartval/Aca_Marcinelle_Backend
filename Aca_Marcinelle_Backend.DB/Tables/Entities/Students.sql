CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT 1,
	[RegistrationOK] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [PK_Student_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Student_Person] FOREIGN KEY ([Id]) REFERENCES [Persons]([Id])
)
