CREATE TABLE [dbo].[Corso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(50) NOT NULL, 
    [Id_Aula] INT NULL, 
    CONSTRAINT [FK_Corso_Aula] FOREIGN KEY ([Id_Aula]) REFERENCES [Aula]([Id])
)
