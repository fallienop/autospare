using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Brands.AddBrand
{
    public class AddBrandCommandRequest : IRequest<AddBrandCommandResponse>
    {
        public string Name { get; set; }
        public byte[]? Image { get; set; }

    }
}
