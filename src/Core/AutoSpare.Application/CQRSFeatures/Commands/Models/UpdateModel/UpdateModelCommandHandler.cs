using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Models.UpdateModel
{
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommandRequest, UpdateModelCommandResponse>
    {
        private readonly IModelWriteRepository _repository;

        public UpdateModelCommandHandler(IModelWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateModelCommandResponse> Handle(UpdateModelCommandRequest request, CancellationToken cancellationToken)
        {
            var model = await _repository.Table.FindAsync(request.Model.Id);
           model.Name=request.Model.Name;
            _repository.Update(model);
            
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };

        }
    }
}
