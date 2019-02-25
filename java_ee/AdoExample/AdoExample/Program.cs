using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace AdoExample
{
	class Program
	{
		private const string ConnectionString =
				"User ID=ina;Password=inxy79!!;Host=localhost;Port=5432;Database=java_ee;";

		static void Main(string[] args)
		{
			using (var connection = new NpgsqlConnection(ConnectionString))
			{
				connection.Open();

				var transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
				using (var cmd = new NpgsqlCommand("SELECT * FROM users", connection))
				{
					using (var result = cmd.ExecuteReader())
					{
						while (result.Read())
						{
							var id     = result.GetInt32(0);
							var login  = result.GetString(1);
							var rating = result.GetInt32(2);
							Console.ForegroundColor = (ConsoleColor) id;
							Console.WriteLine($"Id: {id,5} | Login: {login,10} | Rating: {rating,5}");
						}
					}
				}

				transaction.Commit();
			}
		}
	}
}