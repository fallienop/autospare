using AutoSpare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities.Product
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; } = null!;


        public byte[]? Image { get; set; }
    }
}
