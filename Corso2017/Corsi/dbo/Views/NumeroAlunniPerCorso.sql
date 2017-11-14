
CREATE view [dbo].[NumeroAlunniPerCorso] as
select 
	--c.Id,
	c.Nome Corso,
	doc.Nome + ' ' + doc.Cognome Docente,
	count(isc.Id_Corso) as N_Alunni
 from
	Corso as c
	inner join 
	Docente as Doc on 
		Doc.CodiceFiscale = c.CF_Docente
	left join 
	Iscrizione as isc on 
		isc.Id_Corso = c.Id
 group by 
	c.Id,
	c.Nome, 
	doc.Nome + ' ' + doc.Cognome