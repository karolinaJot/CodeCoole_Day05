using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_02_Repositories
{
	internal class PersonsRepository
	{
		private string connectionString =
"Data Source=(localdb)\\mssqllocaldb; Initial Catalog = PersonTestDatabase; Integrated Security = True; Pooling = False";

		public Person[] GetPersons()
		{
			List<Person> persons = new List<Person>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName FROM Persons", connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Person person = new Person();
							person.Id = reader.GetInt32(0);
							person.FirstName = reader.GetString(1);
							person.LastName = reader.GetString(2);

							persons.Add(person);
						}
					}
				}
			}
			return persons.ToArray();
		}
		public void CreatePerson(Person person)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				connection.Open();


				using (SqlCommand command = new SqlCommand("INSERT INTO Persons (FirstName,LastName) VALUES(@FirstName, @LastName)", connection))
				{
					command.Parameters.AddWithValue("@FirstName", person.FirstName);
					command.Parameters.AddWithValue("@LastName", person.LastName);
					int rowsAffected = command.ExecuteNonQuery();
					//Console.WriteLine($"{rowsAffected} rows affected.");
				}






			}

		}

		public void DeletePerson(int id)
		{

			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				connection.Open();

				using (SqlCommand command = new SqlCommand("DELETE FROM Persons WHERE Id = @Id", connection))
				{
					command.Parameters.AddWithValue("@Id", id);
					int rowsAffected = command.ExecuteNonQuery();
					//Console.WriteLine($"{rowsAffected} rows affected.");
				}
			}
		}

		public void UpdatePerson(Person person)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				connection.Open();

				using (SqlCommand command = new SqlCommand("UPDATE Persons SET FirstName = @FirstName, LastName =@LastName WHERE Id = @Id", connection))
				{
					command.Parameters.AddWithValue("@Id", person.Id);
					command.Parameters.AddWithValue("@FirstName", person.FirstName);
					command.Parameters.AddWithValue("@LastName", person.LastName);
					int rowsAffected = command.ExecuteNonQuery();
					Console.WriteLine($"{rowsAffected} rows affected.");
				}
			}
		}

		public void TestingMethod(int a, int b, int c)
		{

		}
		public void TestingMethod2(int[] arr)
		{

		}
		// you can add much parameters as you want 
		public void TestingMethod3(params int[] arr)
		{

		}
	}
}


