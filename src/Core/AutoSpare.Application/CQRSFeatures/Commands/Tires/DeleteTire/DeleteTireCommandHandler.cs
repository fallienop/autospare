using AutoSpare.Application.Repositories.TireRepo;
using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Commands.Tires.DeleteTire
{
    public class DeleteTireCommandHandler : IRequestHandler<DeleteTireCommandRequest, DeleteTireCommandResponse>
    {
        private readonly ITireWriteRepository _repository;

        public DeleteTireCommandHandler(ITireWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteTireCommandResponse> Handle(DeleteTireCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
            var resp = await _repository.SaveAsync();
            return new() { Success = resp > 0 };
        }
    }
}
