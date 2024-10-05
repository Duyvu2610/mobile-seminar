using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model
{
    public class Item
    {
        public long id { get; set; }
        public string imageUrl { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
        public string description { get; set; }
    }
}
