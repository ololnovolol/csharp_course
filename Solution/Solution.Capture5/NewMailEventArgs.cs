using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture5
{
    class NewMailEventArgs : EventArgs
    {
        public string From { get; }
        public string To { get; }
        public string Subject { get; }

        public NewMailEventArgs(string from, string to, string subject)
        {
            From = from;
            To = to;
            Subject = subject;
        }

        public override string ToString()
        {
            return $"new mail from {From} for {To}: {Subject}";
        }
    }
}
