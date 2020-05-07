using System;
using System.Collections.Generic;

namespace AccountService.Entities
{
    public partial class Category
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Cdetails { get; set; }
    }
}
