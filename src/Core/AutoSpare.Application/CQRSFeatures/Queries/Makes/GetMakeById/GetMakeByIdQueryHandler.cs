using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Makes.GetMakeById
{
    public class GetMakeByIdQueryHandler : IRequestHandler<GetMakeByIdQueryRequest, GetMakeByIdQueryResponse>
    {
        private readonly IMakeReadRepository _repository;

        public GetMakeByIdQueryHandler(IMakeReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMakeByIdQueryResponse> Handle(GetMakeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var make = await _repository.GetByIdAsync(request.Id, false);

            return new()
            {
                Make = make
            };
        }
    }
}
