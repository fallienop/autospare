using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Parts.DeletePart
{
    public class DeletePartCommandRequest : IRequest<DeletePartCommandResponse>
    {
        public string Id { get; set; } = null!;

    }
}
