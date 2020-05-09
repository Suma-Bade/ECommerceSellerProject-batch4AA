using System;
using System.Collections.Generic;

namespace AccountService.Entities
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Price { get; set; }
        public string Itemname { get; set; }
        public string Description { get; set; }
        public int? Stockno { get; set; }
        public string Remarks { get; set; }
        public int? Sid { get; set; }
    }
}
