using AutoSpare.Application.Repositories.CategoryRepo;
using MediatR;

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
            var category = await _repository.Table.FindAsync(request.Id);
            category.Name = request.Name;
            var image = request.Image;
            if (image == "deleted")
            {
                category.Image = null;
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
                category.Image = imageByte;

            }
            _repository.Update(category);
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };
        }
    }
}
