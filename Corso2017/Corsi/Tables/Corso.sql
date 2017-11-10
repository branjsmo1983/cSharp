CREATE TABLE [dbo].[Corso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(50) NOT NULL, 
    [Id_Studente] INT NULL, 
    CONSTRAINT [FK_Corso_Studente] FOREIGN KEY ([Id_Studente]) REFERENCES [Studente]([Id])
)
