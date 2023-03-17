CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL IDENTITY ,
	[City] NVARCHAR(50) NOT NULL,
	[Street] NVARCHAR(50) NOT NULL,
	[Number] NVARCHAR(10) NOT NULL,
	[Zipcode] NCHAR(4) --nullable pour considérations pratiques, ex prof adresse étrangère (FR 5 chiffres) + pas ultra nécessaire
	CONSTRAINT [PK_Address_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Address] UNIQUE ([City], [Number], [Street]),
)
