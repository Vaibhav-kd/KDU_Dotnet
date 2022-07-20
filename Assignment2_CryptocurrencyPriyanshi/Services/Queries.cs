using Assignment2_newAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Services
{
    public class Queries
    {
        //Queries for fetching required data asked by user through menu .

        public void CoinDetails_1(string coinName, List<Coin> coinRecords)
        {
            var ans = coinRecords.Where(x => (x.Name == coinName) || (x.Symbol == coinName));
            foreach (var i in ans)
            {
                Console.WriteLine("Coin Name: " + i.Name);
                Console.WriteLine("Coin Symbol: " + i.Symbol);
                Console.WriteLine("Coin Price: " + i.Price);
                Console.WriteLine("Coin Quantity: " + i.Circulating_Supply);
                Console.WriteLine("Coin Rank: " + i.Rank);
                Console.WriteLine();
            }

        }



        public void top50Coins(List<Coin> coinRecords)
        {
            var ans = coinRecords.OrderByDescending(x => x.Price).Take(50);
            int x = 1;
            foreach (var i in ans)
            {
                Console.WriteLine(x + " " + i.Name);
                x++;
            }
        }

        public void TraderPortfolio(string name, List<Trader> traderRecords)
        {

            var ans = traderRecords.Where(x => (x.firstName + " " + x.lastName) == name);
            foreach (var i in ans)
            {

                Console.WriteLine(i.firstName + " " + i.lastName);
                Console.WriteLine(i.phone);
                Console.WriteLine(i.walletAddress);
            }
        }

        public void TraderProfitLoss(string name, List<Trader> traderRecords)
        {

            var ans = traderRecords.Where(x => (x.firstName) == name);
            foreach (var i in ans)
            {
                Console.WriteLine("The trader " + name + " has made a " + i.profit_or_loss_status + " of " + i.profit_or_loss_value);
            }
        }

        public void Top5Bottom5Trader(List<Trader> traderRecords)
        {
            var top5 = traderRecords.Where(x => x.profit_or_loss_status == "Loss").OrderBy(x => x.profit_or_loss_value).Take(5);
            Console.WriteLine("top 5 traders are: ");
            foreach (var i in top5)
            {
                Console.WriteLine(i.firstName);

            }
            var bottom5 = traderRecords.Where(x => x.profit_or_loss_status == "Loss").OrderByDescending(x => x.profit_or_loss_value).Take(5);
            Console.WriteLine("bottom 5 traders are: ");
            foreach (var i in bottom5)
            {
                Console.WriteLine(i.firstName);

            }
        }
    }
}
