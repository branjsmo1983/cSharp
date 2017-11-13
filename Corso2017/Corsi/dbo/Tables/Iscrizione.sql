CREATE TABLE [dbo].[Iscrizione] (
    [Matricola_Studente] NVARCHAR (10) NOT NULL,
    [Id_Corso]           INT           NOT NULL,
    [DataDiIscrizione]   DATETIME      NULL,
    CONSTRAINT [PK_Iscrizione] PRIMARY KEY CLUSTERED ([Matricola_Studente] ASC, [Id_Corso] ASC),
    CONSTRAINT [FK_Iscrizione_Corso] FOREIGN KEY ([Id_Corso]) REFERENCES [dbo].[Corso] ([Id]),
    CONSTRAINT [FK_Iscrizione_Studente] FOREIGN KEY ([Matricola_Studente]) REFERENCES [dbo].[Studente] ([Matricola])
);



