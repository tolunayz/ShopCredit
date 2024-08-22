using MediatR;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using System;

namespace ShopCredit.Application.CQRS.Queries.CustomerQueries
{
    public class GetCustomerQuery : IRequest<List<GetCustomerQueryResult>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public GetCustomerQuery()
        {
         
        }
    }
}
