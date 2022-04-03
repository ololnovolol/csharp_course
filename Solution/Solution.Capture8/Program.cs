using SiteLibrary;
using System;

namespace Solution.Capture8
{
    class Program
    {
        static void Main(string[] args)
        {
            Site<Account> site = new("ПромТорг", 0737777777);
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                Console.WriteLine("1. Зарегистрироваться \t 2. Посмотреть Бонусы  \t 3. Сделать заказ");
                Console.WriteLine("4. Инфо по Транспортировке \t 5. Пропустить день \t 6. Выйти из программы");
                Console.WriteLine("Введите номер пункта:");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            RegAccount(site);
                            break;
                        case 2:
                            GetBonuses(site);
                            break;
                        case 3:
                            ByOrder(site);
                            break;
                        case 4:
                            InfoTransaction(site);
                            break;
                        case 5:
                            break;
                        case 6:
                            alive = false;
                            continue;
                    }
                    //site.CalculatePercentage();
                }
                catch (Exception ex)
                {
                    // выводим сообщение об ошибке красным цветом
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void RegAccount(Site<Account> bank)
        {
            Console.WriteLine("Укажите Login для создания Account:");
            string login = Console.ReadLine();
            Console.WriteLine("Укажите Pasword для создания Account:");
            string psw = Console.ReadLine();
            Console.WriteLine("Укажите @mail для создания Account:");
            string mail = Console.ReadLine();

            Console.WriteLine("Выберите тип Account: 1. Vip 2. Free");
            AccountValidRagistration accountType;

            int type = Convert.ToInt32(Console.ReadLine());

            decimal price = 250m;

            accountType = type == 2 ? AccountValidRagistration.VipRegistred : AccountValidRagistration.FreeRegistred;

            bank.registration(accountType,
            price,
            Registratio,
            OrderOnSite,
            ProductsSend,
            NewAMail,
            GetBalans);
        }
        private static void GetBonuses(Site<Account> site)
        {
            Console.WriteLine("Введите id счета:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("На вашем счету:");
            Console.WriteLine(site.GetBalanse(id));
        }

        private static void ByOrder(Site<Account> site)
        {
            Console.WriteLine("Укажите кол-во товаров для заказа:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Введите Id счета:");
            int id = Convert.ToInt32(Console.ReadLine());
            site.Order(sum, id);
        }

        private static void InfoTransaction(Site<Account> sitec)
        {
            Console.WriteLine("Введите id счета, чтоб получить информацию про вашей отгрузке:");
            int id = Convert.ToInt32(Console.ReadLine());

            sitec.SendingAnOrder(id);
        }

        // обработчики событий класса Account
        //обработчик открытия счета
        private static void Registratio(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        //обработчик добавления денег на счет
        private static void OrderOnSite(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        //обработчик вывода средств
        private static void ProductsSend(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Seal)
            {
                Console.WriteLine("Ваша посылка отправлена");
            }
            else
            {
                Console.WriteLine("Ваша посылка еще не отправлена\n1)Заказ был не оформлен\n2)Оплата по заказу не получена");
            }
        }
        //обработчик закрытия счета
        private static void NewAMail(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        private static void GetBalans(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
