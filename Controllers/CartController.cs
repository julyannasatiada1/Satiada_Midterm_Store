using Microsoft.AspNetCore.Mvc;
using Satiada_Midterm_Store.Data;
using Satiada_Midterm_Store.Models;

namespace Satiada_Midterm_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db) { _db = db; }

        // READ sect (shows cart)
        public IActionResult Index()
        {
            var items = _db.CartItems.ToList();
            return View(items);
        }

        // CREATE sect (adds product to cart)
        public IActionResult Add(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return RedirectToAction("Index", "Products");

            var item = _db.CartItems.FirstOrDefault(c => c.ProductId == id);
            if (item == null)
            {
                item = new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                };
                _db.CartItems.Add(item);
            }
            else
            {
                item.Quantity++;
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // UPDATE sect (change the quantity)
        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            var item = _db.CartItems.Find(id);
            if (item != null && quantity >= 1)
            {
                item.Quantity = quantity;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // DELETE sect (removes item from the cart)
        public IActionResult Remove(int id)
        {
            var item = _db.CartItems.Find(id);
            if (item != null)
            {
                _db.CartItems.Remove(item);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}