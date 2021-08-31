using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Product
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        public Item Item { get; set; }
        public ICollection<CategorytoProduct> CategoriytoProducts { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }


    }
}
