using MediatR;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.Behaviors
{
    public class CustomerCreatedNotification :INotification
    {
        /// <summary>
        /// 
        /// </summary>
        public Customer Customer { get; set; }
    }
}
