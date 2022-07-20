using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Models
{
    public class Trader
    {
        public Trader()
        {
            traders_account = new List<CoinOwned>();
        }
        public List<CoinOwned> traders_account { get; set; }

        [Name("first_name")]
        public string? firstName { get; set; }
        [Name("last_name")]
        public string? lastName { get; set; }
        [Name("phone")]
        public string? phone { get; set; }
        [Name("Wallet Address")]
        public string? walletAddress{get; set;}

        // public string walletAddress { get; set; }
        public double? balanceAfterBuying { get; set; } = 0;
        public double? balanceAfterSelling { get; set; } = 0;

        public double? profit_or_loss_value { get; set; } = 0;

        public string? profit_or_loss_status { get; set; } = "";


    }
}
