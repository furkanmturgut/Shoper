using Microsoft.AspNetCore.Mvc;
using Shoper.Appplication.Dtos.CustomerDto;
using Shoper.Appplication.Usecasess.CustomerService;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _customerService.GetAllCustomerAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCustomer(int id)
        {
            var result = await _customerService.GetByCustomerIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto dto)
        {
            await _customerService.CreateCustomerAsync(dto);
            return Ok("Müşteri başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto dto)
        { 
            await _customerService.UpdateCustomerAsync(dto);
            return Ok("Müşteri başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok("Müşteri başarıyla silindi");
        }

    }
}
