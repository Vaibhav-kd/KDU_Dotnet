using CryptoCurrency_Assignment2.Models;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency_Assignment2.DataReaderFromCSV
{
    

    internal class CoinReader
    {

        static void Main()
        {
           List<Coin> coinRecords;
            // Reading data from Coins.csv file using CsvReader 
            var reader = new StreamReader(@".\CSVFiles\coins.csv");
            var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            coinRecords = csv.GetRecords<Coin>().ToList();
        }
    }
}
}
