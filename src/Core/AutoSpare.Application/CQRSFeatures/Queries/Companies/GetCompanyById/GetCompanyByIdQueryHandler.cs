using AutoSpare.Application.Repositories.CompanyRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Companies.GetCompanyById
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQueryRequest, GetCompanyByIdQueryResponse>
    {
        private readonly ICompanyReadRepository _repository;

        public GetCompanyByIdQueryHandler(ICompanyReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id, false);

            return new()
            {
                Company = company
            };
        }
    }
}
