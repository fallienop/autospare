using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.UpdatePart
{
    public class UpdatePartCommandHandler : IRequestHandler<UpdatePartCommandRequest, UpdatePartCommandResponse>
    {
        private readonly IPartWriteRepository _repository;

        public UpdatePartCommandHandler(IPartWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdatePartCommandResponse> Handle(UpdatePartCommandRequest request, CancellationToken cancellationToken)
        {
            _repository.Update(request.Part);
            var resp = await _repository.SaveAsync();


            return new()
            {
                Success = resp > 0
            };
        }
    }
}
