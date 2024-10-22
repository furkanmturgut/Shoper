using Shoper.Appplication.Dtos.CustomerDto;

namespace Shoper.Appplication.Usecasess.CustomerService
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();
        Task<GetByCustomerIdDto> GetByCustomerIdAsync(int customerId);
        Task CreateCustomerAsync(CreateCustomerDto  customer);
        Task UpdateCustomerAsync(UpdateCustomerDto customer);
        Task DeleteCustomerAsync(int customerId);
    }
}
