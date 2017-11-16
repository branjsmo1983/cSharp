CREATE TABLE [dbo].[Nationality]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Nationality_Column] ON [dbo].[Nationality] ([Name])
