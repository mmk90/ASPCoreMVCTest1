using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Website.Data;
using Website.Models;

namespace Website.Pages.Admin
{
    public class AddModel : PageModel
    {
        private WebsiteDatabaseContext _context;

        public AddModel(WebsiteDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroups { get; set; }
        public void OnGet()
        {
            Product = new AddEditProductViewModel()
            {
                Categories = _context.Categories.ToList()
            };
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            
            var item = new Item()
            {
                ID=1,
                Price = Product.Price,
                Qty = Product.QuantityInStock
            };
            

            var pro = new Product()
            {
                Name = Product.Name,
                Item = item,
                Description = Product.Description,

            };
            _context.Add(pro);
            _context.SaveChanges();

            if(selectedGroups?.Count>0)
            {
                foreach (var g in selectedGroups)
                {
                    var cp = new CategorytoProduct()
                    {
                        ProductID = pro.ID,
                        CategoryID = g
                    };
                    _context.CategorytoProducts.Add(cp);
                    _context.SaveChanges();
                }
            }

            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.ID + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }


            return RedirectToPage("Index");
        }
    }
}
