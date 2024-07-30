using MediatR;
using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Queries.CustomerAccountQueries
{
    public class GetCustomerAccountQuery : IRequest<List<GetCustomerAccountQuerytResults>>
    {
    }
}
