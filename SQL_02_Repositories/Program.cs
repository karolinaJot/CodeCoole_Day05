using SQL_02_Repositories;

PersonsRepository personsRepository = new PersonsRepository();

Person[] people=  personsRepository.GetPersons();

Person newPerson = new Person()
{
	FirstName = "jan",
	LastName = "kowalski"
};

personsRepository.CreatePerson(newPerson);
personsRepository.DeletePerson(1);

foreach (Person person in people) {
	Console.WriteLine($"{person.FirstName}  {person.LastName}");
}


personsRepository.TestingMethod(1, 2, 3);

