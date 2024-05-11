using AutoSpare.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.Repositories.PlateRepo
{
    public interface IPlateReadRepository : IReadRepository<Plate>
    {

    }
}
