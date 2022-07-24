using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class ContactDetail
    {
        public ContactDetail()
        {
            Users = new HashSet<User>();
        }

        public int ContactId { get; set; }
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string Line1 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
