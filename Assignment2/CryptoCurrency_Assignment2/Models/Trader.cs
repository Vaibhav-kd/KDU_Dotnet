using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency_Assignment2.Models
{
    internal class Trader
    {
        [Name("first_name")]
        public string firstName { get; set; }
        [Name("last_name")]
        public string lastName { get; set; }
        [Name("phone")]
        public string phone { get; set; }
        [Name("Wallet Address")]
        public string walletAddress { get; set; }

    }
}
