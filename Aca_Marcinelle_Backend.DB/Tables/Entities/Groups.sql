CREATE TABLE [dbo].[Groups]
(
	[Id] INT NOT NULL IDENTITY,
	[ClassroomId] INT NOT NULL,
	[CourseId] INT NOT NULL,
	[WeekDayId] INT NOT NULL,
	[StartTime] TIME NOT NULL,
	[EndTime] TIME NOT NULL,
	[SchoolYear] NCHAR(4) NOT NULL DEFAULT YEAR(GETDATE()),
	CONSTRAINT [PK_Group_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Group_Classroom] FOREIGN KEY ([ClassroomId]) REFERENCES [Classrooms]([Id]),
	CONSTRAINT [FK_Group_Course] FOREIGN KEY ([CourseId]) REFERENCES [Courses]([Id]),
	CONSTRAINT [FK_Group_WeekDay] FOREIGN KEY ([WeekDayId]) REFERENCES [WeekDays]([Id]),
	CONSTRAINT [UK_Period_In_Classroom] UNIQUE ([ClassroomId],[WeekDayId], [StartTime])
)
