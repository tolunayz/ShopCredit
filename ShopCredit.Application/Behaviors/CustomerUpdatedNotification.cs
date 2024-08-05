using MediatR;
using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
