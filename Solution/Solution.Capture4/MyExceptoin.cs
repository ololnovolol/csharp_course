using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture4
{
    class MyExceptoin : ArgumentException
    {
        int value;
        public MyExceptoin()
        {
            string g = base.Message;


        }

        public MyExceptoin(string message) : base(message)
        {
            string g = base.Message;
            Console.WriteLine(g + " <--output inside MyExceptoin ctor");

        }

        public MyExceptoin(string message, int value) : base(message)
        {
            string g = base.Message;
            Console.WriteLine(g + " <--output inside MyExceptoin ctor value =" + value);
            this.value = value;
        }
    }
}
