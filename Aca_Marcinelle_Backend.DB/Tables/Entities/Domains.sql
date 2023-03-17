CREATE TABLE [dbo].[Domains]
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200),
	CONSTRAINT [PK_Domain_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Domain_Name] UNIQUE ([Name])
)
