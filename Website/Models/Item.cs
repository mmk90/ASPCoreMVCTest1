using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Item
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}
