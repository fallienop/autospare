﻿using AutoSpare.Application.Repositories.CategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Categories.AddNewCategory
{
    public class AddNewCategoryCommandHandler : IRequestHandler<AddNewCategoryCommandRequest, AddNewCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _repository;

        public AddNewCategoryCommandHandler(ICategoryWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddNewCategoryCommandResponse> Handle(AddNewCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var image = request.Image;
            byte[] imageByte = [];
            if (image != null)
            {
                imageByte = Convert.FromBase64String(image.Substring(image.LastIndexOf(',') + 1));
            }


            await _repository.AddAsync(new()
            {
                Name = request.Name,
                ParentCategoryId =  request.ParentCategoryId,
                Image=imageByte
            });

          var resp=  await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0 
            };
        }
    }
}
