using Assignment2_newAttempt.JsonReader;
using Assignment2_newAttempt.Models;
using Assignment2_newAttempt.Services;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using System.Text.Json;


namespace Assignment2_newAttempt
{
    public class Program
    {
        public static List<Root> transactionJsonlist;

        static void Main(string[] args)
        {
            List<Coin> coinRecords = new List<Coin>();
            List<Trader> traderRecords = new List<Trader>();

            

            // Reading data from Coins.csv file using CsvReader
            try
            {
                var reader1 = new StreamReader(@"C:\Users\KD Administrator\source\repos\Assignment2_newAttempt\CsvDataFiles\coins.csv");
                var csv1 = new CsvHelper.CsvReader(reader1, CultureInfo.InvariantCulture);
                coinRecords = csv1.GetRecords<Coin>().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Reading data from traders.csv file into records

            try
            {
                var reader2 = new StreamReader(@"C:\Users\KD Administrator\source\repos\Assignment2_newAttempt\CsvDataFiles\traders.csv");
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };
                var csv2 = new CsvHelper.CsvReader(reader2, config);
                traderRecords = csv2.GetRecords<Trader>().ToList();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }           



             //Json Reader
            try
            {
                string fileName = @"C:\Users\KD Administrator\source\repos\Assignment2_newAttempt\JsonFiles\test_transaction.json";
                string jsonString = File.ReadAllText(fileName);

                transactionJsonlist = JsonSerializer.Deserialize<List<Root>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           


           /* ThreadStart job = new ThreadStart(transaction);
            Thread thread = new Thread(job);
            thread.Start();*/

          
                foreach (var i in transactionJsonlist)
                {
                    var type_of_transaction = i.type;

                    if (type_of_transaction == "BUY")
                    {
                        Buy b = new Buy();
                        foreach (var a in coinRecords)
                        {
                            if (a.Symbol == i.data.coin)
                            {
                                traderRecords = b.updateTraderData_AfterBuying(i.data.wallet_address, i.data.coin, i.data.quantity, a.Price, traderRecords);
                            }
                        }
                       

                        coinRecords = b.updateCoinsData_AfterBuying(i.data.coin, i.data.quantity, coinRecords);
                       

                        ThreadStart t1 = new ThreadStart(GetBlockHash);
                        Thread thread1 = new Thread(t1);
                        thread1.Start();

                    }
                    if (type_of_transaction == "SELL")
                    {
                        Sell s = new Sell();
                        foreach (var a in coinRecords)
                        {
                            if (a.Symbol == i.data.coin)
                            {
                                traderRecords = s.updateTraderData_AfterSelling(i.data.wallet_address, i.data.coin, i.data.quantity, a.Price, traderRecords);
                            }
                        }
                        

                        ThreadStart t2 = new ThreadStart(GetBlockHash);
                        Thread thread2 = new Thread(t2);
                        thread2.Start();

                        coinRecords = s.updateCoinsData_AfterSelling(i.data.coin, i.data.quantity, coinRecords);

                    }

                    if (type_of_transaction == "ADD_VOLUME")
                    {
                        AddVolume av = new AddVolume();
                        av.addVolumeInCoinsData(i.data.coin, i.data.quantity, coinRecords);

                       
                        ThreadStart t3 = new ThreadStart(GetBlockHash);
                        Thread thread3 = new Thread(t3);
                        thread3.Start();
                    }

                    if (type_of_transaction == "UPDATE_PRICE")
                    {
                        UpdatePrice up = new UpdatePrice();
                        up.updateCoinPrice(i.data.coin, i.data.price, coinRecords);
                        

                        ThreadStart t4 = new ThreadStart(GetBlockHash);
                        Thread thread4 = new Thread(t4);
                        thread4.Start();


                    }

                

                /* Hash_Function hf = new Hash_Function();

                 ThreadStart t5 = new ThreadStart(Menu);
                 Thread thread5 = new Thread(t5);
                 thread5.Start();*/

        
                Console.WriteLine("Menu:");
                Console.WriteLine("1.Given the name or code of a coin, retrieve all its details.");
                Console.WriteLine("2.Display top 50 coins in the market based on price.");
                Console.WriteLine("3.For a given trader, show his portfolio.");
                Console.WriteLine("4.For a given trader, display the total profit or loss they have made trading in the cryptomarket.");
                Console.WriteLine("5.Show top 5 and bottom 5 traders based on their profit / loss.");
                Console.WriteLine("Enter your option");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter Coin's Name/Symbol : ");
                        var input = Console.ReadLine();
                        CoinDetails_1(input);
                        break;

                    case "2":
                        top50Coins();
                        break;

                    case "3":
                        Console.WriteLine("Enter trader's name:");
                        var input1 = Console.ReadLine();
                        TraderPortfolio(input1);
                        break;

                    case "4":
                        Console.WriteLine("Enter trader's name:");
                        var input2 = Console.ReadLine();
                        TraderProfitLoss(input2);
                        break;

                    case "5":
                        Top5Bottom5Trader();
                        break;

                }

                void CoinDetails_1(string coinName)
                {
                    var ans = coinRecords.Where(x => (x.Name == coinName ) || (x.Symbol==coinName));
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

                void top50Coins()
                {
                    var ans = coinRecords.OrderByDescending(x => x.Price).Take(50);
                    int x = 1;
                    foreach (var i in ans)
                    {
                        Console.WriteLine(x + " " + i.Name);
                        x++;
                    }
                }

                void TraderPortfolio(string name)
                {

                    var ans = traderRecords.Where(x => (x.firstName + " " + x.lastName) == name);
                    foreach (var i in ans)
                    {

                        Console.WriteLine(i.firstName + " " + i.lastName);
                        Console.WriteLine(i.phone);
                        Console.WriteLine(i.walletAddress);
                    }
                }

                void TraderProfitLoss(string name)
                {

                    var ans = traderRecords.Where(x => (x.firstName) == name);
                    foreach (var i in ans)
                    {
                        Console.WriteLine("The trader " + name + " has made a " + i.profit_or_loss_status + " of " + i.profit_or_loss_value);
                    }
                }

                void Top5Bottom5Trader()
                {
                    var top5 = traderRecords.Where(x => x.profit_or_loss_status == "Profit").OrderByDescending(x => x.profit_or_loss_value).Take(5);
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







                void GetBlockHash()
                {
                    string SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                    StringBuilder transactionHash = new StringBuilder();
                    Random rnd = new Random();
                    /**
                    * Introducing delay mimicking complex
                    * calculation being performed.
*/
                    for (double i = 0; i < 199999999; i++)
                    {
                        i = i;
                    }
                    while (transactionHash.Length < 128)
                    {
                        int index = Convert.ToInt32((rnd.NextSingle() *SALTCHARS.Length));
                       // transactionHash.Append(SALTCHARS.ElementAt(index));
                    }
                    String hashCode = transactionHash.ToString();
                 //   return "0x" + hashCode.ToLower();
                }
            }


        }
    }
}