using AutoSpare.Application.Repositories.PlateRepo;
using AutoSpare.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace AutoSpare.Application.CQRSFeatures.Commands.Plates.AddPlate
{
    public class AddPlateCommandHandler : IRequestHandler<AddPlateCommandRequest, AddPlateCommandResponse>
    {
        private readonly IPlateWriteRepository _repository;

        public AddPlateCommandHandler(IPlateWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddPlateCommandResponse> Handle(AddPlateCommandRequest request, CancellationToken cancellationToken)
        {
            var plate = new Plate()
            {
               Number=request.Number,
               Price=request.Price,
               Location=request.Location,
               Name=request.Name,
               Phone=request.Phone
            };
            await _repository.AddAsync(plate);
            var resp = await _repository.SaveAsync();
            if (resp>0)
            {
                return new()
                {
                    Success = true
                };
            }
            else
            {
                return new()
                {
                    Success = false
                };
            }
        }
    }
}
