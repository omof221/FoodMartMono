using FoodMartMono.Dtos.TrendProductDto;

namespace FoodMartMono.Services.TrendProductService
{
    public interface ITrendProductService
    {
        Task<List<ResultTrendProductDto>> GetTrendProductsAsync();
        Task CreateTrendProductAsync(CreateTrendProductDto createTrendProductDto);
        Task UpdateTrendProductAsync(UpdateTrendProductDto updateTrendProductDto);
        Task DeleteTrendProductAsync(string id);
        Task<GetTrendProductByIdDto> GetTrendProductByIdAsync(string id);
    }
}
