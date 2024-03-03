using AutoSpare.Domain.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.Abstractions
{
    public interface IMakeService
    {
        List<Make> GetMakes();
    }
}
