using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Solution.BaseNetwork_StreamsBinaryData_
{
    internal class Program
    {
        const int PORT = 5006;
        static TcpListener listener;

        static void Main(string[] args)
        {

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"),PORT);
                listener.Start();
                Console.WriteLine("waiting for a connection....");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObj = new ClientObject(client);

                    //create a new thread to serve a new client

                    Task clientTask = new Task(clientObj.Proces);
                    clientTask.Start();

                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(listener != null) listener.Stop();
            }

        }
    }
}
