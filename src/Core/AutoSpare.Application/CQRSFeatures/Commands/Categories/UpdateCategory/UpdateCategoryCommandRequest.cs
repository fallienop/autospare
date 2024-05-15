using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Image { get; set; }

    }
}
