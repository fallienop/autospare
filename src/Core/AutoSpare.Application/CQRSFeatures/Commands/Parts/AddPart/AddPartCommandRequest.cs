using AutoSpare.Domain.Entities;
using AutoSpare.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.AddPart
{
    public class AddPartCommandRequest : IRequest<AddPartCommandResponse>
    {
        public string Name { get; set; } = null!;
        public Guid ModelId { get; set; }
        public ushort StartYear { get; set; }
        public ushort EndYear { get; set; }
        public decimal Price { get; set; }
        public ushort Stock { get; set; }
        public string? Image { get; set; }
        public Guid CategoryId { get; set; }
        //public Guid? CompanyId { get; set; }
        public Guid BrandId { get; set; }

    }
}
