using AutoSpare.Domain.Entities;
using AutoSpare.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.UpdatePart
{
    public class UpdatePartCommandRequest : IRequest<UpdatePartCommandResponse> 
    {
       public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid ModelId { get; set; }

        [Range(1960, 2030, ErrorMessage = "Please enter a valid year.")]
        public ushort StartYear { get; set; }
        [Range(1960, 2030, ErrorMessage = "Please enter a valid year.")]

        public ushort EndYear { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid stock quantity.")]
        public ushort Stock { get; set; }

        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }

        public Guid CategoryId { get; set; }

        public Guid? BrandId { get; set; }
        public string Description { get; set; }

    }
}
