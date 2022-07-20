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
            // Threading for running Hash function in background and not slowing other processes.
            Hash_Function hf = new Hash_Function();
            Thread backgroundThread = new Thread(() =>
            {
                hf.GetBlockHash();
            });
            backgroundThread.IsBackground = true;
            backgroundThread.Start();

            //updates the price of coin
            foreach (var i in coinRecords)
            {
                if (i.Name == coinName)
                    i.Price = price;
            }
            return coinRecords;
        }
    }
}
