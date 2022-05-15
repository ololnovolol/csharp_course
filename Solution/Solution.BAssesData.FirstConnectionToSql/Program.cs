using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Solution.BAssesData.FirstConnectionToSql
{
    class Program
    {
        public static string connectionString = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        public static async Task Main(string[] args)
        {
            await CreaterSqlValues();
            await SQLCreater();
            await ExecuteScalarAsync();
            await UseParametersSqlAsync();
            await UseProcedure();
            await SaveAndPutDataFromSQL();
            DataAdapterRunner();

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

                    while (await reader.ReadAsync())
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(commandString1, connection);
                object? countRows = command.ExecuteScalar();

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

        #region UseParametersSql
        public async static Task UseParametersSqlAsync()
        {
            string nameLong = "123456789";
            string namePlusComand = "Tom',10);INSERT INTO Users (Name, Age) VALUES('Hack";
            int age = 333;

            using (SqlConnection connection = new(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand($"use adonetdb;INSERT INTO Users(Name, Age) VALUES(@name, @age); SET @Id = scope_IDENTITY()", connection);
                SqlParameter paramName2 = new SqlParameter("@name", SqlDbType.NVarChar, 3);
                paramName2.Value = nameLong;
                command.Parameters.Add(paramName2);
                SqlParameter paramAge = new SqlParameter("@age", age);
                command.Parameters.Add(paramAge);
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // параметр выходной
                };
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();

                Console.WriteLine($"Id нового объекта: {idParam.Value}");

                SqlCommand command1 = new SqlCommand($"use adonetdb; INSERT INTO Users (Name, age) VALUES (@name, @age)", connection);
                paramName2 = new SqlParameter("@name", SqlDbType.NVarChar, 6);
                paramName2.Value = namePlusComand;
                command1.Parameters.Add(paramName2);
                SqlParameter paramAge1 = new SqlParameter("@age", age);
                command1.Parameters.Add(paramAge);
                await command1.ExecuteNonQueryAsync();


                //вывод на консоль
                command.CommandText = "select * from Users";
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        string ColumnName1 = reader.GetName(0);
                        string ColumnName2 = reader.GetName(1);
                        string ColumnName3 = reader.GetName(2);

                        Console.WriteLine($"{ColumnName1}\t{ColumnName2}\t{ColumnName3}");

                        while (await reader.ReadAsync())
                        {
                            object? Id = reader.GetValue(0);
                            object? Name = reader.GetValue(1);
                            object? Age = reader.GetValue(2);

                            Console.WriteLine($"{Id}\t{Name}\t{Age}");
                        }
                    }

                }

            }
        }

        #endregion

        #region  StoredProcedurs
        public static async Task StoredProcedurs()
        {
            string UsingDataBase = "USE adonetdb;";

            //string procedureInsert = "CREATE PROCEDURE [dbo].[sp_InsertUser] @name nvarchar(50), @age int " +
            //    "AS " +
            //    "INSERT INTO Users(Name, Age) " +
            //    "VALUES(@name, @age) " +
            //    "SELECT SCOPE_IDENTITY() GO ";

            //string procedure_2 = " CREATE PROCEDURE [dbo].[sp_GetUsers] " +
            //    "AS " +
            //    "SELECT * FROM Users " +
            //    "GO ";
            string procedure_3 = " CREATE PROCEDURE [dbo].[sp_GetAgeRange] " +
                "@name nvarchar(50), " +
                "@minAge int out, " +
                "@maxAge int out " +
                "AS  " +
                " SELECT @minAge = MIN(Age), @maxAge = MAX(Age) FROM Users WHERE Name LIKE '%' + @name + '%';";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(UsingDataBase, connection);
                await command.ExecuteNonQueryAsync();

                //command.CommandText = procedureInsert;
                //await command.ExecuteNonQueryAsync();

                //command.CommandText = procedure_2;
                //await command.ExecuteNonQueryAsync();

                command.CommandText = procedure_3;
                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Procedure  added to SQL");

            }

        }
        public static async Task UseProcedure()
        {
            await StoredProcedurs();
            string name = "Kolyan3";
            int age = 55;

            await AddToPrecedureUsERSaSYNC(name, age);
            Console.WriteLine();
            await GetUsersAsync();
            Console.WriteLine();
            await OutParams("Kolyan");
            await TransactionsBase();

        }
        public static async Task AddToPrecedureUsERSaSYNC(string name, int age)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("USE adonetdb", connection);
                command.ExecuteNonQuery();

                command.CommandText = "sp_InsertUser";

                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParameter = new SqlParameter("@name", name);
                command.Parameters.Add(nameParameter);

                SqlParameter AgeParameter = new SqlParameter("@age", age);
                command.Parameters.Add(AgeParameter);

                Console.WriteLine($"ид добавленного параметра: {await command.ExecuteScalarAsync()} ");

            }

        }
        public static async Task GetUsersAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("USE adonetdb", connection);
                command.ExecuteNonQuery();

                command.CommandText = "sp_GetUsers";
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}");

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetValue(0)}\t{reader.GetValue(1)}\t{reader.GetValue(2)}");
                        }
                    }
                }
            }


        }
        public static async Task OutParams(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand("USE adonetdb;", connection);
                command.ExecuteNonQuery();

                command.CommandText = "sp_GetAgeRange";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                command.Parameters.Add(nameParam);

                SqlParameter minAgeParam = new SqlParameter
                {
                    ParameterName = "@minAge",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(minAgeParam);

                SqlParameter maxAgeParam = new SqlParameter
                {
                    ParameterName = "@maxAge",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(maxAgeParam);

                await command.ExecuteNonQueryAsync();
                object minAge = command.Parameters[1].Value;
                object maxAge = command.Parameters["@maxAge"].Value;

                Console.WriteLine($"FOR {name} Range age:\nminimal Age {minAge}\tmaximal Age {maxAge}");

            }

        }
        public static async Task TransactionsBase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();

                command.Transaction = transaction;
                command.CommandText = "USE adonetdb;";
                await command.ExecuteNonQueryAsync();

                try
                {
                    command.CommandText = "INSERT INTO Users (Name, Age) VALUES ('rfr',123);";
                    await command.ExecuteNonQueryAsync();

                    command.CommandText = "INSERT INTO Users (Name, Age) VALUES ('ghgh',8);";
                    await command.ExecuteNonQueryAsync();

                    await transaction.CommitAsync();
                    Console.WriteLine("Data is trancend to DataBase");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await transaction.RollbackAsync();
                }

            }

        }
        #endregion

        #region SaveAndPutDataFromSQL
        public static async Task SaveAndPutDataFromSQL()
        {
            //await CreateDBAsync("filedb");
            string newConnectionString = connectionString.Replace("Database=master", "Database=filedb");
            //await CreateTableAsync(newConnectionString);
            //await AddFilesToBaseAsynk(newConnectionString,
            //    @$"D:\OlegLearning\csharp_course\Solution\Solution.BAssesData.FirstConnectionToSql\logoImages\logoFaceboock.jpg"
            //    , "faceboock");
            //await AddFilesToBaseAsynk(newConnectionString,
            //    @$"D:\OlegLearning\csharp_course\Solution\Solution.BAssesData.FirstConnectionToSql\logoImages\logoInstagramm.jpg"
            //    , "instagramm");
            //await AddFilesToBaseAsynk(newConnectionString,
            //    @$"D:\OlegLearning\csharp_course\Solution\Solution.BAssesData.FirstConnectionToSql\logoImages\logoTelegram.jpg"
            //    , "telegram");

            await ReadFileFromDatabaseAsync(newConnectionString);



        }

        public static async Task CreateDBAsync(string baseName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand($"CREATE  DATABASE {baseName}", connection);

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Base is Created");
            }
        }
        public static async Task CreateTableAsync(string newConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(newConnectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand($"CREATE TABLE Files (Id INT PRIMARY KEY IDENTITY, Title NVARCHAR(200) NOT NULL,FileName NVARCHAR(200)NOT NULL,ImageData varbinary(MAX))", connection);

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table has been Created<");

            }
        }
        public static async Task AddFilesToBaseAsynk(string newConnectionString, string fileName, string title)
        {
            using (SqlConnection connection = new SqlConnection(newConnectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(@"INSERT INTO Files VALUES (@FileName, @Title, @ImageData)", connection);
                command.Parameters.Add("@FileName", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Title", SqlDbType.NVarChar, 50);

                string shortFileName = fileName[(fileName.LastIndexOf('\\') + 1)..];

                byte[] imageData;

                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                    command.Parameters.Add("@ImageData", SqlDbType.Image, Convert.ToInt32(fs.Length));
                }

                command.Parameters["@FileName"].Value = shortFileName;
                command.Parameters["@Title"].Value = title;
                command.Parameters["@ImageData"].Value = imageData;

                await command.ExecuteNonQueryAsync();
                Console.WriteLine("File Saved");
            }


        }

        public static async Task ReadFileFromDatabaseAsync(string newConnectionString)
        {
            List<Image> images = new List<Image>();

            using (SqlConnection connection = new SqlConnection(newConnectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Files", connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Image image = new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (byte[])reader.GetValue(3));
                        images.Add(image);
                    }
                }
                for (int i = 0; i < images.Count; i++)
                {
                    using (FileStream fs = new FileStream(path: images[i].Filename ?? "scsc", FileMode.OpenOrCreate))
                    {
                        fs.Write(images[i].Data, 0, images[i].Data.Length);
                        Console.WriteLine($"Файл {images[0].Title} сохранен");
                    }
                }
            }
        }

        #endregion

        #region Sq;DataReader_DataAdapter
        public static void DataAdapterRunner()
        {
            string newConnectionString = connectionString.Replace("Database=master", "Database=adonetdb");

            using (SqlConnection connection = new SqlConnection(newConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("USE adonetdb; SELECT * FROM Users", connection);

                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                foreach (DataTable dataTable in dataSet.Tables)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        Console.Write(column.ColumnName + "\t");
                    }
                    Console.WriteLine();

                    foreach (DataRow rows in dataTable.Rows)
                    {

                        var cells = rows.ItemArray;

                        foreach (object? cell in cells)
                        {
                            Console.Write(cell + "\t");

                        }
                        Console.WriteLine();

                    }

                }


            }



        }


        #endregion


    }
}
