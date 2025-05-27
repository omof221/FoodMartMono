using FoodMartMono.Dtos.CustomerDto;

namespace FoodMartMono.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetResultCustomerAsync();
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomerAsync(string customerId);    
        Task<GetCustomerByIdDto> GetCustomerByIdAsync(string customerId);   
    }
}
