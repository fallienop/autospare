using AutoSpare.Application.Repositories.BrandRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Brands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest, DeleteBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _repository;

        public DeleteBrandCommandHandler(IBrandWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteBrandCommandResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
            var resp = await _repository.SaveAsync();
            if (resp > 0)
            {
                return new() { Success = true };
            }
            return new() { Success = false };
        }
    }
}
