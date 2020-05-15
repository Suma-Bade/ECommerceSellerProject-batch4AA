using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class Token
    {
        public string username { get; set; }
        public string token { get; set; }
        public string message { get; set; }
        public int sellerid { get; set; }
    }
}
