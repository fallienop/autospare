using AutoSpare.Domain.Entities.Common;
using AutoSpare.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities
{
    public class Tire : BaseEntity
    {
        public string Name { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte Radius { get; set; }
        public string Season { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
      
        public string Description { get; set; }
        //public string Availability { get; set; }
    }
}
