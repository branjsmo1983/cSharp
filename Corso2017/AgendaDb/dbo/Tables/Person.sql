CREATE TABLE [dbo].[Person] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Surname]     NVARCHAR (50) NOT NULL,
    [DateOfBirth] DATE          NULL,
    [Nationality] NVARCHAR (20) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([ID] ASC)
);

