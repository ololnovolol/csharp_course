using System;
using System.IO;
using System.Net.Sockets;

namespace Solutiom.BaseNetwork_StreamsBinaryData_Klient
{
    internal class Program
    {

        const int PORT = 5006;
        const string ADDRESS = "127.0.01";

        static void Main(string[] args)
        {
            TcpClient clien = null;
            try
            {
                Console.WriteLine("for registration your sum..write yuor data");
                Console.WriteLine("Write your Name");
                string name = Console.ReadLine();

                Console.WriteLine("write your sum deposite");
                decimal sum = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Write your period save money in mounts");
                int period = int.Parse(Console.ReadLine());

                clien = new TcpClient(ADDRESS, PORT);
                NetworkStream stream = clien.GetStream();

                BinaryWriter bw = new BinaryWriter(stream);
                bw.Write(name);
                bw.Write(sum);
                bw.Write(period);
                bw.Flush();

                BinaryReader br = new BinaryReader(stream);
                string accNumber = br.ReadString();
                Console.WriteLine("Your account number" + accNumber);

                bw.Close();
                br.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                clien.Close();
            }


        }
    }
}
