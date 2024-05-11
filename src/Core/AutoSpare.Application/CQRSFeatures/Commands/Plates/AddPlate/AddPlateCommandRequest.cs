using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Plates.AddPlate
{
    public class AddPlateCommandRequest : IRequest<AddPlateCommandResponse>
    {
        public string Number { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
