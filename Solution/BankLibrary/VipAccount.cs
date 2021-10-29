using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary
{
    internal class VipAccount : Account
    {
        public VipAccount(string login, string pasword) : base(login, pasword)
        {
            MultiBonus(10);
        }

        private void MultiBonus(int i)
        {
            while (i == 10)
            {
                BonusPlus();
                i++;
            }
        }
        public override decimal OrderOnSite(decimal price)
        {
            return base.OrderOnSite(price);
            MultiBonus(2);
        }

        public override void Registration(string login, string pasword, string mail)
        {
            base.Registration(login, pasword, mail);
            MultiBonus(2);
        }

        public override void IncremeinDays()
        {
            base.IncremeinDays();
            MultiBonus(5);
        }
    }
}
