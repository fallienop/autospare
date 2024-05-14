using AutoSpare.Application.Repositories.BrandRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Brands.AddBrand
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommandRequest, AddBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _repository;

        public AddBrandCommandHandler(IBrandWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddBrandCommandResponse> Handle(AddBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new() {Name=request.Name,Image=request.Image });
            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0 
            };
        }
    }
}
