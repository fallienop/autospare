using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Orders.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandRequest : IRequest<ChangeOrderStatusCommandResponse>
    {
        public string OrderId { get; set; }
        public Guid PartId { get; set; }
        public string Status { get; set; }
    }
}
