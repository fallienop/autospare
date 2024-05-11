using AutoSpare.Application.Repositories.PlateRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Plates.DeletePlate
{
    public class DeletePlateCommandHandler : IRequestHandler<DeletePlateCommandRequest, DeletePlateCommandResponse>
    {
        private readonly IPlateWriteRepository _repository;

        public DeletePlateCommandHandler(IPlateWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeletePlateCommandResponse> Handle(DeletePlateCommandRequest request, CancellationToken cancellationToken)
        {
            var plate =await _repository.RemoveByIdAsync(request.Id);
            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0 
            };
        }
    }
}
