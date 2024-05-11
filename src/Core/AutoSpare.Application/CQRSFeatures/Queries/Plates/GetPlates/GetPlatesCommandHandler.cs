using AutoSpare.Application.Repositories.PlateRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlates
{
    public class GetPlatesCommandHandler : IRequestHandler<GetPlatesCommandRequest, GetPlatesCommandResponse>
    {
        private readonly IPlateReadRepository _repository;

        public GetPlatesCommandHandler(IPlateReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetPlatesCommandResponse> Handle(GetPlatesCommandRequest request, CancellationToken cancellationToken)
        {
            var resp = _repository.GetAll(false);
            var plates= new GetPlatesCommandResponse()
            {
                Plates = resp
            };
            return Task.FromResult(plates);
        }
    }
}
