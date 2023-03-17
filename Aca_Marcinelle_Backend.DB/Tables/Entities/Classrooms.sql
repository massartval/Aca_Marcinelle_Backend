CREATE TABLE [dbo].[Classrooms]
(
	[Id] INT NOT NULL,
	[BuildingId] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Classroom_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Classroom_Building] FOREIGN KEY ([BuildingId]) REFERENCES [Buildings]([Id]),
	CONSTRAINT [UK_Name_In_Building] UNIQUE ([BuildingId], [Name])
)
