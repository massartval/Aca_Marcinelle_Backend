CREATE TABLE [dbo].[Levels]
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(10) NOT NULL,
	[Description] NVARCHAR(200),
	[IsAdult] BIT NOT NULL,
	CONSTRAINT [PK_Level_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Level_Name] UNIQUE ([Name])
)
