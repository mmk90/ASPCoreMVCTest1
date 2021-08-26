using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Website.Data;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebsiteDatabaseContext _context;
        private static Cart _cart = new Cart();

        public HomeController(ILogger<HomeController> logger,
                              WebsiteDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Products.ToList();
            return View(model);
        }

        public IActionResult ShowProduct(int id)
        {
            var product = _context.Products.Include(c => c.Item).SingleOrDefault(c => c.ID == id);

            if (product == null)
                return NotFound();

            var categories = _context.Products.Where(c => c.ID == id).SelectMany(c => c.CategoriytoProducts).Select(c => c.Category).ToList();

            ProductCategoriesViewModel model = new ProductCategoriesViewModel()
            {
                Product = product,
                Categories = categories
            };

            return View(model);
        }

        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemID == itemId);
            if (product != null)
            {
                var cartItem = new CartItem()
                {
                    Item = product.Item,
                    Qty = 1
                };
                _cart.addItem(cartItem);
            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            var CartVM = new CartViewModel()
            {
                CartItems = _cart.CartItems,
                OrderTotal = _cart.CartItems.Sum(c => c.getTotalPrice)
            };
            return View(CartVM);
        }

        public IActionResult RemoveCart(int itemId)
        {
            _cart.removeItem(itemId);
            return RedirectToAction("ShowCart");
        }
        public IActionResult Mahdi()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
