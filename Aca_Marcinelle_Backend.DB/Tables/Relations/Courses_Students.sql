CREATE TABLE [dbo].[Courses_Students]
(
	[CourseId] INT NOT NULL,
	[StudentId] INT NOT NULL,
	[LevelId] INT NOT NULL DEFAULT 1,
	CONSTRAINT [PK_CS] PRIMARY KEY ([CourseId], [StudentId]),
	CONSTRAINT [FK_CS_Course] FOREIGN KEY ([CourseId]) REFERENCES [Courses]([Id]),
	CONSTRAINT [FK_CS_Level] FOREIGN KEY ([LevelId]) REFERENCES [Levels]([Id]),
	CONSTRAINT [FK_CS_Student] FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id])
)
