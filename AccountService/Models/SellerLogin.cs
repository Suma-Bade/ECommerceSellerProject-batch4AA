using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class SellerLogin
    {
        public int sellerid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
