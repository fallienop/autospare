using AutoSpare.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Makes.GetAllMakes
{
    public class GetAllMakesQueryResponse 
    {
      public object? Makes { get; set; }
    }
}
