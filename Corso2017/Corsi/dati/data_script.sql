/*    ==Parametri di scripting==

    Versione server di origine : SQL Server 2016 (13.0.4001)
    Edizione motore di database di origine : Microsoft SQL Server Express Edition
    Tipo motore di database di origine : Istanza di SQL Server autonoma

    Versione server di destinazione : SQL Server 2017
    Edizione motore di database di destinazione : Microsoft SQL Server Standard Edition
    Tipo motore di database di destinazione : Istanza di SQL Server autonoma
*/

USE [Corsi]
GO
SET IDENTITY_INSERT [dbo].[Aula] ON 
GO
INSERT [dbo].[Aula] ([Id], [Codice], [Edificio]) VALUES (1, N'1A', N'Blue')
GO
INSERT [dbo].[Aula] ([Id], [Codice], [Edificio]) VALUES (2, N'1B', N'Blue')
GO
INSERT [dbo].[Aula] ([Id], [Codice], [Edificio]) VALUES (3, N'2A', N'Blue')
GO
INSERT [dbo].[Aula] ([Id], [Codice], [Edificio]) VALUES (4, N'1A', N'Red')
GO
INSERT [dbo].[Aula] ([Id], [Codice], [Edificio]) VALUES (5, N'3A', N'Red')
GO
INSERT [dbo].[Aula] ([Id], [Codice], [Edificio]) VALUES (6, N'2B', N'Red')
GO
SET IDENTITY_INSERT [dbo].[Aula] OFF
GO
SET IDENTITY_INSERT [dbo].[Corso] ON 
GO
INSERT [dbo].[Corso] ([Id], [Nome], [Id_Aula]) VALUES (1, N'C#', 1)
GO
INSERT [dbo].[Corso] ([Id], [Nome], [Id_Aula]) VALUES (2, N'C#', NULL)
GO
INSERT [dbo].[Corso] ([Id], [Nome], [Id_Aula]) VALUES (3, N'SQL', 2)
GO
INSERT [dbo].[Corso] ([Id], [Nome], [Id_Aula]) VALUES (4, N'Javascript', 4)
GO
SET IDENTITY_INSERT [dbo].[Corso] OFF
GO
INSERT [dbo].[Iscrizione] ([Matricola_Studente], [Id_Corso], [DataDiIscrizione]) VALUES (N'AAA0001', 1, NULL)
GO
INSERT [dbo].[Iscrizione] ([Matricola_Studente], [Id_Corso], [DataDiIscrizione]) VALUES (N'AAA0002', 2, NULL)
GO
INSERT [dbo].[Iscrizione] ([Matricola_Studente], [Id_Corso], [DataDiIscrizione]) VALUES (N'AAA0003', 4, NULL)
GO
INSERT [dbo].[Studente] ([Matricola], [Nome], [Cognome], [DataDiNascita]) VALUES (N'AAA0001', N'Mario', N'Rossi', NULL)
GO
INSERT [dbo].[Studente] ([Matricola], [Nome], [Cognome], [DataDiNascita]) VALUES (N'AAA0002', N'Luisa', N'Verdi', NULL)
GO
INSERT [dbo].[Studente] ([Matricola], [Nome], [Cognome], [DataDiNascita]) VALUES (N'AAA0003', N'Giovanni', N'Caccamo', NULL)
GO
