CREATE TABLE [dbo].[Persons]
(
	[Id] INT NOT NULL IDENTITY, 	
	[AddressId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL, 
	[BirthDate] DATE NOT NULL,
	[NISS] NCHAR(11)NOT NULL, --entrer uniquement les chiffres
	[Email] NVARCHAR(50),
	[Phone] NVARCHAR(10), --tenir compte des lignes fixes (9 chiffres)
	CONSTRAINT [PK_Person_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Person_Address] FOREIGN KEY ([AddressId]) REFERENCES [Addresses]([Id]),
	CONSTRAINT [FK_Person_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]),
	CONSTRAINT [UK_NISS] UNIQUE ([NISS])
);