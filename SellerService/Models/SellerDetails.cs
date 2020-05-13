using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerService.Models
{
    public class SellerDetails
    {
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
    }
}
