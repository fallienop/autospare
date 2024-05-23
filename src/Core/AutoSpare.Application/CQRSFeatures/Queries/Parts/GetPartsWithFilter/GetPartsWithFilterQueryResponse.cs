using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPartsWithFilter
{
    public class GetPartsWithFilterQueryResponse
    {
        public ICollection<Domain.Entities.Product.Part> Parts {  get; set; }
    }
}
