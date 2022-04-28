using System;
using System.Data;
using System.Data.SqlClient;

namespace Solution.BAssesData.FirstConnectionToSql
{
    class Program
    {
        public static string connectionString = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        static async Task Main(string[] args)
        {
            //await CreaterSqlValues();
            //SQLCreater();
            await ExecuteScalarAsync();

            Console.ReadKey();
        }

        #region created_Sql
        public static async Task CreaterSqlValues()
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
        #endregion

        #region SqlDataReater

        public async static Task SQLCreater()
        {
            await RunnerSqlReaderAsyncVAR1();
            await RunnerSqlReaderAsyncVAR2();
            RunnerSqlReader();
        }
        public async static Task RunnerSqlReaderAsyncVAR1()
        {
            string commandText = "USE adonetdb; SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(commandText, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);
                    string columnName3 = reader.GetName(2);

                    Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

                    while(await reader.ReadAsync())
                    {
                        object id = reader.GetValue(0);
                        object age = reader[1];
                        object name = reader["name"];
                        

                        Console.WriteLine($"{id} \t{name} \t{age}");
                    }

                }
                await reader.CloseAsync();

            }


        }
        public async static Task RunnerSqlReaderAsyncVAR2()
        {
            string commandText = "USE productsdb; SELECT * FROM ORDERS";

            using (SqlConnection connection = new(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new(commandText, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        string columnName0 = reader.GetName(0);
                        string columnName1 = reader.GetName(1);
                        string columnName2 = reader.GetName(2);
                        string columnName3 = reader.GetName(3);
                        string columnName4 = reader.GetName(4);
                        string columnName5 = reader.GetName(5);

                        Console.WriteLine($"{columnName0}\t{columnName1}\t{columnName2}\t{columnName3}\t\t{columnName4}\t{columnName5}");

                        while (await reader.ReadAsync())
                        {
                            object id = reader.GetValue(0);
                            object ProductId = reader.GetValue(1);
                            object CustomerId = reader[2];
                            object CreatedAt = reader[3];
                            int ProductCount = reader.GetInt32(4);
                            object Price = reader["Price"];

                            Console.WriteLine($"{id}\t{ProductId}\t\t{CustomerId}\t\t{CreatedAt}\t{ProductCount}\t\t{Price}");
                        }

                    }

                }
            }
        }            
        public static void RunnerSqlReader()
        {
            string commandText = "USE productsdb; SELECT * FROM Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        string columnName0 = reader.GetName(0);
                        string columnName1 = reader.GetName(1);
                        string columnName2 = reader.GetName(2);
                        string columnName3 = reader.GetName(3);
                        string columnName4 = reader.GetName(4);

                        Console.WriteLine($"{columnName0}\t\t{columnName1}\t\t{columnName2}\t\t{columnName3}\t\t{columnName4}");

                        while (reader.Read())
                        {
                            object Id = reader.GetValue(0);
                            string Name = reader.GetString(1);
                            object Manufacturer = reader[2];
                            object Count = reader["ProductCount"];
                            decimal Price = reader.GetDecimal("Price");

                            Console.WriteLine($"{Id}\t\t{Name}\t\t{Manufacturer}\t\t{Count}\t\t{Price}");
                        }

                    }



                }
            }
        }
        #endregion

        #region ExecuteScalar
        public async static Task ExecuteScalarAsync()
        {
            string commandString1 = "USE productsdb; SELECT Count(*) FROM SummaryProducts";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(commandString1, connection);
                object? countRows =  command.ExecuteScalar();

                command.CommandText = "select min(Productcount) from summaryproducts";
                object? productCountsMin = command.ExecuteScalar();

                command.CommandText = "SELECT MAX(SummaryPrice) FROM SummaryProducts";
                object? productCountsMax = await command.ExecuteScalarAsync();

                command.CommandText = "SELECT AVG(SummaryPrice) FROM SummaryProducts";
                object? productCountsAvg = await command.ExecuteScalarAsync();

                Console.WriteLine($"кол-во строк в таблице: {countRows}");
                Console.WriteLine($"минимальное кол-во группы товаров: {productCountsMin}");
                Console.WriteLine($"максимальная общая сумма группы товаров: {productCountsMax}");
                Console.WriteLine($"средняя общая сумма группы товаров: {productCountsAvg}");
            }

        }
        #endregion



    }
}
