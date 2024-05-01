using AutoSpare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities.Product
{
    public class Model : BaseEntity
    {
        public string Name { get; set; } = null!;
        public Guid? MakeId { get; set; }
        public Make? Make { get; set; }
    }
}
