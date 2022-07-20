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
            }
            catch (Exception e)
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


            // Reading type of transaction from transactionJsonList file and then for each transaction type called that particular function.

            ThreadStart buy_thread = new ThreadStart(() =>
            {
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

                                ThreadStart buy_thread = new ThreadStart(() =>
                                {
                                    traderRecords = b.updateTraderData_AfterBuying(i.data.wallet_address, i.data.coin, i.data.quantity, a.Price, traderRecords);

                                });
                                Thread thread1 = new Thread(buy_thread);
                                thread1.Start();

                            }
                        }
                    }
                    if (type_of_transaction == "SELL")
                    {
                        Sell s = new Sell();
                        foreach (var a in coinRecords)
                        {
                            if (a.Symbol == i.data.coin)
                            {
                                ThreadStart sell_thread = new ThreadStart(() =>
                                {
                                    traderRecords = s.updateTraderData_AfterSelling(i.data.wallet_address, i.data.coin, i.data.quantity, a.Price, traderRecords);

                                });
                                Thread thread = new Thread(sell_thread);
                                thread.Start();

                            }
                        }

                    }

                    if (type_of_transaction == "ADD_VOLUME")
                    {
                        AddVolume av = new AddVolume();
                        ThreadStart addVolume_thread = new ThreadStart(() =>
                        {
                            av.addVolumeInCoinsData(i.data.coin, i.data.quantity, coinRecords);
                        });
                        Thread thread = new Thread(addVolume_thread);
                        thread.Start();

                    }

                    if (type_of_transaction == "UPDATE_PRICE")
                    {
                        UpdatePrice up = new UpdatePrice();
                        ThreadStart updatePrice_thread = new ThreadStart(() =>
                        {
                            up.updateCoinPrice(i.data.coin, i.data.price, coinRecords);
                        });
                        Thread thread = new Thread(updatePrice_thread);
                        thread.Start();
                    }
                }

            });
            Thread thread1 = new Thread(buy_thread);
            thread1.Start();

            //Calling Menu function . 

            Menu menu = new Menu();
            ThreadStart menu_thread = new ThreadStart(() =>
            {
                bool check = true;
                while (check)

                    menu.Menu_(traderRecords, coinRecords);
            });
            Thread thread0 = new Thread(menu_thread);
            thread0.Start();


        }
    }
}