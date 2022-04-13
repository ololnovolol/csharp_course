using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Solution.BaseNetwork_Send_mail_SmtpClient_
{
    internal class Program
    {
        // к письму мы можем приложить Вложения свойство Attachment
        //MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
        //MailAddress to = new MailAddress("somemail2@yandex.ru");
        //MailMessage m = new MailMessage(from, to);
        //m.Attachments.Add(new Attachment("D://temlog.txt"));


        static void Main(string[] args)
        {
            BasevershioSendEmail();
            //SendEmailAsync().GetAwaiter();

            Console.ReadKey();

        }

        public static void BasevershioSendEmail()
        {

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("vdvdfvdfv@gmail.com", "Oleg from VS");
            // кому отправляем
            MailAddress to = new MailAddress("dfvdfvdfvdv@gmail.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("asascdsac@gmail.com", "qwerty");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
        }

        private static async Task SendEmailAsync()
        {
            MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
            MailAddress to = new MailAddress("somemail@yandex.ru");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "Письмо-тест 2 работы smtp-клиента";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
            Console.WriteLine("Письмо отправлено");
        }
    }
}
