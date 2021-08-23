using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public Item Item { get; set; }
        public int Qty { get; set; }
        public decimal getTotalPrice 
        { 
            get
            {
                return Item.Price * Qty;
            }
        }
    }
}
