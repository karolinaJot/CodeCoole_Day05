using Microsoft.Data.SqlClient;



string connectionString =
"Data Source=(localdb)\\mssqllocaldb; Initial Catalog = PersonTestDatabase; Integrated Security = True; Pooling = False";

using (SqlConnection connection = new SqlConnection(connectionString))
{

	connection.Open();


	//using (SqlCommand command = new SqlCommand("INSERT INTO Persons (FirstName,LastName) VALUES(@FirstName, @LastName)", connection))
	//{
	//	command.Parameters.AddWithValue("@FirstName", "John");
	//	command.Parameters.AddWithValue("@LastName", "Doe");
	//	int rowsAffected = command.ExecuteNonQuery();
	//	Console.WriteLine($"{rowsAffected} rows affected.");
	//}


	//using (SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName FROM Persons", connection))
	//{
	//	using (SqlDataReader reader = command.ExecuteReader())
	//	{
	//		while (reader.Read())
	//		{
	//			Console.WriteLine($"Id: {reader.GetInt32(0)}," +
	//				$" FirstName:{reader.GetString(1)}," +
	//				$" LastName: {reader.GetString(2)}");
	//		}
	//	}
	//}

	using (SqlCommand command = new SqlCommand("UPDATE Persons SET FirstName = @FirstName WHERE Id = @Id", connection))
	{
		command.Parameters.AddWithValue("@Id", 1);
		command.Parameters.AddWithValue("@FirstName", "UpdatedFirstName");
		int rowsAffected = command.ExecuteNonQuery();
		Console.WriteLine($"{rowsAffected} rows affected.");
	}


	using (SqlCommand command = new SqlCommand("DELETE FROM Persons WHERE Id = @Id",connection))
	{
		command.Parameters.AddWithValue("@Id", 1);
		int rowsAffected = command.ExecuteNonQuery();
		Console.WriteLine($"{rowsAffected} rows affected.");
	}



}