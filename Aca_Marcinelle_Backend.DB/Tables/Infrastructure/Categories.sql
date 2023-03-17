CREATE TABLE [dbo].[Categories]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200),
	CONSTRAINT [PK_Category_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Category_Name] UNIQUE ([Name])
)
