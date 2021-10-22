using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture5
{
    internal class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            NewMail?.Invoke(this, e);
        }

        public void SimilateNewMail(string from, string to, string subject)
        {
            var e = new NewMailEventArgs(from, to, subject);
            OnNewMail(e);
        }

    }
}
