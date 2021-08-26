using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class ProductCategoriesViewModel
    {
        public Product Product { get; set; }

        public List<Category> Categories { get; set; }
    }
}
