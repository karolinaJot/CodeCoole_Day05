using SQL_02_Repositories;

PersonsRepository personsRepository = new PersonsRepository();

Person[] people=  personsRepository.GetPersons();

foreach (Person person in people) {
	Console.WriteLine($"{person.FirstName}  {person.LastName}");
}


