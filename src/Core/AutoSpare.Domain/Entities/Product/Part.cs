using AutoSpare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities.Product
{
    public class Part : BaseEntity
    {
        public string Name { get; set; } = null!;
        public Guid ModelId { get; set; }
        public Model Model { get; set; } = null!;

        [Range(1960, 2030, ErrorMessage = "Please enter a valid year.")]
        public ushort Year { get; set; }

     [Range(0, long.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid stock quantity.")]
        public ushort Stock { get; set; }

        public ICollection <Order>? Orders { get; set; }

    }
}
