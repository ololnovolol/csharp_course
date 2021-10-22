using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture5
{
    interface ITelePhone
    {
        public void IncomingCall();
        public void OutgoingCall();
        public void IncomingMessage(string mesasage);
        public void OutgoingMessage();

    }
}
