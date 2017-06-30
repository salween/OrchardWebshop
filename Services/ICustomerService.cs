using Orchard.Webshop.Models;

namespace Orchard.Webshop.Services
{
    public interface ICustomerService : IDependency
    {
        CustomerPart CreateCustomer(string email, string password);
    }
}
