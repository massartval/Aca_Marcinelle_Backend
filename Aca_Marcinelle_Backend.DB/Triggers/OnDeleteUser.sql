CREATE TRIGGER [OnDeleteUser]
	ON [dbo].[Users]
	FOR DELETE
	AS
	BEGIN
		UPDATE [Users] SET [IsActive] = 0
		WHERE [Id] LIKE (SELECT [Id] FROM [deleted])
	END;