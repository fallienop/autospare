using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Tires.DeleteTire
{
    public class DeleteTireCommandRequest : IRequest<DeleteTireCommandResponse> 
    {
        public string Id { get; set; }
    }
}
