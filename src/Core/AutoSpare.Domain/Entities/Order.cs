using AutoSpare.Domain.Entities.Product;
using AutoSpare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSpare.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSpare.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Address { get; set; } = null!;
        //public virtual ICollection<Part> Parts { get; set; } = new List<Part>();

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderPart> OrderPart { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

    }
}
