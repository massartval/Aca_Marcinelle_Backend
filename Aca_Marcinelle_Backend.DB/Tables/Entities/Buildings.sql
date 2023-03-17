CREATE TABLE [dbo].[Buildings]
(
	[Id] INT NOT NULL,
	[AddressId] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Building_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Building_Address] FOREIGN KEY ([AddressId]) REFERENCES [Addresses]([Id]),
	CONSTRAINT [UK_Building_Name] UNIQUE ([Name])
)
