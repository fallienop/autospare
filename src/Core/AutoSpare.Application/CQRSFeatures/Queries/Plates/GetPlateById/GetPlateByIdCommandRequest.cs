﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlateById
{
    public class GetPlateByIdCommandRequest : IRequest<GetPlateByIdCommandResponse>
    {
        public string Id { get; set; }
    }
}
