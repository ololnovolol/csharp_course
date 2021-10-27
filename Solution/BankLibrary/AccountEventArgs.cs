using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public delegate void AcountStateHandler(object sendr, AccountEventArgs e);
    public class AccountEventArgs
    {
        public string Message { get; private set; }
        public decimal Price { get; set; }


        public AccountEventArgs(string message, decimal priceForProduct)
        {
            Message = Message;
            Price = priceForProduct;
        }

    }
}
