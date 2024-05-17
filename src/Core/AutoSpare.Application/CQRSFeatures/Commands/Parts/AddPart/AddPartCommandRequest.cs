using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.AddPart
{
    public class AddPartCommandRequest : IRequest<AddPartCommandResponse>
    {
        public string Name { get; set; } = null!;
        public Guid ModelId { get; set; }
        public ushort StartYear { get; set; }
        public ushort EndYear { get; set; }
        public decimal Price { get; set; }
        public ushort Stock { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public Guid CategoryId { get; set; }
        //public Guid? CompanyId { get; set; }
        public Guid BrandId { get; set; }
        public string Description { get; set; }


    }
}
