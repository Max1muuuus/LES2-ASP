using Microsoft.AspNetCore.Mvc;
using Les3.Dtos;
using Les3.Services;

namespace Les3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        readonly ProductService service;

        public ProductController(ProductService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(service.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = service.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }

            return Ok(service.CreateProduct(obj));
        }

        [HttpGet("price")]
        public IActionResult GetProductsByPrice()
        {
            return Ok(service.GetProductsByPrice());
        }

        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            return Ok(service.Search(name));
        }
    }
}