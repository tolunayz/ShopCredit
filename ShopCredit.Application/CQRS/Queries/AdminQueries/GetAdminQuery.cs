using MediatR;
using ShopCredit.Application.CQRS.Results.AdminResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Queries.AdminQueries
{
    public class GetAdminQuery: IRequest<List<GetAdminQueryResult>>
    {
    }
}
