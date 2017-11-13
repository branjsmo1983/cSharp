CREATE TABLE [dbo].[Docente]
(
	[CodiceFiscale] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(50) NOT NULL, 
    [Cognome] NVARCHAR(50) NOT NULL, 
    [DataDiNascita] DATE NULL, 
    [Telefono] NVARCHAR(50) NULL
)
