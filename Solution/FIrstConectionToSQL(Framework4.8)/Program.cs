using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FIrstConectionToSQL_Framework4._8_
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server =.;Database=master;Trusted_Connection=True;";

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                await connection.OpenAsync();
                System.Console.WriteLine("подключение открыто");
            }
            catch(SqlException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    System.Console.WriteLine("Подключение закрыто");
                }
            }
            System.Console.WriteLine("Программа завершила работу");
            System.Console.ReadKey();

        }
    }
}
