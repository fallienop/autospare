using AutoSpare.Application.Repositories.BrandRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Brands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _repository;

        public UpdateBrandCommandHandler(IBrandWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            //var brand = await _repository.Table.FindAsync(request.Brand.Id);
           
            //brand=request.Brand;
            _repository.Update(request.Brand);
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0 
            };
        }
    }
}
