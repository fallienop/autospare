using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Makes.GetMakeById
{
    public class GetMakeByIdQueryRequest : IRequest<GetMakeByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
