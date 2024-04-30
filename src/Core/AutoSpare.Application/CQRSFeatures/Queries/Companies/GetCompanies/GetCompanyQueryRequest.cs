using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Companies.GetCompanies
{
    public class GetCompanyQueryRequest : IRequest<GetCompanyQueryResponse>
    {
    }
}
