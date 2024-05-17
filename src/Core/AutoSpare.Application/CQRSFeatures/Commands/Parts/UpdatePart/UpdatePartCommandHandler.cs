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

            var part = await _repository.Table.FindAsync(request.Id);

            part.Name = request.Name;
            part.ModelId=request.ModelId;
            part.StartYear = request.StartYear;
            part.EndYear=request.EndYear;
            part.Price= request.Price;
            part.Stock= request.Stock;
            part.Image1 = imageByte1;
            part.Image2 = imageByte2;
            part.Image3 = imageByte3;
            part.CategoryId = request.CategoryId;
            part.Description = request.Description;

            _repository.Update(part);
            var resp = await _repository.SaveAsync();


            return new()
            {
                Success = resp > 0
            };
        }
    }
}
