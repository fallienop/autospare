using AutoSpare.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Brands.UpdateBrand
{
    public class UpdateBrandCommandRequest : IRequest<UpdateBrandCommandResponse>
    {
        //public string Id { get; set; }
        //public string Name { get; set; } = null!;
        //public byte[]? Image { get; set; }
        public Brand Brand {  get; set; }

    }
}
