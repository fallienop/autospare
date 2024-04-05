using AutoSpare.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Models.UpdateModel
{
    public class UpdateModelCommandRequest : IRequest<UpdateModelCommandResponse>
    {
        public Model Model { get; set; }
    }
}
