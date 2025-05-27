
using FoodMartMono.Dtos.CategoryDtos;

namespace FoodMartMono.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetCategorybyIdDto> GetCategoryByIdAsync(string id);   
    }
}
