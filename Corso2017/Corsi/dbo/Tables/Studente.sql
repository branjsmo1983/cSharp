CREATE TABLE [dbo].[Studente] (
    [Matricola]   NVARCHAR(10)           NOT NULL,
    [Nome] NVARCHAR (50) NOT NULL,
    [Cognome] NVARCHAR(50) NOT NULL, 
    [DataDiNascita] DATE NULL, 
    PRIMARY KEY CLUSTERED ([Matricola] ASC)
);
