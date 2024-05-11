using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Models.DeleteModel
{
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommandRequest, DeleteModelCommandResponse>
    {
        private readonly IModelWriteRepository _repository;

        public DeleteModelCommandHandler(IModelWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteModelCommandResponse> Handle(DeleteModelCommandRequest request, CancellationToken cancellationToken)
        {
            var model=await _repository.Table.FindAsync(Guid.Parse(request.Id));
            if(model == null) {
            
            return new() { Success = false };
            }
            _repository.Remove(model);
            var resp=await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0
            };
        }
    }
}
