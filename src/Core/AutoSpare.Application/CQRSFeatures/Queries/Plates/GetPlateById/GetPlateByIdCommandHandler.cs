using AutoSpare.Application.Repositories.PlateRepo;
using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlateById
{
    public class GetPlateByIdCommandHandler : IRequestHandler<GetPlateByIdCommandRequest, GetPlateByIdCommandResponse>
    {
        private readonly IPlateReadRepository _repository;

        public GetPlateByIdCommandHandler(IPlateReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPlateByIdCommandResponse> Handle(GetPlateByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var plate = await _repository.GetByIdAsync(request.Id);
            return new()
            {
                Plate = plate
            };
        }
    }
}
