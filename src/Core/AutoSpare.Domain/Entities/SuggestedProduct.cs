using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities
{
        [Keyless]
    public class SuggestedProduct
    {
        public string SuggestedProducts { get; set; }
    }
}
