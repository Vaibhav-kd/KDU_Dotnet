using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency_Assignment2.TransactionRequestModel
{
    internal class UpdatePrice
    {
         public string name;
        public int price;
        public SellCoin (string name,int price)
        {
            this.name = name;
            this.price= price;

        }

        public void main()
        {
            object lock_= new object();
            bool isLocked = true;
            try
            {
                System.Threading.Monitor.Enter(lock_, ref isLocked);
                var a=item for item in market if item.get('name') == name;
                market[name]=price;
            

            }

        }

    }
}
