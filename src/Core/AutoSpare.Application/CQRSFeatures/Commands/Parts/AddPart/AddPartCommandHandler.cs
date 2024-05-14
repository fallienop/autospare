﻿using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var image = request.Image;
            byte[] imageByte = [];
            if (image != null)
            {
                imageByte = Convert.FromBase64String(image.Substring(image.LastIndexOf(',') + 1));
            }


            await _repository.AddAsync(new() {
                Name=request.Name,
                ModelId=request.ModelId,
                StartYear=request.StartYear,
                EndYear=request.EndYear,
                Price=request.Price,
                Stock=request.Stock,
                Image = imageByte,
                CategoryId=request.CategoryId,
                BrandId=request.BrandId
            });

            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0
            };
        }
    }
}
