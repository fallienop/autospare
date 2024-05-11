using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Models.AddModeloMake
{
    public class AddModeloMakeCommandHandler : IRequestHandler<AddModeloMakeCommandRequest, AddModeloMakeCommandResponse>
    {

        private readonly IModelWriteRepository _repository;

        public AddModeloMakeCommandHandler(IModelWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddModeloMakeCommandResponse> Handle(AddModeloMakeCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new() {MakeId=request.Id, Name=request.Name });
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };
        }
    }
}
