using Assignment2_newAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Services
{
    internal class Sell
    {

        public List<Trader> updateTraderData_AfterSelling(string walletAddress, string coinName, int quantity, double price, List<Trader> traderRecords)
        {
            foreach (var i in traderRecords)
            {
                i.balanceAfterSelling += quantity * price;
                if (i.balanceAfterBuying > i.balanceAfterSelling)
                {
                    i.profit_or_loss_value = (i.balanceAfterSelling - i.balanceAfterBuying) ;
                    i.profit_or_loss_status = "Loss";
                }
                else
                {
                    i.profit_or_loss_value = (-i.balanceAfterSelling + i.balanceAfterBuying) ;
                    i.profit_or_loss_status = "Profit";
                }


               // i.balanceAfterSelling += quantity * price; 

                if (i.walletAddress == walletAddress)
                {
                    if (!(i.traders_account is null))
                    {
                        if (i.traders_account.Where(c => c.CoinName == coinName).Count() == 0)
                        {
                            Console.WriteLine("Doesn't has the coin to sell in the market");
                        }
                        else
                        {
                            //update by decreasing amount
                            foreach (var rec in i.traders_account.Where(c => c.CoinName == coinName))
                            {
                                rec.Quantity -= quantity;
                            }

                        }
                    }
                    else
                    {
                        i.traders_account.Add(new CoinOwned
                        {
                            CoinName = coinName,
                            Quantity = quantity,
                            Price = price
                        });
                    }
                }
            }
            return traderRecords;
        }

        public List<Coin> updateCoinsData_AfterSelling(string coinName, long quantity, List<Coin> coinRecords)
        {
            foreach (var i in coinRecords)
            {
                if (i.Name == coinName)
                    i.Circulating_Supply -= quantity;
            }
            return coinRecords;
        }

    }
}
