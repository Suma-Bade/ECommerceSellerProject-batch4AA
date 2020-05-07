using System;
using System.Collections.Generic;

namespace SellerService.Entities
{
    public partial class Seller
    {
        public int Sid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Companyname { get; set; }
        public int Gst { get; set; }
        public string Aboutcmpy { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
    }
}
