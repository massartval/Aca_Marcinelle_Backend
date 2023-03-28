CREATE TABLE [dbo].[Groups_Students]
(
	[GroupId] INT NOT NULL,
	[StudentId] INT NOT NULL,
	CONSTRAINT [PK_GS] PRIMARY KEY ([GroupId], [StudentId]),
	CONSTRAINT [FK_GS_Group] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([Id]),
	CONSTRAINT [FK_GS_Student] FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id])
)
