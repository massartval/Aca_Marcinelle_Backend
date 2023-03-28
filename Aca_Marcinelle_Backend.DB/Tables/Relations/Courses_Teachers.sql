CREATE TABLE [dbo].[Courses_Teachers]
(
	[CourseId] INT NOT NULL,
	[TeacherId] INT NOT NULL,
	CONSTRAINT [PK_CT] PRIMARY KEY ([CourseId], [TeacherId]),
	CONSTRAINT [FK_CT_Course] FOREIGN KEY ([CourseId]) REFERENCES [Courses]([Id]),
	CONSTRAINT [FK_CT_Teacher] FOREIGN KEY ([TeacherId]) REFERENCES [Teachers]([Id]))
