using AutoSpare.Application.Repositories.CategoryRepo;
using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Commands.Categories.DeleteCategoryById
{
    public class DeleteCategoryByIdCommandHandler : IRequestHandler<DeleteCategoryByIdCommandRequest, DeleteCategoryByIdCommandResponse>
    {
        private readonly ICategoryWriteRepository _repository;

        public DeleteCategoryByIdCommandHandler(ICategoryWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCategoryByIdCommandResponse> Handle(DeleteCategoryByIdCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0 
            };
        }
    }
}
