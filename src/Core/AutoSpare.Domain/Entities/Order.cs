using AutoSpare.Domain.Entities.Product;
using AutoSpare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Address { get; set; } = null!;
        public ICollection<Part> Parts { get; set; } = null!;
        public Customer Customer { get; set; } = null!; 
        public Guid CustomerId { get; set; }
    }
}
