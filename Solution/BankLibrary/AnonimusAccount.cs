using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary 
{
    class AnonimusAccount : Account
    {
        public AnonimusAccount(string login, string pasword) : base(login, pasword)
        {
            base.Id += 1;
        }
        protected override void OnGetBalansed(AccountEventArgs e)
        {
            OnGetBalansed(new AccountEventArgs($"your bonus account = 0, comlete registration get 100 bonuses", 0));
        }
        protected override void OnNewAMail(AccountEventArgs e)
        {
            OnNewAMail(new AccountEventArgs($"we cannot send you a letter by email register", 0));
        }

        protected override void OnProductsSended(AccountEventArgs e)
        {
            base.OnProductsSended(e);
        }

    }
}
