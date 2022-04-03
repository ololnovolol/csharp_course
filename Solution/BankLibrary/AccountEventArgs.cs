namespace SiteLibrary
{
    public delegate void AcountStateHandler(object sendr, AccountEventArgs e);
    public class AccountEventArgs
    {
        public string Message { get; private set; }
        public decimal Price { get; set; }
        public bool Seal { get; set; } = false;


        public AccountEventArgs(string message, decimal priceForProduct)
        {
            Message = Message;
            Price = priceForProduct;
        }

        public AccountEventArgs(string message, bool seal)
        {
            Message = Message;
            Seal = seal;
        }
    }
}
