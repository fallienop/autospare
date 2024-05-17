using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.AddPart
{
    public class AddPartCommandHandler : IRequestHandler<AddPartCommandRequest, AddPartCommandResponse>
    {
        private readonly IPartWriteRepository _repository;

        public AddPartCommandHandler(IPartWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddPartCommandResponse> Handle(AddPartCommandRequest request, CancellationToken cancellationToken)
        {
            var image1 = request.Image1;
            var image2 = request.Image2;
            var image3 = request.Image3;
            byte[] imageByte1 = [];
            byte[] imageByte2 = [];
            byte[] imageByte3 = [];
            if (image1 != null)
            {
                imageByte1 = Convert.FromBase64String(image1.Substring(image1.LastIndexOf(',') + 1));
            }
            if (image2 != null)
            {
                imageByte2 = Convert.FromBase64String(image2.Substring(image2.LastIndexOf(',') + 1));
            }
            if (image3 != null)
            {
                imageByte3 = Convert.FromBase64String(image3.Substring(image3.LastIndexOf(',') + 1));
            }


            await _repository.AddAsync(new()
            {
                Name = request.Name,
                ModelId = request.ModelId,
                StartYear = request.StartYear,
                EndYear = request.EndYear,
                Price = request.Price,
                Stock = request.Stock,
                Image1 = imageByte1,
                Image2 = imageByte2,
                Image3 = imageByte3,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                Description=request.Description
                
            });

            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0
            };
        }
    }
}
