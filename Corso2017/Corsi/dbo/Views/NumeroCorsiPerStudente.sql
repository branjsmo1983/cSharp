create view NumeroCorsiPerStudente as
select
	St.Nome
	,St.Cognome
	,count(*) as Nr_Corsi
from
	Studente as St
		inner join
	Iscrizione as Isc
		on St.Matricola = Isc.Matricola_Studente
group by 
	St.Nome,
	St.Cognome