using MediatR;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.Behaviors
{
    public class CustomerCreatedNotification :INotification
    {
       
        public Customer Customer { get; set; }

        public CustomerCreatedNotification(Customer customer)
        {
            Customer = customer;
        }
    }
}
