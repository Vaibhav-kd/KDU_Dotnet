using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency_Assignment2.TransactionRequestModel
{
    internal class Buy
    {
        
             public string name;
        public int quant;
        public SellCoin (string name,int quant)
        {
            this.name = name;
            this.quant = quant;

        }

        public void main()
        {
            object lock_= new object();
            bool isLocked = true;
            try
            {
                System.Threading.Monitor.Enter(lock_, ref isLocked);
                var a=item for item in market if item.get('name') == name;
                market[name]=a-quant;
            

            }

        }
            
       }
}
}
