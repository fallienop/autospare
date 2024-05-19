using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.UpdatePart
{
    public class UpdatePartCommandRequest : IRequest<UpdatePartCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid ModelId { get; set; }

        [Range(1960, 2030, ErrorMessage = "Please enter a valid year.")]
        public ushort StartYear { get; set; }
        [Range(1960, 2030, ErrorMessage = "Please enter a valid year.")]

        public ushort EndYear { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid stock quantity.")]
        public ushort Stock { get; set; }

        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }

        public Guid CategoryId { get; set; }

        public Guid? BrandId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

    }
}
