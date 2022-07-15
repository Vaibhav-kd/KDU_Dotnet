using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency_Assignment2.Models
{
    internal class Coin
    {
        [Name("Rank")]
        public int Rank { get; set; }
        [Name("Name")]
        public string Name { get; set; }
        [Name("Symbol")]
        public string Symbol { get; set; }
        [Name("Price")]
        public float Price { get; set; }
        [Name("Circulating Supply")]
        public int Circulating_Supply { get; set; }
    }
}
