using System;
using System.Collections.Generic;

namespace SellerService.Entities
{
    public partial class SubCategory
    {
        public int Subid { get; set; }
        public string Subname { get; set; }
        public string Cname { get; set; }
        public string Sdetails { get; set; }
        public int? Gst { get; set; }
    }
}
