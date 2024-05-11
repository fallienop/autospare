using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Makes.AddNewMake
{
    public class AddMakeCommandHandler : IRequestHandler<AddMakeCommandRequest, AddMakeCommandResponse>
    {
        private readonly IMakeWriteRepository _repository;

        public AddMakeCommandHandler(IMakeWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddMakeCommandResponse> Handle(AddMakeCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new() {Name= request.Name });
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };


        }
    }
}
