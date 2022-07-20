using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Models
{
    public class Coin
    {
        [Name("Rank")]
        public int Rank { get; set; }
        [Name("Name")]
        public string Name { get; set; }
        [Name("Symbol")]
        public string Symbol { get; set; }
        [Name("Price")]
        public double Price { get; set; }
        [Name("Circulating Supply")]
        public long Circulating_Supply { get; set; }
    }
}
