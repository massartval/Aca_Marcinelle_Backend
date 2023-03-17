CREATE TABLE [dbo].[Courses]
(
	[Id] INT NOT NULL IDENTITY, 
	[DomainId] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200),
	[IsCollective] BIT NOT NULL,
	[IsPrincipal] BIT NOT NULL,
	CONSTRAINT [PK_Course_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Course_Domain] FOREIGN KEY ([DomainId]) REFERENCES [Domains]([Id]),
	CONSTRAINT [UK_Course_Name] UNIQUE ([Name])
)
