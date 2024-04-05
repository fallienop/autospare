using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Models.AddModeloMake
{
    public class AddModeloMakeCommandRequest : IRequest<AddModeloMakeCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
