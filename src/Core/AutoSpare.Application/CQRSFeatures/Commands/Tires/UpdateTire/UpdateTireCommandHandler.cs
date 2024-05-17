using AutoSpare.Application.Repositories.TireRepo;
using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Commands.Tires.UpdateTire
{
    public class UpdateTireCommandHandler : IRequestHandler<UpdateTireCommandRequest, UpdateTireCommandResponse>
    {
        private readonly ITireWriteRepository _repository;

        public UpdateTireCommandHandler(ITireWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateTireCommandResponse> Handle(UpdateTireCommandRequest request, CancellationToken cancellationToken)
        {
            var tire = await _repository.Table.FindAsync(request.Id);
            if (tire == null)
            {
                return new()
                {
                    Success = false
                };
            }
            tire.Name = request.Name;
            tire.BrandId = request.BrandId;
            tire.Width = request.Width;
            tire.Height = request.Height;
            tire.Radius = request.Radius;
            tire.Season = request.Season;
            tire.Price = request.Price;
            tire.Description = request.Description;
            var resp =  await _repository.SaveAsync();
            return new()
            {
                Success=resp>0
            };
        }
    }
}
