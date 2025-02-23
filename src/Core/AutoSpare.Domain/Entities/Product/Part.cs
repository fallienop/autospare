﻿using AutoSpare.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace AutoSpare.Domain.Entities.Product
{
    public class Part : BaseEntity
    {
        public string Name { get; set; } = null!;
        public Guid ModelId { get; set; }
        public Model Model { get; set; } = null!;

        [Range(1960, 2030, ErrorMessage = "Please enter a valid year.")]
        public ushort StartYear { get; set; }
        [Range(1960, 2030, ErrorMessage = "Please enter a valid year.")]

        public ushort EndYear { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid stock quantity.")]
        public ushort Stock { get; set; }

        //public ICollection<Order>? Orders { get; set; }
        public virtual ICollection<OrderPart> OrderPart { get; set; }


        public byte[]? Image1 { get; set; }
        public byte[]? Image2 { get; set; }
        public byte[]? Image3 { get; set; }


        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public Brand? Brand { get; set; }
        public Guid? BrandId { get; set; }
        
        public Company? Company { get; set; }
        public Guid? CompanyId { get; set; }
        
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
