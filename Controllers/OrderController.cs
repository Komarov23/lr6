using lr6.Models;
using Microsoft.AspNetCore.Mvc;

namespace lr6.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        public IActionResult Register(User request)
        {
            if (request.Age >= 16) return View("Quantity");
            else return View("UnderAge");
        }

        [HttpPost]
        public IActionResult ShowProducts(int quantity)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < quantity; i++) products.Add(new Product { Name = "Pizza " + (i + 1).ToString(), Quantity = 0 });
            return View("Products", products);
        }

        [HttpPost]
        public IActionResult OrderProducts(List<Product> products)
        {
            var filteredProducts = from product in products where product.Quantity != 0 select product;
            return View("Order", filteredProducts.ToList<Product>());
        }
    }
}
