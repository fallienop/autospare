using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Companies.GetCompanyById
{
    public class GetCompanyByIdQueryRequest : IRequest<GetCompanyByIdQueryResponse>
    {
        public string Id { get; set; }

    }
}
