﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture4
{
    internal class MyExceptoin : ArgumentException
    {
        int value;
        string g;

        public MyExceptoin(string message) : base(message)
        {
            g = base.Message;
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
