using Les3.Dtos;

namespace Les3.Services
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductDto GetProduct(int id);
        ProductDto CreateProduct(CreateProductDto obj);
        List<ProductDto> GetProductsByPrice();
        List<ProductDto> Search(string name);
    }
}