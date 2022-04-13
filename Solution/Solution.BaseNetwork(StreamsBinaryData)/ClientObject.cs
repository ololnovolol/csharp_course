using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Solution.BaseNetwork_StreamsBinaryData_
{
    internal class ClientObject
    {
        public TcpClient client;

        public ClientObject(TcpClient tcpClient) => client = tcpClient;

        public void Proces()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                BinaryReader br = new BinaryReader(stream);
                // read Data with Thread
                string name = br.ReadString();
                decimal sum = br.ReadDecimal();
                int period = br.ReadInt32();

                Account acc = new Account(name, sum, period);

                Console.WriteLine($"{acc.Name} registrated his Account on sum ={sum}");

                // send a response in the form of an account number

                BinaryWriter bw = new BinaryWriter(stream);
                bw.Write(acc.Id);

                bw.Flush();

                br.Close();
                bw.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(stream != null) stream.Close();
                if(client != null) client.Close();
            }

        }
  

    }
}
