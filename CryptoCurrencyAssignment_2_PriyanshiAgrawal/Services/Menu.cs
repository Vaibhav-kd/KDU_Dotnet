using Assignment2_newAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Services
{
    public class Menu
    {
        //Display  menu using this Menu_ method in main method 
        public void Menu_(List<Trader> traderRecords, List<Coin> coinRecords)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1.Given the name or code of a coin, retrieve all its details.");
            Console.WriteLine("2.Display top 50 coins in the market based on price.");
            Console.WriteLine("3.For a given trader, show his portfolio.");
            Console.WriteLine("4.For a given trader, display the total profit or loss they have made trading in the cryptomarket.");
            Console.WriteLine("5.Show top 5 and bottom 5 traders based on their profit / loss.");
            Console.WriteLine("Enter your option");



            var option = Console.ReadLine();
            Queries q = new Queries();


            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter Coin's Name/Symbol : ");
                    var input = Console.ReadLine();
                    q.CoinDetails_1(input, coinRecords);
                    break;

                case "2":
                    q.top50Coins(coinRecords);
                    break;

                case "3":
                    Console.WriteLine("Enter trader's name:");
                    var input1 = Console.ReadLine();
                    q.TraderPortfolio(input1, traderRecords);
                    break;

                case "4":
                    Console.WriteLine("Enter trader's name:");
                    var input2 = Console.ReadLine();
                    q.TraderProfitLoss(input2, traderRecords);
                    break;

                case "5":
                    q.Top5Bottom5Trader(traderRecords);
                    break;

            }

        }
    }
}
