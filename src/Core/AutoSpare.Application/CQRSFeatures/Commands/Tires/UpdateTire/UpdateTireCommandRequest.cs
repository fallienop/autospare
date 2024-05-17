using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Tires.UpdateTire
{
    public class UpdateTireCommandRequest : IRequest<UpdateTireCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BrandId { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte Radius { get; set; }
        public string Season { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
