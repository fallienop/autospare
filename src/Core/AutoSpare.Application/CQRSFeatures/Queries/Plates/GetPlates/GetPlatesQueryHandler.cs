using AutoSpare.Application.Repositories.PlateRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlates
{
    public class GetPlatesQueryHandler : IRequestHandler<GetPlatesQueryRequest, GetPlatesQueryResponse>
    {
        private readonly IPlateReadRepository _repository;

        public GetPlatesQueryHandler(IPlateReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetPlatesQueryResponse> Handle(GetPlatesQueryRequest request, CancellationToken cancellationToken)
        {
            var resp = _repository.GetAll(false);
            var plates= new GetPlatesQueryResponse()
            {
                Plates = resp
            };
            return Task.FromResult(plates);
        }
    }
}
