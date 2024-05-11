using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.DeletePart
{
    public class DeletePartCommandHandler : IRequestHandler<DeletePartCommandRequest, DeletePartCommandResponse>
    {
        private readonly IPartWriteRepository _repository;

        public DeletePartCommandHandler(IPartWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeletePartCommandResponse> Handle(DeletePartCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
            var resp = await _repository.SaveAsync();


            return new()
            {
                Success = resp > 0 
            };

        }
    }
}
