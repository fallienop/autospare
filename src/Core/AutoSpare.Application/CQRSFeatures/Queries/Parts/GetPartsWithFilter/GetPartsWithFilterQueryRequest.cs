using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPartsWithFilter
{
    public class GetPartsWithFilterQueryRequest : IRequest<GetPartsWithFilterQueryResponse>
    {
        public string? ModelId { get; set; }
        public List<Guid>? BrandId { get; set; }
        public List<Guid>? CompanyId { get; set; }
        public int? MinimumPrice { get; set; }
        public int? MaximumPrice { get; set; }
        public string? CategoryId { get; set; }
        public int? Year { get; set; }
    }
}
