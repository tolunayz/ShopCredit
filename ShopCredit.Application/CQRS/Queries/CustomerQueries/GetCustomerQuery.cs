using MediatR;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using System;

namespace ShopCredit.Application.CQRS.Queries.CustomerQueries
{
    public class GetCustomerQuery : IRequest<List<GetCustomerQueryResult>>
    {
        //public Guid Id { get; set; }

        //public GetCustomerQuery(Guid id)
        //{
        //    Id = id;
        //}

        public GetCustomerQuery()
        {
            
        }
    }
}
