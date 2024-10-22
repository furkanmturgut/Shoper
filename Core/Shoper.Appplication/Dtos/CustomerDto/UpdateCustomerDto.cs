using Shoper.Domain.Entities;

namespace Shoper.Appplication.Dtos.CustomerDto
{
    public class UpdateCustomerDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
