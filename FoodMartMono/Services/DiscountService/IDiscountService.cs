

using FoodMartMono.Dtos.DiscountsDto;

namespace FoodMartMono.Services.DiscountService
{
    public interface IDiscountService
    { Task<List<ResultDiscountDto>> GetResultDiscountAsync();
        Task CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto);
        Task DeleteDiscountAsync(string discountId);
        Task<GetDiscountByIdDto> GetDiscountByIdAsync(string discountId);   
    }
}
