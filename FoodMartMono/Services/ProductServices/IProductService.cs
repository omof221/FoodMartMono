using FoodMartMono.Dtos.ProductDto;

namespace FoodMartMono.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetResultProductAsync();
        Task CreateProoductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetProductByIdDto> GetProductByIdAsync(string id); 
    }
}
