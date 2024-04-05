using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Makes.AddNewMake
{
    public class AddMakeCommandRequest :IRequest<AddMakeCommandResponse>
    {
        public string Name { get; set; } = null!;

    }
}
