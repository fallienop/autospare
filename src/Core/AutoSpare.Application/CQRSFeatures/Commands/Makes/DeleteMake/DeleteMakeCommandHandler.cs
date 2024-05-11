using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Makes.DeleteMake
{
    public class DeleteMakeCommandHandler : IRequestHandler<DeleteMakeCommandRequest, DeleteMakeCommandResponse>
    {
        private readonly IMakeWriteRepository _repository;

        public DeleteMakeCommandHandler(IMakeWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteMakeCommandResponse> Handle(DeleteMakeCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id );
            var resp=await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };


        }
    }
}
