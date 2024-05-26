using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Orders.GetOrdersOfCompany
{
    public class GetOrdersOfCompanyQueryRequest : IRequest<GetOrdersOfCompanyQueryResponse>
    {
    }
}
