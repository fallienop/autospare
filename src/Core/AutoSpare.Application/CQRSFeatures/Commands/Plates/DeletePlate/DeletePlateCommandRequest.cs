using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Plates.DeletePlate
{
    public class DeletePlateCommandRequest : IRequest<DeletePlateCommandResponse>
    {
        public string Id {  get; set; }
    }
}
