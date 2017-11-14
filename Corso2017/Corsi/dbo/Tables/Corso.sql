CREATE TABLE [dbo].[Corso] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Nome]       NVARCHAR (50) NOT NULL,
    [Id_Aula]    INT           NULL,
    [CF_Docente] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK__Corso__3214EC07811DF158] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Corso_Aula] FOREIGN KEY ([Id_Aula]) REFERENCES [dbo].[Aula] ([Id]),
    CONSTRAINT [FK_Corso_Docente] FOREIGN KEY ([CF_Docente]) REFERENCES [dbo].[Docente] ([CodiceFiscale])
);


