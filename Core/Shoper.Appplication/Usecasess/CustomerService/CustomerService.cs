using Shoper.Appplication.Dtos.CustomerDto;
using Shoper.Appplication.Interfaces;
using Shoper.Domain.Entities;

namespace Shoper.Appplication.Usecasess.CustomerService
{
    public class CustomerService : ICustomerService
    {

        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            var result = await _customerRepository.GetAllAsync();
            return result.Select(x => new ResultCustomerDto
            {
                CustomerId = x.CustomerId,
                Orders = x.Orders,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
        }

        public async Task<GetByCustomerIdDto> GetByCustomerIdAsync(int customerId)
        {
            var result = await _customerRepository.GetByIdAsync(customerId);
            return new GetByCustomerIdDto
            {
                Orders = result.Orders,
                LastName = result.LastName,
                CustomerId = result.CustomerId,
                Email = result.Email,
                FirstName = result.FirstName
            };
        }

        public async Task CreateCustomerAsync(CreateCustomerDto customer)
        {
            await _customerRepository.CreateAsync(new Customer
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            });
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto customer)
        {
            var result = await _customerRepository.GetByIdAsync(customer.CustomerId);
            result.FirstName = customer.FirstName;
            result.LastName = customer.LastName;
            result.Email = customer.Email;
            result.Orders = customer.Orders;

            await _customerRepository.UpdateAsync(result);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var result = await _customerRepository.GetByIdAsync(customerId);
            await _customerRepository.DeleteAsync(result);
        }
    }
}
