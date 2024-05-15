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
            var brand = await _repository.Table.FindAsync(request.Id);
            brand.Name = request.Name;
            var image = request.Image;
            if (image == "deleted")
            {
                brand.Image = null;
            }
            else if (image == "same")
            {

            }
            else
            {

                byte[] imageByte = [];
                if (image != null)
                {
                    imageByte = Convert.FromBase64String(image.Substring(image.LastIndexOf(',') + 1));
                }
                brand.Image = imageByte;

            }
            _repository.Update(brand);
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };
        }
    }
}
