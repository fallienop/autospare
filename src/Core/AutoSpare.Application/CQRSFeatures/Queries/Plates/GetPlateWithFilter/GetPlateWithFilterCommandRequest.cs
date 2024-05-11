using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlateWithFilter
{
    public class GetPlateWithFilterCommandRequest : IRequest<GetPlateWithFilterCommandResponse>
    {
        public string Pattern { get; set; }
    }
}
