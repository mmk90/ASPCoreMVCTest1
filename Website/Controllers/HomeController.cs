using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemID == itemId);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
                if (order != null)
                {
                    var orderDetail =
                        _context.OrderDetails.FirstOrDefault(d =>
                            d.OrderId == order.OrderId && d.ProductId == product.ID);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.OrderDetails.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.ID,
                            Price = product.Item.Price,
                            Count = 1
                        });
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    _context.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.ID,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }

                _context.SaveChanges();
            }
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o => o.UserId == userId && !o.IsFinaly)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();
            return View(order);
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {

            var orderDetail = _context.OrderDetails.Find(detailId);
            _context.Remove(orderDetail);
            _context.SaveChanges();

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

        [Route("/Category/{categoryID}/{categoryName}")]
        public IActionResult GetProductByCategory(int categoryID,string categoryName)
        {
            ViewData["CategoryName"] = categoryName;
            var model = _context.CategorytoProducts.Where(c => c.CategoryID == categoryID).Include(c => c.Product).Select(c => c.Product).ToList();
            return View(model);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
