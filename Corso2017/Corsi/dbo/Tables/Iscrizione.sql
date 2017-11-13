CREATE TABLE [dbo].[Iscrizione] (
    [Matricola_Studente] NVARCHAR (10) NOT NULL,
    [Id_Corso]           INT           NOT NULL,
    [DataDiIscrizione]   DATETIME      NULL,
    CONSTRAINT [PK_Iscrizione] PRIMARY KEY CLUSTERED ([Matricola_Studente] ASC, [Id_Corso] ASC)
);

