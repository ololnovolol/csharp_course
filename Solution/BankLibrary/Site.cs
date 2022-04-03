using System;

namespace SiteLibrary
{
    public enum AccountValidRagistration
    {
        VipRegistred,
        FreeRegistred
    }
    public class Site<T> where T : Account
    {
        T[] accounts;
        public string Name { get; private set; }
        public string Pasword { get; private set; }
        public int TelephoneNumber { get; private set; }

        public Site(string name, int telephoneNumber)
        {
            Name = name;
            TelephoneNumber = telephoneNumber;
        }

        public void registration(AccountValidRagistration accountValidRagistration, decimal price,
        AcountStateHandler Registratio, AcountStateHandler OrderOnSite,
        AcountStateHandler ProductsSend, AcountStateHandler NewAMail,
        AcountStateHandler GetBalans)
        {
            T newAccount = null;

            switch (accountValidRagistration)
            {
                case AccountValidRagistration.VipRegistred:
                    newAccount = new FreeAccount("Free" + Name, Pasword) as T;
                    break;
                case AccountValidRagistration.FreeRegistred:
                    newAccount = new VipAccount(Name, Pasword) as T;
                    break;
                default:
                    break;
            }

            if (newAccount == null)
            {
                throw new Exception("creation error");
            }
            // добавляем новый счет в массив счетов      
            if (accounts == null)
                accounts = new T[] { newAccount };
            else
            {
                T[] tempAccounts = new T[accounts.Length + 1];
                for (int i = 0; i < accounts.Length; i++)
                {
                    tempAccounts[i] = accounts[i];
                }

                tempAccounts[tempAccounts.Length - 1] = newAccount;
                accounts = tempAccounts;
            }
            //    // установка обработчиков событий счета
            newAccount.Registred += Registratio;
            newAccount.OrderOnSited += OrderOnSite;
            newAccount.ProductsSended += ProductsSend;
            newAccount.NewAMailed += NewAMail;
            newAccount.GetBalansed += GetBalans;
        }
        public T FindAccount(int id)
        {
            try
            {
                for (int i = 0; i <= accounts?.Length; i++)
                {
                    if (accounts[i].Id == id)
                    {
                        return accounts[i];
                    }
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("еще не создан пользователь с таким ID");
                return null;
            }
            return null;
        }

        // перегруженная версия поиска счета
        public T FindAccount(int id, out int index)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                {
                    index = i;
                    return accounts[i];
                }
            }
            index = -1;
            return null;
        }

        public decimal GetBalanse(int id)
        {
            T account = FindAccount(id);
            return account == null ? throw new Exception("Account not found") : account.Bonus;
        }
        public decimal Order(decimal countProducts, int id)
        {
            decimal BasePrice = 250;
            decimal resultPrice = BasePrice * countProducts;
            T account = FindAccount(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            account.NewMail();
            return account.OrderOnSite(resultPrice);
        }

        public void Registration(string login, string pasword, string mail, int id)
        {
            int index;
            T account = FindAccount(id, out index);
            if (account == null)
            {
                // throw new Exception("Account not found");
                account.Registration(login, pasword, mail);

                if (accounts.Length <= 1)
                {
                    accounts = null;
                }
                else
                {
                    T[] tempAccounts = new T[accounts.Length + 1];
                    for (int i = 0; i < accounts.Length; i++)
                    {
                        tempAccounts[i] = accounts[i];
                    }
                    accounts = tempAccounts;
                    account.NewMail();
                }
            }
        }

        public void SendingAnOrder(int id)
        {
            T account = FindAccount(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            account.SendingAnOrder(account.seal);
            account.NewMail();
        }
        protected virtual void IncremeinDays()
        {
            if (accounts == null) // если массив не создан, выходим из метода
                return;
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i].IncremeinDays();

            }
        }
    }
}
