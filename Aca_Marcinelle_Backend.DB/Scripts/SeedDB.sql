/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



-- Infrastructure tables

SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories]([Id], [Name])
VALUES
(1, 'Demandeur d''emploi'),
(2, 'Etudiant'),
(3, 'CPAS'), 
(4, 'Enseignant');
SET IDENTITY_INSERT [Categories] OFF;

INSERT INTO [Domains]([Id], [Name])
VALUES
(1, 'Arts de la parole'),
(2, 'Expression corporelle'),
(3, 'Musique'), 
(4, 'Pluridisciplinaire');

INSERT INTO [Levels]([Id], [Name], [IsAdult])
VALUES
(1, 'F1', 0),
(2, 'F2', 0),
(3, 'F3', 0),
(4, 'F4', 0),
(5, 'F5', 0),
(6, 'F1A', 1),
(7, 'F2A', 1);

INSERT INTO [WeekDays]([Id], [Name])
VALUES
(1, 'Lundi'),
(2, 'Mardi'),
(3, 'Mercredi'),
(4, 'Jeudi'),
(5, 'Vendredi'),
(6, 'Samedi'),
(7, 'Dimanche');



-- Data tables

SET IDENTITY_INSERT [Addresses] ON;
INSERT INTO [Addresses]([Id], [City], [Street], [Number], [Zipcode])
VALUES
(1, 'Marcinelle', 'Rue Aurélien Thibaut', '20' , '6001'),
(2, 'Lodelinsart', 'Rue Albert Delwarte', '23', '6042')
SET IDENTITY_INSERT [Addresses] OFF;

INSERT INTO [Buildings]([Id], [AddressId], [Name])
VALUES 
(1, 1, 'Implantation Centre - Bâtiment principal'),
(2, 1, 'Implantation Centre - Salle Gossiaux');

INSERT INTO [Classrooms]([Id],[BuildingId], [Name])
VALUES
(1, 1, 'C1'),
(2, 1, 'C2'),
(3, 2, 'Salle Gossiaux');

SET IDENTITY_INSERT [Persons] ON;
INSERT INTO [Persons]([Id], [AddressId], [CategoryId], [FirstName], [LastName], [BirthDate], [NISS], [Email], [Phone])
VALUES
(1, 2, 1, 'Valentin', 'Massart', '12/24/1991', '91122438913', 'massart.val@gmail.com', '0472772704'),
(2, 2, 2, 'Charlotte', 'Franckx', '04/16/1999', '99041638913', 'fckx@gmail.com', '0495196207');
SET IDENTITY_INSERT [Persons] OFF;

INSERT INTO [Users]([Id], [UserName], [Password], [IsActive])
VALUES
(1, 'valmas', 'testtest1234=', 1),
(2, 'chafra', 'testtest1234=', 1);


INSERT INTO [Students]([Id], [RegistrationOK])
VALUES
(1, 0),
(2, 1);

INSERT INTO [Teachers]([Id])
VALUES
(2);

INSERT INTO [Admins]([Id])
VALUES
(2);

SET IDENTITY_INSERT [Courses] ON;
INSERT INTO [Courses]([Id], [DomainId], [Name], [IsCollective], [IsPrincipal])
VALUES 
(1, 1, 'Art Dramatique', 1, 1),
(2, 2, 'Atelier mouvement', 1, 0),
(3, 3, 'Piano', 0, 1),
(4, 4, 'Atelier comédie musicale', 1, 1);
SET IDENTITY_INSERT [Courses] OFF;

SET IDENTITY_INSERT [Groups] ON;
INSERT INTO [Groups]([Id], [ClassroomId], [CourseId], [WeekDayId], [StartTime], [EndTime])
VALUES
(1, 1, 1, 1, '17:30', '18:20'),
(2, 2, 2, 2, '18:20', '19:10');
SET IDENTITY_INSERT [Groups] OFF;

SET IDENTITY_INSERT [Articles] ON;
INSERT INTO [Articles]([Id], [Title], [Content], [PublicationDate], [AuthorId], [GroupId])
VALUES
(1, 'Hello World', 'Blablabla', GETDATE() , 1, 1),
(2, 'Oboe Stories', 'Lorem Ipsum', GETDATE(), 2, NULL);
SET IDENTITY_INSERT [Articles] OFF;

-- Junction tables

INSERT INTO [Groups_Students]([GroupId], [StudentId], [LevelId])
VALUES
(1, 1, 6),
(1, 2, 7);

INSERT INTO [Groups_Teachers]([GroupId], [TeacherId])
VALUES
(2, 2);

