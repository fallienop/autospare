using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Models.GetModelsOfMake
{
    public class ModelOMakeQueryRequest : IRequest<ModelOMakeQueryResponse>
    {
        public string Id { get; set; } = null!;
    }
}
