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
    public class DeleteModel : PageModel
    {
        private WebsiteDatabaseContext _context;
        public DeleteModel(WebsiteDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.Find(id);
        }

        public IActionResult OnPost()
        {
            var product = _context.Products.Find(Product.ID);
            var item = _context.Items.First(p => p.ID == product.ItemID);
            _context.Items.Remove(item);
            _context.Products.Remove(product);

            _context.SaveChanges();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product.ID + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("Index");
        }
    }
}
