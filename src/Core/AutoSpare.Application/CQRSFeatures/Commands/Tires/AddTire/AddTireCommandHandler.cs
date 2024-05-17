using AutoSpare.Application.Repositories.TireRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Tires.AddTire
{
    public class AddTireCommandHandler : IRequestHandler<AddTireCommandRequest, AddTireCommandResponse>
    {
        private readonly ITireWriteRepository _repository;

        public AddTireCommandHandler(ITireWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddTireCommandResponse> Handle(AddTireCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new()
            {
                Name= request.Name,
                BrandId= request.BrandId,
                Width= request.Width,
                Height= request.Height,
                Radius= request.Radius,
                Season= request.Season,
                Price= request.Price,
                Description= request.Description
            });
            var resp = await _repository.SaveAsync();
            return new() { Success = resp>0 };
        }
    }
}
