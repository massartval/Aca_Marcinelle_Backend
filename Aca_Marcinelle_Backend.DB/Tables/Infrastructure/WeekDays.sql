﻿CREATE TABLE [dbo].[WeekDays]
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(10) NOT NULL,
	CONSTRAINT [PK_WeekDay_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_WeekDay_Name] UNIQUE ([Name])
)
