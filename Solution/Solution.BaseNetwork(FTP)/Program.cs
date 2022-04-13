using System;
using System.IO;
using System.Net;
using System.Text;

namespace FtpConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // BaseFTP();
            //ServerFtpInfo();
            LoadFileOnFTP();
        }

        static void BaseFTP()
        {
            // Создаем объект FtpWebRequest
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.86.150:55015/test.txt");
            // устанавливаем метод на загрузку файлов
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // если требуется логин и пароль, устанавливаем их
            //request.Credentials = new NetworkCredential("login", "password");

            //request.EnableSsl = true; // если используется ssl

            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            // получаем поток ответа
            Stream responseStream = response.GetResponseStream();
            // сохраняем файл в дисковой системе
            // создаем поток для сохранения файла
            FileStream fs = new FileStream("newTest.txt", FileMode.Create);

            //Буфер для считываемых данных
            byte[] buffer = new byte[64];
            int size = 0;

            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);

            }
            fs.Close();
            response.Close();

            Console.WriteLine("Загрузка и сохранение файла завершены");
            Console.Read();
        }

        static void ServerFtpInfo()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.86.150:42548");

            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Содержимое сервера:");
            Console.WriteLine();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
            responseStream.Close();
            response.Close();
            Console.Read();
        }

        static void LoadFileOnFTP()
        {
            // Создаем объект FtpWebRequest - он указывает на файл, который будет создан
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.86.150:42548");
            // устанавливаем метод на загрузку файлов
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // создаем поток для загрузки файла
            FileStream fs = new FileStream(@"\\test.txt", FileMode.Open);
            byte[] fileContents = new byte[fs.Length];
            fs.Read(fileContents, 0, fileContents.Length);
            fs.Close();
            request.ContentLength = fileContents.Length;

            // пишем считанный в массив байтов файл в выходной поток
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Загрузка файлов завершена. Статус: {0}", response.StatusDescription);

            response.Close();
            Console.Read();
        }
    }
}