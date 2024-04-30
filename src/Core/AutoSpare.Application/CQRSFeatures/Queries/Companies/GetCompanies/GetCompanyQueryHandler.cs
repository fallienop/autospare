using AutoSpare.Application.Repositories.CompanyRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Companies.GetCompanies
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQueryRequest, GetCompanyQueryResponse>
    {
        private readonly ICompanyReadRepository _repository;

        public GetCompanyQueryHandler(ICompanyReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetCompanyQueryResponse> Handle(GetCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var company = _repository.GetAll(false);
            var resp = new GetCompanyQueryResponse()
            {
                Companies = company
            };
            return Task.FromResult(resp);
        }
    }
}
