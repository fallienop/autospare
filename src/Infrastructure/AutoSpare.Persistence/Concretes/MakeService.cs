using AutoSpare.Application.Abstractions;
using AutoSpare.Domain.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Concretes
{
    public class MakeService : IMakeService
    {
        public List<Make> GetMakes() => new() {

            new()
            {
                Id=Guid.NewGuid(),
                Name= "Mercedes"
            },
            
            new()
            {
                Id=Guid.NewGuid(),
                Name= "Toyota"
            }

        };
    }
}
