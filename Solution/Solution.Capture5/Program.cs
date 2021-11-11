using System;
using OlolLybrary;

namespace Solution.Capture5
{
    class Program
    {
        /// <summary>
        /// training with delegates
        /// </summary>
        delegate void Shmelegate();
        delegate int Prilegate(int y, int x);
        delegate T Operation<T, K>(K val, K val1);
        delegate T OperationRef<T, K>(ref K val, ref K val1);
        //delegate void EvantHandler<T>(string from, string to, string subject);
        static void Main(string[] args)
        {
            Smelegator();

            MyCleaner.Clear();
            Console.ReadKey();
        }

        public static void Smelegator()
        {
            Shmelegate shm = Hello;
            Shmelegate shm1 = HowAreYou;
            Shmelegate shm3 = shm + shm1;
            shm3 += HowAreYou;
            shm3 += HowAreYou;
            shm3 -= HowAreYou;

            shm3();

            Prilegate pri = Add;
            Console.WriteLine(pri(1, 2));
            Console.WriteLine(pri.Invoke(1, 5));


            Operation<int, int> opOne = Add;
            Console.WriteLine(opOne(2, 5));

            Operation<string, string> opTwo = Add;
            Console.WriteLine(opTwo("2", "5"));

            int a = 256;
            int b = 512;
            OperationRef<int, int> opRef = AddX;
            int c = opRef(ref a, ref b);
            Console.WriteLine("c= " + c);

            //opOne = opTwo;//

            IPhone msg = new IPhone("Hello");
            // msg.RegisterDelMg(new IPhone.MessageDelagate(PrintMsg));
            msg.Departure += PrintMsg;
            msg.Sent += PrintMsg;
            msg.Сame += PrintMsg;
            msg.IncomingMessage("hello");
            msg.IncomingMessage("how are you");
            msg.OutgoingMessage();

            var mm = new MailManager();
            mm.NewMail += MailManagerNewMail;
            Console.WriteLine("Input your name: ");
            var sender = Console.ReadLine();

            var sms = new SMS();
            mm.NewMail += sms.MmNewMail;

            Console.WriteLine("enter the name of the interlocutor : ");
            var target = Console.ReadLine();

            Console.WriteLine("Input the text SMS: ");
            var message = Console.ReadLine();

            mm.SimilateNewMail(sender, target, message);
        }
        private static void MailManagerNewMail(object sender,NewMailEventArgs e)
        {
            var sms = new SMS();
            sms.Send(e.Subject);

            var printer = new Printer();
            printer.Print($"Message from {e.From} for {e.To}\r\n <<{e.Subject}>>");
        }
        private static void PrintMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        private static void Hello() => Console.WriteLine("Hello");
        private static void HowAreYou() => Console.WriteLine("How are you?");
        private static int Add(int x, int y) => x + y;
        private static string Add(string x, string y) => x + y;
        private static int AddX(ref int x, ref int y) => y = (x * 2) + y;

    }
}
