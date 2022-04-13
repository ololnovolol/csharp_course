using System;
using System.Net;

namespace Solution.BaseNetwork_WebClient_
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //DownloadStream();
            //DownloadStreamAsync();
            //WebRequestResponse();

        }

        static void DownloadFile()
        {
            WebClient client = new WebClient();
            client.DownloadFile("http://somesite.com/book.pdf", "myBook.pdf");
            Console.WriteLine("downloaded");
        }

        static void DownloadStream()
        {
            WebClient client = new WebClient();
            using (Stream stream = client.OpenRead("https://lyricsworld.ru/Mozgi/Polyubye-889758.html"))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("File Download");
            Console.WriteLine();
        }
        static void DownloadStreamAsync()
        {

            DownloadFileAsync().GetAwaiter();

            Console.WriteLine("Файл загружен");
            Console.Read();


        }
        private static async Task DownloadFileAsync()
        {
            WebClient client = new WebClient();
            await client.DownloadFileTaskAsync(new Uri("https://lyricsworld.ru/Mozgi/Polyubye-889758.html"), "mytxtFile.txt");
        }
        public static void WebRequestResponse()
        {
            WebRequest request = WebRequest.Create("https://lyricsworld.ru/Mozgi/Polyubye-889758.html");
            WebResponse response = request.GetResponse();


            using(Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {

                    string line = "";
                    while((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }


                }

            }
            response.Close();
            Console.WriteLine("request finish");
            Console.WriteLine();

        }

    }
}

