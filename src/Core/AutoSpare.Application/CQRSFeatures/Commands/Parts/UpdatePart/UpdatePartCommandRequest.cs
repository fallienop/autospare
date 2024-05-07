using AutoSpare.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.UpdatePart
{
    public class UpdatePartCommandRequest : IRequest<UpdatePartCommandResponse> 
    {
        public Part Part { get; set; }

    }
}
