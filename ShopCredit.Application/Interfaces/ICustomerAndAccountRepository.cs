using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.Interfaces
{
    public interface ICustomerAndAccountRepository 
    {
     
        Task<Customer?> GetCustomerByIdWithAccountsAsync(Guid customerId);
    }
}
