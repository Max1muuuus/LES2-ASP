using Microsoft.AspNetCore.Mvc;
using Les3.Models;

namespace Les3.Controllers
{
    public class ProductController : Controller
    {
        readonly Data.AppDbContext context;

        public ProductController(Data.AppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = context.Products.ToList();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product = context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product obj)
        {
            if (obj == null)
            {
                return BadRequest("Product object is null.");
            }

            context.Products.Add(obj);
            context.SaveChanges();

            return Ok(obj);
        }

        [HttpGet]
        public IActionResult GetProductsByPrice()
        {
            var products = context.Products
                .OrderBy(x => x.Price)
                .ToList();

            return Ok(products);
        }

        [HttpGet]
        public IActionResult Search(string name)
        {
            var products = context.Products
                .Where(x => x.Name.Contains(name))
                .ToList();

            return Ok(products);
        }
    }
}