using Assignment2_newAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Services
{
    internal class UpdatePrice
    {
        public List<Coin> updateCoinPrice(string coinName, double price, List<Coin> coinRecords)
        {
            foreach (var i in coinRecords)
            {
                if (i.Name == coinName)
                    i.Price = price;
            }
            return coinRecords;
        }
    }
}
