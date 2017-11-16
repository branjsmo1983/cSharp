CREATE TABLE [dbo].[Person] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Surname]     NVARCHAR (50) NOT NULL,
    [DateOfBirth] DATE          NULL,
    [NationalityId] INT NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Person_Nationality] FOREIGN KEY ([NationalityId]) REFERENCES [Nationality]([Id])
);

