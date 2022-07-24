using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class User
    {
        public User()
        {
            Passengers = new HashSet<Passenger>();
            Transactions = new HashSet<Transaction>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int ContactId { get; set; }

        public virtual ContactDetail Contact { get; set; } = null!;
        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
