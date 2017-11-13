CREATE TABLE [dbo].[corso]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Id_Studente] INT NULL, 
    [Nome] NCHAR(10) NULL, 
    CONSTRAINT [FK_corso_Studente] FOREIGN KEY ([Id_studente]) REFERENCES [Studente]([Id])
)
