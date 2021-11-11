using System;

namespace Solution.Capture5
{
    internal class SMS
    {
        public void MmNewMail(object sender, NewMailEventArgs e)
        {
            Console.WriteLine($"{sender} {e.From}");
        }
        public void Send(string message)
        {
            Console.WriteLine($"sending sms messages: \r\n{message}\r\n");
        }
    }
}
