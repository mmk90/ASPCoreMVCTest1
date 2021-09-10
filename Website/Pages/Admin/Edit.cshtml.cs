using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Models;

namespace Website.Pages.Admin
{
    public class EditModel : PageModel
    {
        private WebsiteDatabaseContext _context;
        public EditModel(WebsiteDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroups { get; set; }

        public List<int> Groups { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.Include(c => c.Item).Where(c => c.ID == id).Select(
                c => new AddEditProductViewModel()
                {
                    Id = c.ID,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Item.Price,
                    QuantityInStock = c.Item.Qty,
                    Categories=_context.Categories.ToList()
                }
                ).FirstOrDefault();

            Groups = _context.CategorytoProducts.Where(c => c.ProductID == Product.Id).Select(c => c.CategoryID).ToList();  
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
                return Page();

            var product = _context.Products.Find(Product.Id);
            //var item = _context.Items.First(p => p.ID == product.ItemID);

            product.Name = Product.Name;
            product.Description = Product.Description;
            //item.Price = Product.Price;
            //item.Qty = Product.QuantityInStock;

            _context.SaveChanges();
            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.ID + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            _context.CategorytoProducts.RemoveRange(_context.CategorytoProducts.Where(c => c.ProductID == product.ID));
            _context.SaveChanges();

            if (selectedGroups?.Count > 0)
            {
                foreach (var g in selectedGroups)
                {
                    var cp = new CategorytoProduct()
                    {
                        ProductID = product.ID,
                        CategoryID = g
                    };
                    _context.CategorytoProducts.Add(cp);
                    _context.SaveChanges();
                }
            }
            return RedirectToPage("Index");
        }
    }
}
