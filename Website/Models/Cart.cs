using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public int OrderID { get; set; }
        public List<CartItem> CartItems { get; set; }

        public void addItem(CartItem cartItem)
        {
            if(CartItems.Exists(c=>c.Item.ID==cartItem.ID))
            {
                CartItems.Find(c => c.Item.ID == cartItem.ID).Qty += 1;
            }
            else
            {
                CartItems.Add(cartItem);
            }
        }

        public void removeItem(int itemID)
        {
            var Item = CartItems.SingleOrDefault(c => c.Item.ID == itemID);

            if (Item?.Qty <= 1)
                CartItems.Remove(Item);
            else
                Item.Qty -= 1;
        }
    }
}
