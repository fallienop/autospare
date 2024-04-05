using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Models.DeleteModel
{
    public class DeleteModelCommandRequest : IRequest<DeleteModelCommandResponse>
    {
        public string Id { get; set; } = null!;
    }
}
