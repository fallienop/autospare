using AutoSpare.Application.Repositories.CategoryRepo;
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
            await _repository.AddAsync(new()
            {
                Name = request.Name,
                ParentCategoryId= request.ParentCategoryId
            });

          var resp=  await _repository.SaveAsync();

            if (resp > 0)
            {
                return new()
                {
                    Success = true
                };
            }

            return new() { Success = false };
        }
    }
}
