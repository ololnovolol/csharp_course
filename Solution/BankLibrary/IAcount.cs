namespace SiteLibrary
{
    public interface IAcount
    {
        void Registration(string login, string pasword, string mail); // регистрация

        decimal OrderOnSite(decimal price); // покупка товара на сайте

        void SendingAnOrder(bool Seal); // отгрука заказа если товар оплачен

        void GetBalanse(); // показать баланс клиента бонусы

    }
}
