using Assignment2_newAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Services
{
    public class Buy
    {


        public List<Trader> updateTraderData_AfterBuying(string walletAddress, string coinName, int quantity, double price, List<Trader> traderRecords)
        {

            Hash_Function hf = new Hash_Function();
            Thread backgroundThread = new Thread(() =>
             {
                 hf.GetBlockHash();
             });
             backgroundThread.IsBackground = true;
             backgroundThread.Start();



            foreach (var i in traderRecords)
            {
                
                if (i.walletAddress == walletAddress)
                {
                    i.balanceAfterBuying += quantity * price;
                   
                    if (i.balanceAfterBuying > i.balanceAfterSelling)
                    {
                        i.profit_or_loss_value = (-i.balanceAfterSelling + i.balanceAfterBuying);
                        i.profit_or_loss_status = "Loss";
                    }
                    else
                    {
                        i.profit_or_loss_value = (i.balanceAfterSelling - i.balanceAfterBuying);
                        i.profit_or_loss_status = "Profit";
                    }

                    if (!(i.traders_account is null))
                    {

                        if (i.traders_account.Where(c => c.CoinName == coinName).Count() == 0)
                        {
                            //add
                            i.traders_account.Add(new CoinOwned
                            {
                                CoinName = coinName,
                                Quantity = quantity,
                                Price = price
                            });
                        }
                        else
                        {
                            //update
                            foreach (var rec in i.traders_account.Where(c => c.CoinName == coinName))
                            {
                                rec.Quantity += quantity;
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

        public List<Coin> updateCoinsData_AfterBuying(string coinName, long quantity, List<Coin> coinRecords)
        {
            foreach (var i in coinRecords)
            {
                if (i.Name == coinName)
                    i.Circulating_Supply += quantity;
            }
            return coinRecords;
        }
    }
}
