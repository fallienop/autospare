using AutoSpare.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities
{
    public class OrderPart
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid PartId { get; set; }
        public virtual Part Part { get; set; }

        public int Count { get; set; }
        public string Status { get; set; }

    }
}
