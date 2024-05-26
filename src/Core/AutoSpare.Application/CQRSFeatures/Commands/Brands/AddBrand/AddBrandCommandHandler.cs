using AutoSpare.Application.Repositories.BrandRepo;
using MediatR;

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

            var image = request.Image;
            byte[] imageByte = [];
            if (image != null)
            {
                imageByte = Convert.FromBase64String(image.Substring(image.LastIndexOf(',') + 1));
            }

            await _repository.AddAsync(new() { Name = request.Name, Image = imageByte });
            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0
            };
        }
    }
}
