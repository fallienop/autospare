using AutoSpare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities.Cars
{
    public class Detail : BaseEntity
    {
        public string Name { get; set; }
        public Guid ModelId { get; set; }
        public int Year { get; set; }
        public long Price { get; set; }
        public int Stock { get; set; }

    }
}
