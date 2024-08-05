using MediatR;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.Behaviors
{
    public class CustomerUpdatedNotification:INotification
    {
        public Customer Customer { get; set; }

        public CustomerUpdatedNotification(Customer customer)
        {
            Customer = customer;
        }
    }
}
