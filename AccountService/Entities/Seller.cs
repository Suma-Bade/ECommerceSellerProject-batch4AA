using System;
using System.Collections.Generic;

namespace AccountService.Entities
{
    public partial class Seller
    {
        public Seller()
        {
            Items = new HashSet<Items>();
        }

        public int Sellerid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Companyname { get; set; }
        public int Gst { get; set; }
        public string Aboutcmpy { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
