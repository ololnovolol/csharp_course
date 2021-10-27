using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public enum AccountValidRagistration
    {
        registred,
        unregistred
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
                case AccountValidRagistration.registred:
                    newAccount = new RegistredAccount("", "") as T;
                    break;
                case AccountValidRagistration.unregistred:
                    newAccount = new AnonimusAccount(Name, Pasword) as T;
                    break;
                default:
                    break;
            }

            if (newAccount == null)
                throw new Exception("creation error");
            // добавляем новый счет в массив счетов      
            if (accounts == null)
                accounts = new T[] { newAccount };
            else
            {
                T[] tempAccounts = new T[accounts.Length + 1];
                for (int i = 0; i < accounts.Length; i++)
                    tempAccounts[i] = accounts[i];
                tempAccounts[tempAccounts.Length - 1] = newAccount;
                accounts = tempAccounts;
            }
        //    // установка обработчиков событий счета
        //    newAccount.Added += addSumHandler;
        //    newAccount.Withdrawed += withdrawSumHandler;
        //    newAccount.Closed += closeAccountHandler;
        //    newAccount.Opened += openAccountHandler;
        //    newAccount.Calculated += calculationHandler;

        //    newAccount.Open();
        //}

        //public void Put(decimal sum, int id)
        //{
        //    T account = FindAccount(id);
        //    if (account == null)
        //        throw new Exception("Счет не найден");
        //    account.Put(sum);
        //}
        //// вывод средств
        //public void Withdraw(decimal sum, int id)
        //{
        //    T account = FindAccount(id);
        //    if (account == null)
        //        throw new Exception("Счет не найден");
        //    account.Withdraw(sum);
        //}
        //// закрытие счета
        //public void Close(int id)
        //{
        //    int index;
        //    T account = FindAccount(id, out index);
        //    if (account == null)
        //        throw new Exception("Счет не найден");

        //    account.Close();

        //    if (accounts.Length <= 1)
        //        accounts = null;
        //    else
        //    {
        //        // уменьшаем массив счетов, удаляя из него закрытый счет
        //        T[] tempAccounts = new T[accounts.Length - 1];
        //        for (int i = 0, j = 0; i < accounts.Length; i++)
        //        {
        //            if (i != index)
        //                tempAccounts[j++] = accounts[i];
        //        }
        //        accounts = tempAccounts;
        //    }
        //}

        //// начисление процентов по счетам
        //public void CalculatePercentage()
        //{
        //    if (accounts == null) // если массив не создан, выходим из метода
        //        return;
        //    for (int i = 0; i < accounts.Length; i++)
        //    {
        //        accounts[i].IncrementDays();
        //        accounts[i].Calculate();
        //    }
        //}

        //// поиск счета по id
        //public T FindAccount(int id)
        //{
        //    for (int i = 0; i < accounts.Length; i++)
        //    {
        //        if (accounts[i].Id == id)
        //            return accounts[i];
        //    }
        //    return null;
        //}
        //// перегруженная версия поиска счета
        //public T FindAccount(int id, out int index)
        //{
        //    for (int i = 0; i < accounts.Length; i++)
        //    {
        //        if (accounts[i].Id == id)
        //        {
        //            index = i;
        //            return accounts[i];
        //        }
        //    }
        //    index = -1;
        //    return null;
        }

    }
}
