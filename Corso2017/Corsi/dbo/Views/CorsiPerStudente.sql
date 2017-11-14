CREATE view CorsiPerStudente as
select
	s.Nome,
	s.Cognome,
	c.Nome Corso,
	a.Codice + ' - ' + a.Edificio  Aula
from
	Studente s
	inner join 
	Iscrizione i on 
		s.Matricola = i.Matricola_Studente
	inner join
	Corso c on 
		i.Id_Corso = c.Id
	left join
	Aula a on
		c.Id_Aula = a.Id
--where
--	s.Matricola = 'AAA0002'