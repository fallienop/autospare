using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Makes.DeleteMake
{
    public class DeleteMakeCommandRequest : IRequest<DeleteMakeCommandResponse>
    {
        public string Id { get; set; } = null!;
    }
}
