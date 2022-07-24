using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class Transaction
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int Respcode { get; set; }
        public string Respmsg { get; set; } = null!;
        public string Gateway { get; set; } = null!;
        public string PaymentMode { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual User User { get; set; } = null!;

       // public string error { get; set; } = string.Empty;
    }
}
