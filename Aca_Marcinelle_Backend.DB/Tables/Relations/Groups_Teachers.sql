CREATE TABLE [dbo].[Groups_Teachers]
(
	[GroupId] INT NOT NULL,
	[TeacherId] INT NOT NULL,
	CONSTRAINT [PK_GT] PRIMARY KEY ([GroupId], [TeacherId]),
	CONSTRAINT [FK_GT_Group] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([Id]),
	CONSTRAINT [FK_GT_Teacher] FOREIGN KEY ([TeacherId]) REFERENCES [Teachers]([Id])
)
