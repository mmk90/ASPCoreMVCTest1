using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class CategorytoProduct
    {
        public int CategoryID { get; set; }
        public int ProductID { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
