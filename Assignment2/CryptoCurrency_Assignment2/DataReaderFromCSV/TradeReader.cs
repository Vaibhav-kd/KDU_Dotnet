using CryptoCurrency_Assignment2.Models;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Trader;


namespace CryptoCurrency_Assignment2.DataReaderFromCSV
{
    public class TradeReader
    {
        static void Main()
        {
            List<Trader> traderRecords;

            //Reading data from traders.csv file into records
            var reader = new StreamReader(@".\CSVFiles\traders.csv");
            var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            traderRecords = csv.GetRecords<Trader>().ToList();

            /*for (int i = 0; i < records.Count; i++)
            {
                var a = records[i].firstName;
            }*/

        }

    }
}
