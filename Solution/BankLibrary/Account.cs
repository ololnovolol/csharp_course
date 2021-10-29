using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary
{
    public abstract class Account : IAcount
    {
        protected internal event AcountStateHandler Registred;
        protected internal event AcountStateHandler OrderOnSited;
        protected internal event AcountStateHandler ProductsSended;
        protected internal event AcountStateHandler NewAMailed;
        protected internal event AcountStateHandler GetBalansed;

        static int counter = 0;
        protected int days = 0;// время с момента открытия счета
        public decimal Price { get; private set; } = 250m;
        public decimal Bonus { get; private set; }
        public string Login { get; set; }
        public bool seal { get; set; } = false;
        public string Pasword { private get; set; }
        public string Mail { get; private set; }
        public int Id { get; set; }

        public Account(string login, string pasword)
        {
            Login = login;
            Pasword = pasword;
            BonusPlus();
            Id = ++counter;
        }

        public void BonusPlus()
        {
            Bonus += 100;
        }

        private void CallEvent(AccountEventArgs e, AcountStateHandler handler)
        {
            if (e != null)
            {
                handler?.Invoke(this, e);
            }
        }

        protected virtual void OnRegistration(AccountEventArgs e)
        {
            CallEvent(e, Registred);
        }
        protected virtual void OnOrderOnSited(AccountEventArgs e)
        {
            CallEvent(e, OrderOnSited);
        }
        protected virtual void OnProductsSended(AccountEventArgs e)
        {
            CallEvent(e, ProductsSended);
        }
        protected virtual void OnNewAMail(AccountEventArgs e)
        {
            CallEvent(e, NewAMailed);
        }
        protected virtual void OnGetBalansed(AccountEventArgs e)
        {
            CallEvent(e, GetBalansed);
        }


        public virtual void GetBalanse()
        {
            OnGetBalansed(new AccountEventArgs($"account  {Login}: \non your bonus account = ", Bonus));
        }

        public virtual decimal OrderOnSite(decimal price)
        {
            decimal result;
            if (price > Bonus)
            {
                OnOrderOnSited(new AccountEventArgs($"you can pay for the purchase from a bonus account {Id}", Bonus));
                result = Bonus - price;
                seal = true;
                BonusPlus();
                return result;
            }
            OnOrderOnSited(new AccountEventArgs($"you need to pay the full amount", price));
            Bonus += 100;
            return price;
        }

        public virtual void Registration(string login, string pasword, string mail)
        {
            Login = login;
            Pasword = pasword;
            Mail = mail;
            BonusPlus();
            OnRegistration(new AccountEventArgs($"account created {login}, confirm in the mail in the letter\non your bonus account = ", 100m));
        }

        public virtual void SendingAnOrder(bool Seal)
        {
            seal = Seal;
            
            if (seal)
            {
                OnProductsSended(new AccountEventArgs($"a parcel has been sent to you, receive it in 3 days and pay the amount =  = ", seal));
                seal = false;
            }
            else
            {
                OnProductsSended(new AccountEventArgs($"a parcel has don`t sent to you = ", seal));
            }
        }
        public virtual void IncremeinDays()
        {
            days++;
            BonusPlus();
        }

        public virtual void NewMail()
        {
            OnRegistration(new AccountEventArgs($"a message has been sent to you ",0));
        }

    }
}
