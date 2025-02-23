﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPartsByModel
{
    public class GetPartsByModelQueryRequest : IRequest<GetPartsByModelQueryResponse>
    {
        public string ModelId { get; set; }
    }
}
