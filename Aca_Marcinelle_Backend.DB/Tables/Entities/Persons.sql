CREATE TABLE [dbo].[Persons]
(
	[Id] INT NOT NULL IDENTITY, 	
	[CategoryId] INT,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL, 
	[BirthDate] DATE NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[Street] NVARCHAR(50) NOT NULL,
	[HouseNumber] NVARCHAR(10) NOT NULL,
	[Zipcode] NCHAR(4), --nullable pour considérations pratiques, ex prof adresse étrangère (FR 5 chiffres) + pas ultra nécessaire
	[NISS] NCHAR(11)NOT NULL, --entrer uniquement les chiffres
	[Email] NVARCHAR(50),
	[PhoneNumber] NVARCHAR(10), --tenir compte des lignes fixes (9 chiffres)
	CONSTRAINT [PK_Person_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Person_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]),
	CONSTRAINT [UK_NISS] UNIQUE ([NISS])
);