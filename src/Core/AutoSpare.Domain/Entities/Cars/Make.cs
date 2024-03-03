using AutoSpare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities.Cars
{
    public class Make : BaseEntity
    {
        public string Name { get; set; } = null!;

    }
}
