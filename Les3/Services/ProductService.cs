using Les3.Dtos;
using Les3.Models;

namespace Les3.Services
{
    public class ProductService : IProductService
    {
        readonly Data.AppDbContext context;

        public ProductService(Data.AppDbContext _context)
        {
            context = _context;
        }

        public List<ProductDto> GetProducts()
        {
            var products = context.Products.ToList();

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Category = x.Category
            }).ToList();
        }

        public ProductDto GetProduct(int id)
        {
            var product = context.Products.Find(id);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = product.Count,
                Category = product.Category
            };
        }

        public ProductDto CreateProduct(CreateProductDto obj)
        {
            var product = new ProductEntity
            {
                Name = obj.Name,
                Price = obj.Price,
                Count = obj.Count,
                Category = obj.Category
            };

            context.Products.Add(product);
            context.SaveChanges();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = product.Count,
                Category = product.Category
            };
        }

        public List<ProductDto> GetProductsByPrice()
        {
            var products = context.Products
                .OrderBy(x => x.Price)
                .ToList();

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Category = x.Category
            }).ToList();
        }

        public List<ProductDto> Search(string name)
        {
            var products = context.Products
                .Where(x => x.Name.Contains(name))
                .ToList();

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Category = x.Category
            }).ToList();
        }
    }
}