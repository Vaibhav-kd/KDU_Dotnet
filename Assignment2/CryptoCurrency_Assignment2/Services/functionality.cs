using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency_Assignment2.Services
{
    internal class functionality
    {
        public static void coinDetails()
        {
            {

                var coin = Console.ReadLine();
                var ans1 = coinRecords.
                            Select(a => new
                            {
                                rank = a.Rank,
                                name = a.Name,
                                symbol = a.Symbol,
                                price = a.Price,
                                circulating_supply = a.Circulating_Supply

                            }).Where(a => a.name == coin).ToList();

                foreach (var i in ans1)
                {
                    Console.WriteLine(i.rank + " Rank" + i.name + " Name " + i.symbol + " Symbol " + i.price + " Price " + i.circulating_supply + " supply");
                }
            }


           public void top50Coins()
            {
                var display = coinRecords
                                    .Select(y => y.Name)
                                    .OrderByAscending(y => y.Rank)
                                    .Take(50).ToList();
                foreach (var i in display)
                {
                    Console.WriteLine(i + " " + i.Name);
                }


            }


            public static void TraderPortfolio(String name)
            {
                var traderName = Console.ReadLine();
                var portfolio = tradersRecords.
                                    Select(y => new
                                    {
                                        firstName = y.firstName,
                                        lastName = y.lastName,
                                        phone = y.phone,
                                        walletAddress = y.walletAddress
                                    }).Where(y => y.Name == name).ToList();

                foreach (var i in portfolio)
                {
                    Console.WriteLine(i.firstName + i.lastName + " Name " + i.phone + " phone " + i.walletAddress + " WalletAddress ");
                }

            }

            static void ProfitLossOfTrader(String name)
            {

            }
        }
    }
}
