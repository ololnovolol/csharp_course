using System;
using Microsoft.Data;
using Microsoft.Data.Sqlite;

namespace Solution.BAsses.Data.SQlite
{
    class Program
    {
        public static string connectionString = "Data Source=usersdata.db";
        public static void Main(string[] args)
        {
            Runner();


            Console.Read();

        }

        public static void Runner()
        {
            using (SqliteConnection connection = new(connectionString))
            {
                connection.Open();

                string sqCommand1 = "CREATE TABLE Users (Id INTEGER NUT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    "name TEXT NOT NULL, age INTEGER NOT NULL)";
                string sqCommand2 = "INSERT INTO Users (Name, Age) VALUES ('Sam', 25),('Bob', 33),('Tom', 77);";

                string sqCommand3 = "UPDATE Users SET Age = 17 WHERE Age = 77;";

                string sqCommand4 = "DELETE FROM Users WHERE Name = 'bob';";

                string sqCommand5 = "SELECT * FROM Users;";

                SqliteCommand command = new SqliteCommand(sqCommand5, connection);

                command.ExecuteNonQuery();

                Console.WriteLine($"В таблицу Users добавлено");

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var id = reader.GetValue(0);
                            var name = reader.GetValue(1);
                            var age = reader.GetValue(2);

                            Console.WriteLine($"{id} \t {name} \t {age}");
                        }
                    }
                }
            }
        }

    }
}