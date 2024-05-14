using AutoSpare.Application.Repositories.CategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //var category = await _repository.Table.FindAsync(request.Category.Id);
            //category=request.Category;
            _repository.Update(request.Category);
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };
        }
    }
}
