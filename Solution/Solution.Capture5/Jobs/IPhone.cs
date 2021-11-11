using System;

namespace Solution.Capture5
{
    class IPhone : ITelePhone
    {
        public delegate void MessageDelagate(string message);
        public event MessageDelagate Departure;
        public event MessageDelagate Sent;
        public event MessageDelagate Сame;

        //private MessageDelagate mgdel = delegate
        //    {
        //        Console.WriteLine("---------------------Delegate Anonime Work---------------------");
        //    };

        //public void RegisterDelMg(MessageDelagate mgdel)
        //{
        //    this.mgdel += mgdel;
        //}
        //public void UnregisterDelMGg(MessageDelagate mgdel)
        //{
        //    this.mgdel -= mgdel; 
        //}

        private string mg;

        public IPhone(string massage)
        {
            mg = massage;
        }
        public virtual void IncomingCall() => Departure?.Invoke("Incoming Call");
        public virtual void IncomingMessage(string message) => Сame?.Invoke($"Incoming Message :\n\t{message}");
        public virtual void OutgoingCall() => Sent?.Invoke("Outgoing Call");
        public virtual void OutgoingMessage()
        {
            Console.WriteLine("Input your msg: ");
            string f = Console.ReadLine();
            if(f.Length < 1)
            {
                Console.WriteLine("no data entered!!!!!!!!!!!!!!!!!!!!");
                OutgoingMessage();
            }
            else
            {
                Departure?.Invoke($"Outgoing Message :\n\t{f}");
            }
        }
    }
}
