using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Solution.BAssesData.FirstConnectionToSql
{
    class Program
    {
        public static string connectionString = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        static async Task Main(string[] args)
        {
   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("подключение открыто");

                //await SqlCommandCreateDatabase(connection, nameBase:"adonetdb");
                //await SqlCommandCreateTable(connection, "adonetdb");
                await SqlCommandInsertToTable(connection, "bob", 32);
                await SqlCommandInsertToTable(connection, "bob", 28);
                //await SqlCommandInsertToTable(connection);
                //await SQlCommanUpdateDataTAble(connection);
                await SQlCommanDeleteDataTAble(connection);




            }
            Console.WriteLine("Подключение закрыто");
            Console.WriteLine("Программа завершила работу");
            Console.ReadKey();

        }

        public static void ConnectionInfo(SqlConnection connection)
        {         
            Console.WriteLine($"\tСвойства подключения:");
            Console.WriteLine($"\t\tстрока подключения: {connection.ConnectionString}");
            Console.WriteLine($"\t\tСервер: {connection.Database}");
            Console.WriteLine($"\t\tВерсия сервера: {connection.ServerVersion}");
            Console.WriteLine($"\t\tСостояние: {connection.State}");
            Console.WriteLine($"\t\tWorkStation: {connection.WorkstationId}");
        }
        public static async Task SqlCommandCreateDatabase(SqlConnection connection, string nameBase)
        {
            SqlCommand command = new SqlCommand(connectionString);
            command.CommandText = $"CREATE DATABASE {nameBase}";
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
            Console.WriteLine("База создана");
        }
        public static async Task SqlCommandCreateTable(SqlConnection connection, string nameBase)
        {
            SqlCommand command = new SqlCommand(connectionString);
            command.CommandText = $"USE {nameBase}; CREATE TABLE Users (Id INT IDENTITY PRIMARY KEY,Name NVARCHAR(100) NOT NULL, Age INT NOT NULL) ";
            command.Connection = connection;
            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Таблица создана");
        }
        public static async Task SqlCommandInsertToTable(SqlConnection connection)
        {
            string CommandText = $"use adonetdb; INSERT INTO Users (Name, Age) VAlUES ('TOM', 11),('BOB', 12),('SAM', 13),('TIM', 14),('BEN',15)";
            SqlCommand command = new SqlCommand(CommandText, connection);
                     
            int countLineAdded = await command.ExecuteNonQueryAsync();

            Console.WriteLine($"Добавлено объектов: {countLineAdded}");
        }
        public static async Task SqlCommandInsertToTable(SqlConnection connection, string name, int age)
        {
            string commandTest = $"USE adonetdb; INSERT INTO Users (Name, Age) VALUES ('{name}', {age})";
            SqlCommand command = new SqlCommand(commandTest, connection);

            int countLineAdded = await command.ExecuteNonQueryAsync();

            Console.WriteLine($"Добавлено объектов: {countLineAdded}");
        }

        public static async Task SQlCommanUpdateDataTAble(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("USE adonetdb; UPDATE Users SET Age = 99 WHERE Age < 15", connection);

            int numbersChange = await sqlCommand.ExecuteNonQueryAsync();
            Console.WriteLine($"Изменено  {numbersChange} обьектов");
        }

        public static async Task SQlCommanDeleteDataTAble(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("USE adonetdb; DELETE FROM Users where Name = 'BOB' ", connection);
            int numbersChange = await command.ExecuteNonQueryAsync();

            Console.WriteLine($"Удалено  {numbersChange} обьектов");
        }
    }
}
