using AutoSpare.Application.Repositories.PlateRepo;
using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlateById
{
    public class GetPlateByIdQueryHandler : IRequestHandler<GetPlateByIdQueryRequest, GetPlateByIdQueryResponse>
    {
        private readonly IPlateReadRepository _repository;

        public GetPlateByIdQueryHandler(IPlateReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPlateByIdQueryResponse> Handle(GetPlateByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var plate = await _repository.GetByIdAsync(request.Id);
            return new()
            {
                Plate = plate
            };
        }
    }
}
