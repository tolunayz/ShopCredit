using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.Interfaces
{
    public interface ICustomerAndAccountRepository 
    {
     
        Task<Customer?> GetCustomerByIdWithAccountsAsync(Guid customerId);
    }
}
