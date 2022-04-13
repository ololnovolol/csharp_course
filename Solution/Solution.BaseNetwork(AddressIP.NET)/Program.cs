using System;
using System.Net;

namespace Solution.BaseNetwork_AddressIP.NET_
{
    class Program
    {
        public static void Main(string[] args)
        {
            IPHostEntry host1 = Dns.GetHostEntry("naztextile.com");
            Console.WriteLine(host1.HostName);

            foreach (var ip in host1.AddressList)
            {
                Console.WriteLine(ip.ToString());
            }

            Console.WriteLine();

            IPHostEntry host2 = Dns.GetHostEntry("google.com");
            Console.WriteLine(host2.HostName);

            foreach (var ip in host2.AddressList)
            {
                Console.WriteLine(ip.ToString());
            }

        }

    }



}
