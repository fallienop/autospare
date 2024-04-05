using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Makes.UpdateMake
{
    public class UpdateMakeCommandHandler : IRequestHandler<UpdateMakeCommandRequest, UpdateMakeCommandResponse>
    {
        private readonly IMakeWriteRepository _repository;

        public UpdateMakeCommandHandler(IMakeWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateMakeCommandResponse> Handle(UpdateMakeCommandRequest request, CancellationToken cancellationToken)
        {
          _repository.Update(request.Make);
            var resp = await _repository.SaveAsync();


            if (resp > 0)
            {
                return new() { Success = true };

            }
            return new() { Success = false };
        }
    }
}
