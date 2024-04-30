using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Brands.DeleteBrand
{
    public class DeleteBrandCommandRequest : IRequest<DeleteBrandCommandResponse>
    {
        public string Id { get; set; }
    }
}
