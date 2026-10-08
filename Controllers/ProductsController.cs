using Microsoft.AspNetCore.Mvc;
using Satiada_Midterm_Store.Data;
using Satiada_Midterm_Store.Models;

namespace Satiada_Midterm_Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db) { _db = db; }

        // READ
        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        // CREATE sect (Form)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (Save)
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // UPDATE (Form)
        public IActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return RedirectToAction("Index");
            return View(product);
        }

        // UPDATE sect (Save)
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE sect
        public IActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
